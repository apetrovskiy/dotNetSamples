#!/bin/sh

# dotnet tool install -g tunit.console

pwd
ls -la GitlabProjectCreator

cd GitlabProjectCreator || exit
dotnet format -v d
# dotnet run
cd ..

cd GitlabProjectCreator.Tests || exit
dotnet format -v d
# tunit.console bin\Debug\net8.0\GitlabProjectCreator.Tests.dll
dotnet test
