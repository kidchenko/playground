FROM httpd:2.4
EXPOSE 80
RUN apt-get update && apt-get install -y fortunes
COPY ./page.html /usr/local/apache2/htdocs/
LABEL maintener="moby-dock@example.com"