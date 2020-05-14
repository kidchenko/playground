FROM ubuntu:18.04 as SDKMAN

RUN rm /bin/sh && ln /bin/bash /bin/sh
RUN apt-get update
RUN apt-get install -q -y curl zip unzip
RUN curl -s "https://get.sdkman.io" | bash
RUN chmod a+x "$HOME/.sdkman/bin/sdkman-init.sh"
RUN source "$HOME/.sdkman/bin/sdkman-init.sh" && sdk install kotlin && sdk install java

FROM SDKMAN AS BUILD

RUN source "$HOME/.bashrc"
COPY . /usr/src/hello-world
WORKDIR /usr/src/hello-world
