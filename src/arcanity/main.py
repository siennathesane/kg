#!/usr/bin/env python3
import sentry_sdk
import spacy

from os import getenv
from sanic import Sanic
from sanic.request import Request
from sanic.response import JSONResponse, json
from sanic.worker.manager import WorkerManager
from sentry_sdk import capture_exception
from sentry_sdk.integrations.sanic import SanicIntegration
from spacy.morphology import Morphology
from spacy.tokens.doc import Doc
from warnings import simplefilter

app = Sanic("arcanity")

sentry_sdk.init(
    dsn="https://94586711de2c4723b92f768f6337f86f@o4504901793873920.ingest.sentry.io/4504901795774464",
    traces_sample_rate=1.0,
    sample_rate=1.0,
    integrations=[SanicIntegration()],
    _experiments={
        "profiles_sample_rate": 1.0,
    },
)

# hide the warning logs
simplefilter("ignore")

# set up the app and set the worker boot timer
WorkerManager.THRESHOLD = 1800


@app.before_server_start
async def nlp_loader(app_ctx, _):
    """
    Load the NLP model before the server starts. Currently, the only model is `en_core_web_trf`
    Args:
        app_ctx: Sanic Application object
        _:

    Returns: None

    """
    app_ctx.ctx.nlp = spacy.load("en_core_web_trf")


@app.on_request
async def load_model(request: Request):
    """
    Make a reference to the model per-request to ensure processing individual requests is faster
    Args:
        request: HTTP request object

    Returns:

    """
    request.ctx.nlp = app.ctx.nlp


@app.post("/v1/nlp/extract")
async def extract(request: Request) -> JSONResponse:
    """
    Extract the information from free-form text.
    Args:
        request: An HTTP POST request.

    Returns: JSON HTTP response

    """
    # noinspection PyUnusedLocal,PyTypeChecker
    parsed: Doc = None
    body = request.json
    try:
        parsed = request.ctx.nlp(body["content"])
    except Exception as e:
        capture_exception(e)
        return json(None, 500)

    # delete the text field to optimise data usage
    d = parsed.to_json()
    del d["text"]

    # extract the morphologies for easier downstream parsing
    for idx, _ in enumerate(d["tokens"]):
        d["tokens"][idx]["morph"] = Morphology.feats_to_dict(d["tokens"][idx]["morph"])
    return json(d)


@app.get("/v1/nlp/features")
async def load_labels(request: Request) -> JSONResponse:
    """
    Determine the available features for the NLP Service
    Args:
        request: HTTP request object

    Returns: JSON HTTP response

    """
    entities = request.ctx.nlp.get_pipe("ner").labels
    ent_dict = {}
    for entity in entities:
        ent_dict[entity] = spacy.explain(entity)

    tags = request.ctx.nlp.get_pipe("tagger").labels
    pos_dict = {}
    for tag in tags:
        pos_dict[tag] = spacy.explain(tag)

    deps = request.ctx.nlp.get_pipe("parser").labels
    deps_dict = {}
    for dep in deps:
        deps_dict[dep] = spacy.explain(dep)
    return json({"entities": ent_dict,
                 "partsOfSpeech": pos_dict,
                 "dependencies": deps_dict})


if __name__ == '__main__':
    port = int(getenv("PORT", 8080))
    app.run("0.0.0.0", 8080, single_process=True)
