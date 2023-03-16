# Builder stage:
FROM python:3 AS builder

# Install OS-level dependencies
RUN apt-get update \
 && DEBIAN_FRONTEND=noninteractive \
    apt-get install --no-install-recommends --assume-yes \
      build-essential

# Create the virtual environment
RUN python3 -m venv /venv
ENV PATH=/venv/bin:$PATH

# Install Python dependencies
WORKDIR /app
COPY requirements.txt .
RUN pip3 install -r requirements.txt

# If your setup.py/setup.cfg has a console script entry point,
# install the application too
RUN pip3 install $(spacy info 'en_core_web_trf' --url)

# Final stage:
# must be _exactly_ the same image as the builder
FROM python:3

# Install OS-level dependencies if needed (libmysqlclient, not ...-dev)
# RUN apt-get update && apt-get install ...

# Copy the virtual environment; must be _exactly_ the same path
COPY --from=builder /venv /venv
ENV PATH=/venv/bin:$PATH

# Copy in the application (if it wasn't `pip install`ed into the venv)
WORKDIR /app
COPY . .

# Say how to run it
EXPOSE 8080
CMD ["./main.py"]
