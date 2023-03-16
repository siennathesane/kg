# Builder stage:
FROM python:3-slim AS builder

# Create the virtual environment
RUN python3 -m venv /venv
ENV PATH=/venv/bin:$PATH

RUN apt update && apt install -y build-essential

# Install Python dependencies
WORKDIR /app
COPY requirements.txt .
RUN pip3 install -r requirements.txt

# If your setup.py/setup.cfg has a console script entry point,
# install the application too
RUN python3 -m spacy download en_core_web_trf

# Final stage:
# must be _exactly_ the same image as the builder
FROM python:3-slim

# Copy the virtual environment; must be _exactly_ the same path
COPY --from=builder /venv /venv
ENV PATH=/venv/bin:$PATH

# Copy in the application (if it wasn't `pip install`ed into the venv)
WORKDIR /app
COPY . .

# Say how to run it
EXPOSE 8080
CMD ["./main.py"]
