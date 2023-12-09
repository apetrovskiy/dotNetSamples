#!/bin/sh

dotnet new sln --output RecordDemoApp
dotnet new console --output RecordDemo
dotnet sln add RecordDemo

dotnet run --project RecordDemo/RecordDemo.csproj
