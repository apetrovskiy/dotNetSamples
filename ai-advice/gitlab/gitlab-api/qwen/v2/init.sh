#!/bin/sh

SOLUTION_NAME=GitlabProjectCreator
ROOT_FOLDER=.
MAIN_PRJ_NAME="${SOLUTION_NAME}"
MAIN_PRJ_FOLDER="${ROOT_FOLDER}/${MAIN_PRJ_NAME}"
MAIN_PRJ_FILE="${MAIN_PRJ_FOLDER}/${MAIN_PRJ_NAME}.csproj"
TEST_PRJ_NAME="${SOLUTION_NAME}.Tests"
TEST_PRJ_FOLDER="${ROOT_FOLDER}/${TEST_PRJ_NAME}"
TEST_PRJ_FILE="${TEST_PRJ_FOLDER}/${TEST_PRJ_NAME}.csproj"

dotnet new sln --name "${SOLUTION_NAME}"
dotnet new console --name "${MAIN_PRJ_NAME}" --framework net8.0 --output "${MAIN_PRJ_FOLDER}"
dotnet new xunit --name "${TEST_PRJ_NAME}" --framework net8.0 --output "${TEST_PRJ_FOLDER}"
dotnet sln add "${MAIN_PRJ_FILE}"
dotnet sln add "${TEST_PRJ_FILE}"
dotnet add "${TEST_PRJ_FILE}" reference "${MAIN_PRJ_FILE}"

dotnet add "${TEST_PRJ_FILE}" package TUnit
dotnet add "${MAIN_PRJ_FILE}" package Microsoft.Extensions.Logging
dotnet add "${MAIN_PRJ_FILE}" package Microsoft.Extensions.Configuration
dotnet add "${MAIN_PRJ_FILE}" package Newtonsoft.Json
dotnet add "${MAIN_PRJ_FILE}" package Microsoft.Extensions.Logging.Console
dotnet add "${MAIN_PRJ_FILE}" package Microsoft.Extensions.Configuration.Json
