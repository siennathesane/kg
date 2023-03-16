#!/usr/bin/env python3
import spacy
from sanic import Sanic
from sanic.response import JSONResponse, json
from sanic.request import Request
from sanic.worker.manager import WorkerManager
from spacy.tokens.doc import Doc
from warnings import simplefilter

simplefilter("ignore")
app = Sanic("arcanity")
WorkerManager.THRESHOLD = 1800


@app.before_server_start
async def nlp_loader(app_ctx, _):
    app_ctx.ctx.nlp = spacy.load("en_core_web_trf")


@app.on_request
async def load_model(request):
    request.ctx.nlp = app.ctx.nlp


@app.post("/v1/extract")
async def extract(request: Request) -> JSONResponse:
    # noinspection PyUnusedLocal
    parsed: Doc = None
    body = request.json
    try:
        parsed = request.ctx.nlp(body["content"])
    except Exception as e:
        print(e)
        return json(None, 500)

    # delete the text field to optimise data usage
    d = parsed.to_json()
    del d["text"]
    return json(d)


if __name__ == '__main__':
    app.run("0.0.0.0", 8080, single_process=True)
