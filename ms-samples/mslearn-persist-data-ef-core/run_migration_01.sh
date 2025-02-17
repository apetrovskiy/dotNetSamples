#!/bin/sh

cd ContosoPizza || exit

dotnet ef migrations add InitialCreate --context PizzaContext

dotnet ef database update --context PizzaContext

cd -
