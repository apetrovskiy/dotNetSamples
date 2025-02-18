#!/bin/sh

PROJECT_NAME=YiCoderSample

dotnet new webapi -n "${PROJECT_NAME}" -f net8.0
cd "${PROJECT_NAME}" || exit

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Swashbuckle.AspNetCore
