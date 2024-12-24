#!/bin/sh

SOLUTION_NAME=EFSampleNet8
MAIN_PRJ_NAME="${SOLUTION_NAME}.Core"
TEST_PRJ_NAME="${SOLUTION_NAME}.Tests"
MAIN_PRJ_FOLDER="${MAIN_PRJ_NAME}"
TEST_PRJ_FOLDER="${TEST_PRJ_NAME}"
MAIN_PRJ_FILE="${MAIN_PRJ_NAME}/${MAIN_PRJ_NAME}.csproj"
TEST_PRJ_FILE="${TEST_PRJ_NAME}/${TEST_PRJ_NAME}.csproj"

# dotnet new web -f net8.0 -n "${PROJECT_NAME}"

dotnet new sln --name "${SOLUTION_NAME}" --force
dotnet new classlib --name "${MAIN_PRJ_NAME}" --framework net8.0 --output "${MAIN_PRJ_FOLDER}" --force
dotnet new classlib --name "${TEST_PRJ_NAME}" --framework net8.0 --output "${TEST_PRJ_FOLDER}" --force
dotnet sln add "${MAIN_PRJ_FILE}"
dotnet sln add "${TEST_PRJ_FILE}"
dotnet add "${TEST_PRJ_FILE}" reference "${MAIN_PRJ_FILE}"

rm -f "${TEST_PRJ_FOLDER}/Class1.cs"
rm -f "${MAIN_PRJ_FOLDER}/Class1.cs"

dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.Design
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.Tools
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.Relational
dotnet add "${MAIN_PRJ_FOLDER}" package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.SqlServer
dotnet add "${MAIN_PRJ_FOLDER}" package MySql.Data.EntityFrameworkCore
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.SQLite
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.EntityFrameworkCore.InMemory
dotnet add "${MAIN_PRJ_FOLDER}" package Pomelo.EntityFrameworkCore.MySql
dotnet add "${MAIN_PRJ_FOLDER}" package MongoDB.EntityFrameworkCore

# formatting
dotnet add "${MAIN_PRJ_FOLDER}" package Stylecop.Analyzers --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Stylecop.Analyzers --prerelease

# logging
dotnet add "${MAIN_PRJ_FOLDER}" package NLog --prerelease

# testing
dotnet add "${TEST_PRJ_FOLDER}" package Microsoft.NET.Test.Sdk --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package coverlet.collector --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package NUnit --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package NUnit3TestAdapter --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package xunit --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package xunit.assert --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package xunit.analyzers --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package xunit.core --prerelease
