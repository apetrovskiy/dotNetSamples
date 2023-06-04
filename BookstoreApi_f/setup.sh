#!/cin/sh

dotnet new webapi --language "F#"

dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add package Swashbuckle.AspNetCore

dotnet tool install fantomas