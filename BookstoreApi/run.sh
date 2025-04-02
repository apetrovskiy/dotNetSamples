#!/bin/sh

docker build -t bookstore-api .

docker run -p 8080:80 bookstore-api
