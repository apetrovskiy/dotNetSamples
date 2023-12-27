#!/bin/sh

dotnet new sln -n Otus.Serializer
dotnet new classlib -n Otus.Serializer -o Otus.Serializer
otnet sln add Otus.Serializer
