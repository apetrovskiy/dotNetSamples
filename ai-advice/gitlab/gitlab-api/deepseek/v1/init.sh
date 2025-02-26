#!/bin/sh

dotnet new console -n GitLabProjectCreator
cd GitLabProjectCreator || exit
dotnet add package Newtonsoft.Json
dotnet add package dotenv.net
