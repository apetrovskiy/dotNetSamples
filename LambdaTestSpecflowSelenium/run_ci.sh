#!/bin/sh

dotnet clean
dotnet restore
dotnet format --verify-no-changes -v d
dotnet build --no-restore

dotnet test
