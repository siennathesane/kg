# reference code: https://github.com/chartbeat-labs/textacy/blob/main/src/textacy/extract/triples.py

import collections
from json import JSONEncoder
from operator import attrgetter
from typing import Iterable, Mapping, List

from spacy.symbols import VERB, dobj, pobj, agent, xcomp
from spacy.tokens import Token, Span

from . import DocLike, _NOMINAL_SUBJ_DEPS, _CLAUSAL_SUBJ_DEPS, _VERB_MODIFIER_DEPS

# noinspection PyTypeChecker
SVOTriple: tuple[list[Token], list[Token], list[Token]] = collections.namedtuple(
    "SVOTriple", ["subject", "verb", "object"]
)


class SubjectPredicateObject:
    subjects: list[Token]
    predicates: list[Token]
    objects: list[Token]

    def __init__(self, subjects: list[Token], predicates: list[Token], objects: list[Token]):
        super().__init__()
        self.subjects = subjects
        self.predicates = predicates
        self.objects = objects


def svo_triples(doclike: DocLike, clausal_compliment_expansion: bool) -> Iterable[SVOTriple]:
    sentences: Iterable[Span]
    if isinstance(doclike, Span):
        sentences = [doclike]
    else:
        sentences = doclike.sents

    for sentence in sentences:
        verb_sub: Mapping = collections.defaultdict(lambda: collections.defaultdict(set))

        for token in sentence:
            head = token.head

            # to catch verbs and conjunction verbs without a subject
            if token.pos == VERB:
                _ = verb_sub[token]

            # nominal subjects
            if token.dep in _NOMINAL_SUBJ_DEPS:
                if head.pos == VERB:
                    verb_sub[head]["subjects"].update(expand_noun(token))

            # clausal subjects
            elif token.dep in _CLAUSAL_SUBJ_DEPS:
                if head.pos == VERB:
                    verb_sub[head]["subjects"].update(token.subtree)

            # transitive & nominal directs
            elif token.dep == dobj:
                if head.pos == VERB:
                    verb_sub[head]["objects"].update(expand_noun(token))

            # prepositional object acting as agent of passive verb
            elif token.dep == pobj:
                if head.dep == agent and head.head.pos == VERB:
                    verb_sub[head.head]["objects"].update(expand_noun(token))

            # open clausal complement, but not as a secondary predicate
            elif token.dep == xcomp:
                if head.pos == VERB and not any(child.dep == dobj for child in head.children):
                    if clausal_compliment_expansion:
                        # todo (sienna): validate this is grammatically correct
                        verb_sub[head.pos]["objects"].update(expand_verb(token))
                    verb_sub[head]["objects"].update(token.subtree)

        # indirect relationships with verb conjunctions
        for verb, sub_obj_dict in verb_sub.items():
            conjunctions = verb.conjuncts
            if sub_obj_dict.get("subjects"):
                for conj in conjunctions:
                    conjunction_sub_obj_dict = verb_sub.get(conj)
                    if conjunction_sub_obj_dict and not conjunction_sub_obj_dict.get("subjects"):
                        conjunction_sub_obj_dict["subjects"].update(sub_obj_dict["subjects"])
            if not sub_obj_dict.get("objects"):
                sub_obj_dict["objects"].update(
                    obj
                    for conj in conjunctions
                    for obj in verb_sub.get(conj, {}).get("objects", [])
                )

        # expand and restructure
        for verb, sub_obj_dict in verb_sub.items():
            if sub_obj_dict["subjects"] and sub_obj_dict["objects"]:
                # yield SubjectPredicateObject(sub_obj_dict["subjects"], expand_verb(verb), sub_obj_dict["objects"])
                yield SVOTriple(
                    subject=sorted(sub_obj_dict["subjects"], key=attrgetter("i")),
                    verb=sorted(expand_verb(verb), key=attrgetter("i")),
                    object=sorted(sub_obj_dict["objects"], key=attrgetter("i"))
                )


def expand_noun(token: Token) -> List[Token]:
    """Expand a noun token to include all associated conjunct and compound nouns."""
    tok_and_conjuncts = [token] + list(token.conjuncts)
    compounds = [
        child
        for tc in tok_and_conjuncts
        for child in tc.children
        # TODO: why doesn't compound import from spacy.symbols?
        if child.dep_ == "compound"
    ]
    return tok_and_conjuncts + compounds


def expand_verb(token: Token) -> List[Token]:
    """Expand a verb token to include all associated auxiliary and negation tokens."""
    verb_modifiers = [
        child for child in token.children if child.dep in _VERB_MODIFIER_DEPS
    ]
    return [token] + verb_modifiers


def to_json(triples: Iterable[SVOTriple]) -> str:
    t = []
    for triple in triples:

        t.append({
            "subjects": [{"id": s.i, "value": str(s)} for s in triple.subject],
            "predicates": [{"id": s.i, "value": str(s)} for s in triple.verb],
            "objects": [{"id": s.i, "value": str(s)} for s in triple.object],
        })