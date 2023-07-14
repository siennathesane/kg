# Set the name of the bazel workspace.
workspace(name = "veridian")

load("//:variables.bzl", "BUF_VERSION", "GOLANG_VERSION", "PYTHON_VERSION")

########################
# SYSTEM DEPENDENCIES
########################

load("@bazel_tools//tools/build_defs/repo:http.bzl", "http_archive")
load("@bazel_tools//tools/build_defs/repo:git.bzl", "git_repository")

# note that ruby is being imported twice because of naming issues

git_repository(
    name = "bazelruby_rules_ruby",
    commit = "cc2f5ce961f7fa34557264dd05c7597e634f31e1",
    remote = "https://github.com/bazelruby/rules_ruby.git",
)

git_repository(
    name = "rules_ruby",
    commit = "cc2f5ce961f7fa34557264dd05c7597e634f31e1",
    remote = "https://github.com/bazelruby/rules_ruby.git",
)

git_repository(
    name = "upb",
    commit = "8c71bc4593d97d39dd16c6e99ad7c32c8518f9bf",
    remote = "https://github.com/protocolbuffers/upb.git",
)

git_repository(
    name = "utf8_range",
    commit = "d863bc33e15cba6d873c878dcca9e6fe52b2f8cb",
    remote = "https://github.com/protocolbuffers/utf8_range.git",
)

http_archive(
    name = "com_github_google_benchmark",
    sha256 = "2a778d821997df7d8646c9c59b8edb9a573a6e04c534c01892a40aa524a7b68c",
    strip_prefix = "benchmark-bf585a2789e30585b4e3ce6baf11ef2750b54677",
    urls = ["https://github.com/google/benchmark/archive/bf585a2789e30585b4e3ce6baf11ef2750b54677.zip"],
)

http_archive(
    name = "com_google_absl",
    strip_prefix = "abseil-cpp-20230125.3",
    urls = ["https://github.com/abseil/abseil-cpp/archive/refs/tags/20230125.3.zip"],
)

http_archive(
    name = "com_google_googletest",
    strip_prefix = "googletest-011959aafddcd30611003de96cfd8d7a7685c700",
    urls = ["https://github.com/google/googletest/archive/011959aafddcd30611003de96cfd8d7a7685c700.zip"],
)

http_archive(
    name = "com_google_protobuf",
    sha256 = "a700a49470d301f1190a487a923b5095bf60f08f4ae4cac9f5f7c36883d17971",
    strip_prefix = "protobuf-23.4",
    urls = [
        "https://github.com/protocolbuffers/protobuf/archive/v23.4.tar.gz",
    ],
)

http_archive(
    name = "bazel_gazelle",
    sha256 = "29218f8e0cebe583643cbf93cae6f971be8a2484cdcfa1e45057658df8d54002",
    urls = [
        "https://github.com/bazelbuild/bazel-gazelle/releases/download/v0.32.0/bazel-gazelle-v0.32.0.tar.gz",
    ],
)

http_archive(
    name = "bazel_skylib",
    sha256 = "66ffd9315665bfaafc96b52278f57c7e2dd09f5ede279ea6d39b2be471e7e3aa",
    urls = [
        "https://mirror.bazel.build/github.com/bazelbuild/bazel-skylib/releases/download/1.4.2/bazel-skylib-1.4.2.tar.gz",
        "https://github.com/bazelbuild/bazel-skylib/releases/download/1.4.2/bazel-skylib-1.4.2.tar.gz",
    ],
)

http_archive(
    name = "bazel_skylib_gazelle_plugin",
    sha256 = "3327005dbc9e49cc39602fb46572525984f7119a9c6ffe5ed69fbe23db7c1560",
    urls = [
        "https://mirror.bazel.build/github.com/bazelbuild/bazel-skylib/releases/download/1.4.2/bazel-skylib-gazelle-plugin-1.4.2.tar.gz",
        "https://github.com/bazelbuild/bazel-skylib/releases/download/1.4.2/bazel-skylib-gazelle-plugin-1.4.2.tar.gz",
    ],
)

http_archive(
    name = "googleapis",
    sha256 = "9d1a930e767c93c825398b8f8692eca3fe353b9aaadedfbcf1fca2282c85df88",
    strip_prefix = "googleapis-64926d52febbf298cb82a8f472ade4a3969ba922",
    urls = [
        "https://github.com/googleapis/googleapis/archive/64926d52febbf298cb82a8f472ade4a3969ba922.zip",
    ],
)

http_archive(
    name = "io_bazel_rules_go",
    sha256 = "6dc2da7ab4cf5d7bfc7c949776b1b7c733f05e56edc4bcd9022bb249d2e2a996",
    urls = [
        "https://mirror.bazel.build/github.com/bazelbuild/rules_go/releases/download/v0.39.1/rules_go-v0.39.1.zip",
        "https://github.com/bazelbuild/rules_go/releases/download/v0.39.1/rules_go-v0.39.1.zip",
    ],
)

http_archive(
    name = "rules_pkg",
    sha256 = "8f9ee2dc10c1ae514ee599a8b42ed99fa262b757058f65ad3c384289ff70c4b8",
    urls = [
        "https://mirror.bazel.build/github.com/bazelbuild/rules_pkg/releases/download/0.9.1/rules_pkg-0.9.1.tar.gz",
        "https://github.com/bazelbuild/rules_pkg/releases/download/0.9.1/rules_pkg-0.9.1.tar.gz",
    ],
)

http_archive(
    name = "rules_python",
    sha256 = "0a8003b044294d7840ac7d9d73eef05d6ceb682d7516781a4ec62eeb34702578",
    strip_prefix = "rules_python-0.24.0",
    url = "https://github.com/bazelbuild/rules_python/releases/download/0.24.0/rules_python-0.24.0.tar.gz",
)

http_archive(
    name = "rules_python_gazelle_plugin",
    sha256 = "0a8003b044294d7840ac7d9d73eef05d6ceb682d7516781a4ec62eeb34702578",
    strip_prefix = "rules_python-0.24.0/gazelle",
    url = "https://github.com/bazelbuild/rules_python/releases/download/0.24.0/rules_python-0.24.0.tar.gz",
)

http_archive(
    name = "rules_buf",
    sha256 = "523a4e06f0746661e092d083757263a249fedca535bd6dd819a8c50de074731a",
    strip_prefix = "rules_buf-0.1.1",
    urls = [
        "https://github.com/bufbuild/rules_buf/archive/refs/tags/v0.1.1.zip",
    ],
)

http_archive(
    name = "rules_proto",
    sha256 = "dc3fb206a2cb3441b485eb1e423165b231235a1ea9b031b4433cf7bc1fa460dd",
    strip_prefix = "rules_proto-5.3.0-21.7",
    urls = [
        "https://github.com/bazelbuild/rules_proto/archive/refs/tags/5.3.0-21.7.tar.gz",
    ],
)

# Load rulesets and some necessary functions
load("@bazel_gazelle//:deps.bzl", "gazelle_dependencies")
load("@bazel_skylib_gazelle_plugin//:setup.bzl", "bazel_skylib_gazelle_plugin_setup")
load("@bazel_skylib_gazelle_plugin//:workspace.bzl", "bazel_skylib_gazelle_plugin_workspace")
load("@bazel_skylib//:workspace.bzl", "bazel_skylib_workspace")
load("@bazelruby_rules_ruby//ruby:deps.bzl", "rules_ruby_dependencies")
load("@googleapis//:repository_rules.bzl", "switched_rules_by_language")
load("@io_bazel_rules_go//go:deps.bzl", "go_download_sdk", "go_rules_dependencies")
load("@rules_pkg//:deps.bzl", "rules_pkg_dependencies")
load("@rules_proto//proto:repositories.bzl", "rules_proto_dependencies", "rules_proto_toolchains")
load("@rules_python_gazelle_plugin//:deps.bzl", _py_gazelle_deps = "gazelle_deps")
load("@rules_python//python:repositories.bzl", "py_repositories", "python_register_toolchains")

bazel_skylib_workspace()

bazel_skylib_gazelle_plugin_workspace()

bazel_skylib_gazelle_plugin_setup()

switched_rules_by_language(
    name = "com_google_googleapis_imports",
)

go_download_sdk(
    name = "go_sdk",
    version = GOLANG_VERSION,
)

go_rules_dependencies()

rules_ruby_dependencies()

py_repositories()

python_register_toolchains(
    name = "python",
    python_version = PYTHON_VERSION,
)

load("@python//:defs.bzl", "interpreter")
load("@rules_python//python:pip.bzl", "pip_parse")

pip_parse(
    name = "pip",
    python_interpreter_target = interpreter,
    requirements = "//src/arcanity:requirements_lock.txt",
)

load("@pip//:requirements.bzl", "install_deps")

install_deps()

_py_gazelle_deps()

rules_proto_dependencies()

rules_proto_toolchains()

rules_pkg_dependencies()

gazelle_dependencies(go_repository_default_config = "//:WORKSPACE.bazel")
