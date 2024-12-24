// <copyright file="SqliteContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EFSampleNet8.Core.Models.Sqlite;

using Microsoft.EntityFrameworkCore;

public class SqliteContext : DbContext
{
    public SqliteContext(DbContextOptions<SqliteContext> options)
        : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
}
