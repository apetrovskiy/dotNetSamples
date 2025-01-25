#!/bin/sh

SOLUTION_NAME=SelfTestingSvc
MAIN_PRJ_NAME=SimpleService
TEST_PRJ_NAME=WiremockTestApp
MAIN_PRJ_FILE="${MAIN_PRJ_NAME}.csproj"
TEST_PRJ_FILE="${TEST_PRJ_NAME}.csproj"
MAIN_PRJ_PATH="${MAIN_PRJ_NAME}/${MAIN_PRJ_FILE}"
TEST_PRJ_PATH="${TEST_PRJ_NAME}/${TEST_PRJ_FILE}"

rm -rf "${MAIN_PRJ_NAME}"
rm -rf "${TEST_PRJ_NAME}"
rm "${SOLUTION_NAME}.sln"

# dotnet new uninstall TUnit.Templates
# dotnet new install Microsoft.DotNet.Web.ProjectTemplates.8.0::8.0.12 --force
# dotnet new install Microsoft.DotNet.Web.Spa.ProjectTemplates
# dotnet new install Microsoft.Quantum.ProjectTemplates
# dotnet new install Microsoft.DotNet.Common.ProjectTemplates.8.0
# dotnet new install TUnit.Templates

dotnet new sln -n "${SOLUTION_NAME}"
dotnet new webapi -n "${MAIN_PRJ_NAME}" -o "${MAIN_PRJ_NAME}"
dotnet sln add "${MAIN_PRJ_PATH}"
# dotnet new TUnit -n "${TEST_PRJ_NAME}" -o "${TEST_PRJ_NAME}"
dotnet new xunit -n "${TEST_PRJ_NAME}" -o "${TEST_PRJ_NAME}"
dotnet sln add "${TEST_PRJ_PATH}"
dotnet add "${TEST_PRJ_PATH}" reference "${MAIN_PRJ_PATH}"

dotnet add "${TEST_PRJ_PATH}" package WireMock.Net --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.StandAlone --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.Testcontainers --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.Aspire --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.AspNetCore.Middleware --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.FluentAssertions --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.xUnit --prerelease
# dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.TUnit --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.Matchers.CSharpCode --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.OpenApiParser --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Net.RestClient --prerelease
dotnet add "${TEST_PRJ_PATH}" package WireMock.Org.RestClient --prerelease
dotnet add "${TEST_PRJ_PATH}" package Microsoft.AspNetCore.Mvc
dotnet add "${TEST_PRJ_PATH}" package Newtonsoft.Json

dotnet build
dotnet run --project SimpleService/SimpleService.csproj
