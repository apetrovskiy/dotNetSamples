#!/bin/sh

cd GitLabProjectCreator || exit
dotnet format -v d
dotnet run
cd ..
