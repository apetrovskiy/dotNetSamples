#!/bin/sh

cd ContosoPizza || exit

dotnet build

dotnet ef migrations add ModelRevisions --context PizzaContext

dotnet ef database update --context PizzaContext

cd -
