# reference code: https://github.com/chartbeat-labs/textacy/blob/main/src/textacy/extract/triples.py

from typing import Union, Callable, Iterable

from spacy.symbols import (
    aux,
    auxpass,
    csubj,
    csubjpass,
    neg,
    nsubj,
    nsubjpass,
)
from spacy.tokens import Doc, Span, Token

DocLike = Union[Doc, Span]
SpanLike = Union[Span, Token]
DocLikeToSpans = Callable[[DocLike], Iterable[Span]]
DocOrTokens = Union[Doc, Iterable[Token]]

_NOMINAL_SUBJ_DEPS = {nsubj, nsubjpass}
_CLAUSAL_SUBJ_DEPS = {csubj, csubjpass}
_ACTIVE_SUBJ_DEPS = {csubj, nsubj}
_VERB_MODIFIER_DEPS = {aux, auxpass, neg}
