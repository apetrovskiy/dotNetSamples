#!/bin/sh
# https://learn.microsoft.com/en-us/training/modules/persist-data-ef-core/3-migrations

git clone https://github.com/MicrosoftDocs/mslearn-persist-data-ef-core

sleep 20
cd mslearn-persist-data-ef-core || exit
# code . &

# dotnet build ContosoPizza/ContosoPizza.csproj 
dotnet add ContosoPizza/ContosoPizza.csproj package Microsoft.EntityFrameworkCore.Sqlite

dotnet add ContosoPizza/ContosoPizza.csproj package Microsoft.EntityFrameworkCore.Design

dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --channel classic
# dotnet tool update --global dotnet-ef

mkdir Data
cat << EOF > Data/PizzaContext.cs
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Models;

namespace ContosoPizza.Data;

public class PizzaContext : DbContext
{
    public PizzaContext (DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<Topping> Toppings => Set<Topping>();
    public DbSet<Sauce> Sauces => Set<Sauce>();
}
EOF


