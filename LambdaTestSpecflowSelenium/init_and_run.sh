#!/bin/sh

FULL_RESTORE=0
# 0 - runs code operations without the Internet
# 1 - reloads packages

rm allure-results/* -y

SOLUTION_NAME=LambdaTestSpecflowSelenium
ROOT_FOLDER=src
MAIN_PRJ_NAME=LambdaTestSpecflowSelenium.Core
MAIN_PRJ_FOLDER="${ROOT_FOLDER}/${MAIN_PRJ_NAME}"
MAIN_PRJ_FILE="${MAIN_PRJ_FOLDER}/${MAIN_PRJ_NAME}.csproj"
MAIN_PRJ_TMP_FILE="${MAIN_PRJ_FOLDER}/main.tmp"
TEST_PRJ_NAME=LambdaTestSpecflowSelenium.Tests
TEST_PRJ_FOLDER="${ROOT_FOLDER}/${TEST_PRJ_NAME}"
TEST_PRJ_FILE="${TEST_PRJ_FOLDER}/${TEST_PRJ_NAME}.csproj"
TEST_PRJ_TMP_FILE="${TEST_PRJ_FOLDER}/test.tmp"
# the allure config item
ALLURE_CONFIG_FILE_NAME=allureConfig.json
ALLURE_CONFIG_FILE_PATH=${TEST_PRJ_FOLDER}/${ALLURE_CONFIG_FILE_NAME}
ALLURE_CONFIG_CONTENT="{\n  \"allure\": {\n    \"directory\": \"../../../../../allure-results\"\n  }\n}\n"
ALLURE_ITEM_GROUP="\n  <ItemGroup>\n    <Content Include=\"allureConfig.json\">\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n    </Content>\n  </ItemGroup>\n"
# stylecop # $(SolutionDir)
# STYLECOP_PROJECT_GROUP="  <PropertyGroup>\n    <CodeAnalysisRuleSet>$(pwd)/src/stylecop.json</CodeAnalysisRuleSet>\n  </PropertyGroup>\n"
STYLECOP_ITEM_GROUP="  <ItemGroup>\n    <AdditionalFiles Include=\"../stylecop.json\" />\n  </ItemGroup>\n"
PROJECT_TAG="</Project>"

rm -f "${TEST_PRJ_FILE}"
rm -f "${TEST_PRJ_FOLDER}/Class1.cs"
rm -f "${MAIN_PRJ_FILE}"
rm -f "${MAIN_PRJ_FOLDER}/Class1.cs"
rm -f "${SOLUTION_NAME}.sln"

dotnet new sln --name "${SOLUTION_NAME}"
dotnet new classlib --name "${MAIN_PRJ_NAME}" --framework net7.0 --output "${MAIN_PRJ_FOLDER}"
dotnet new classlib --name "${TEST_PRJ_NAME}" --framework net7.0 --output "${TEST_PRJ_FOLDER}"
dotnet sln add "${MAIN_PRJ_FILE}"
dotnet sln add "${TEST_PRJ_FILE}"
dotnet add "${TEST_PRJ_FILE}" reference "${MAIN_PRJ_FILE}"

rm -f "${TEST_PRJ_FOLDER}/Class1.cs"
rm -f "${MAIN_PRJ_FOLDER}/Class1.cs"

# formatting
dotnet add "${MAIN_PRJ_FOLDER}" package Stylecop.Analyzersv
dotnet add "${TEST_PRJ_FOLDER}" package Stylecop.Analyzers --prerelease

# testing
dotnet add "${TEST_PRJ_FOLDER}" package Microsoft.NET.Test.Sdk --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package coverlet.collector --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package NUnit --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package NUnit3TestAdapter --prerelease
# dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Allure
# dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Allure.Steps
#
dotnet add "${TEST_PRJ_FOLDER}" package Allure.Commons --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package NUnit.Analyzers --prerelease
#
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow --version 4.0.31-beta
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.Tools.MsBuild.Generation --version 4.0.31-beta

dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.NUnit --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.Plus.LivingDocPlugin --prerelease
# dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.Allure - legacy
#
# dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow
# dotnet add "${TEST_PRJ_FOLDER}" package Allure.SpecFlow --prerelease
# experimentally
# dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.NUnit.Runners
#
dotnet add "${TEST_PRJ_FOLDER}" package FluentAssertions --prerelease
# dotnet add "${TEST_PRJ_FOLDER}" package Shouldly

# REST
dotnet add "${MAIN_PRJ_FOLDER}" package System.Net.Http --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package RestSharp --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package DalSoft.RestClient --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Flurl.Http --prerelease

# web
dotnet add "${MAIN_PRJ_FOLDER}" package HtmlAgilityPack --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.Playwright --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Microsoft.Playwright.NUnit --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Selenium.WebDriver --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Selenium.WebDriver.ChromeDriver --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Selenium.Firefox.WebDriver --prerelease
dotnet add "${MAIN_PRJ_FOLDER}" package Selenium.Opera.WebDriver --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package HtmlAgilityPack --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Microsoft.Playwright --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Microsoft.Playwright.NUnit --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Selenium.WebDriver --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Selenium.WebDriver.ChromeDriver --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Selenium.Firefox.WebDriver --prerelease
dotnet add "${TEST_PRJ_FOLDER}" package Selenium.Opera.WebDriver --prerelease

##########
# dotnet add "${TEST_PRJ_FOLDER}" package Swashbuckle.AspNetCore

# json
dotnet add "${MAIN_PRJ_FOLDER}" package Newtonsoft.Json --prerelease
# dotnet add "${TEST_PRJ_FOLDER}" package SpecFlow.Plus.LivingDocPlugin
##########

echo "${ALLURE_CONFIG_CONTENT}" >"${ALLURE_CONFIG_FILE_PATH}"

echo "============================="
cat "${ALLURE_CONFIG_FILE_PATH}"
echo "============================="
echo "${ALLURE_ITEM_GROUP}"
echo "============================="
echo "${STYLECOP_ITEM_GROUP}"
echo "============================="
echo "${PROJECT_TAG}"

# main prj
sed '$d' "${MAIN_PRJ_FILE}"
tail -r "${MAIN_PRJ_FILE}" | tail -n +3 | tail -r >"${MAIN_PRJ_TMP_FILE}"
{
    echo "${STYLECOP_ITEM_GROUP}"
    echo "${PROJECT_TAG}"
} >>"${MAIN_PRJ_TMP_FILE}"
mv "${MAIN_PRJ_TMP_FILE}" "${MAIN_PRJ_FILE}"

# test prj
sed '$d' "${TEST_PRJ_FILE}"
tail -r "${TEST_PRJ_FILE}" | tail -n +3 | tail -r >"${TEST_PRJ_TMP_FILE}"
{
    echo "${ALLURE_ITEM_GROUP}"
    echo "${STYLECOP_ITEM_GROUP}"
    echo "${PROJECT_TAG}"
} >>"${TEST_PRJ_TMP_FILE}"
mv "${TEST_PRJ_TMP_FILE}" "${TEST_PRJ_FILE}"

if [ "${FULL_RESTORE}" = 1 ]; then
    echo "cleanin... ==========="
    dotnet clean
    dotnet restore
fi
# install from here: dotnet tool install dotnet-format --version "7.*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet7/nuget/v3/index.json
dotnet tool restore
dotnet format -v d
dotnet build --no-restore
dotnet test --no-build --verbosity normal
