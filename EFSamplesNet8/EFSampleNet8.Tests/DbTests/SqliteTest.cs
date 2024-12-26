// <copyright file="SqliteTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EFSampleNet8.Tests.DbTests;

using EFSampleNet8.Core.Models.Sqlite;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

public class SqliteTest
{
    private WebApplicationBuilder builder;
    private SqliteContext context;

    [SetUp]
    public void Setup()
    {
        this.builder = WebApplication.CreateBuilder([]);

        // TODO: to config
        var connString = "Data Source=usersdata.db";
        this.builder.Services.AddDbContextFactory<SqliteContext>(options => options.UseSqlite(connString));

        var app = this.builder.Build();

        this.context = new SqliteContext();
    }

    [Test]
    public void NewRecipeTest()
    {
        var recipesCount = this.context.Recipes.Count();
        Recipe recipe = new Recipe { Name = $"My french recipe {DateTime.Now}", Method = "GET", Ingredients = new[] { new Ingredient { Name = "Salt", Unit = "g" } } };
        this.context.Recipes.Add(recipe);
        this.context.SaveChanges();
        Assert.That(this.context.Recipes.Count(), Is.GreaterThan(recipesCount));
    }

    [Test]
    public void ThereAreRecipesTest()
    {
        Assert.That(this.context.Recipes.Count(), Is.GreaterThan(5));
    }
}
