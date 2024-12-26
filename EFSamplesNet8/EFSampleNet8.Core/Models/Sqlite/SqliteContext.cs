// <copyright file="SqliteContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EFSampleNet8.Core.Models.Sqlite;

using Dapper;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

public class SqliteContext : DbContext
{
    /*
    public SqliteContext(DbContextOptions<SqliteContext> options)
        : base(options)
    {
    }
    */

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = new SqliteConnection("Data Source=usersdb.db");
        optionsBuilder.UseSqlite(connection: conn); // (databaseName: "IDGSampleDb");
        conn.Execute(@";
        drop table if exists Ingredient;
        create table if not exists Ingredient
        (
        IngredientId integer identity primary key null,
        RecipeId integer null,
        name varchar(50) null,
        Quantity decimal null,
        Unit varchar(10) null
        );
        drop table if exists Recipes;
        create table if not exists Recipes
        (
        recipe_id integer identity primary key null, 
        name varchar(50) null,
        TimeToCook date null,
        IsDeleted varchar(5) null,
        Method varchar(50) null,
        Ingredients integer null
/*
    public int IngredientId { get; set; }

    public int RecipeId { get; set; }

    public required string Name { get; set; }

    public decimal Quantity { get; set; }

    public required string Unit { get; set; }

            public int RecipeId { get; set; }
    public required string Name { get; set; }
    public TimeSpan TimeToCook { get; set; 
    public bool IsDeleted { get; set; }
    public required string Method { get; set; }
    public required ICollection<Ingredient> Ingredients { get; set; }
    */
        )");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Recipe> Recipes { get; set; }
}
