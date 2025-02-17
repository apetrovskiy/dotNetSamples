

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MyWebService.Controllers;
using MyWebService.Repositories;
using MyWebService.Models;
using MyWebService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext(options =>
options.UseSqlite("Data Source=mydatabase.db"));
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository<Customer>>();
builder.Services.AddControllers();

var app = builder.Build();

// Create the database and tables
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService();
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
