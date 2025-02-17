#!/bin/sh

PROJECT_NAME=MyWebService

dotnet new webapi -n "${PROJECT_NAME}" -f net8.0
cd "${PROJECT_NAME}" || exit

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef --version 8.0.0

mkdir -p Models

cat <<EOF >Models/Employee.cs
using System.ComponentModel.DataAnnotations;

public class Employee
{
public int Id { get; set; }

[MaxLength(100)]
public string Name { get; set; }

public int RoleId { get; set; }
public Role Role { get; set; }
}
EOF

cat <<EOF >Models/Role.cs
using System.ComponentModel.DataAnnotations;

public class Role
{
public int Id { get; set; }

[MaxLength(50)]
public string Title { get; set; }
}
EOF

cat <<EOF >Models/Customer.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Customer
{
public int Id { get; set; }

[MaxLength(100)]
public string Name { get; set; }

public int PreferenceId { get; set; }
public ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();
public PromoCode PromoCode { get; set; }
}
EOF

cat <<EOF >Models/Preference.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Preference
{
public int Id { get; set; }

[MaxLength(100)]
public string Description { get; set; }

public ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();
}
EOF

cat <<EOF >Models/CustomerPreference.cs
public class CustomerPreference
{
public int CustomerId { get; set; }
public Customer Customer { get; set; }

public int PreferenceId { get; set; }
public Preference Preference { get; set; }
}
EOF

cat <<EOF >Models/PromoCode.cs
using System.ComponentModel.DataAnnotations;

public class PromoCode
{
public int Id { get; set; }

[MaxLength(50)]
public string Code { get; set; }

public int CustomerId { get; set; }
public Customer Customer { get; set; }
}
EOF

mkdir -p Data
cat <<EOF >Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
public DbSet Employees { get; set; }
public DbSet Roles { get; set; }
public DbSet Customers { get; set; }
public DbSet Preferences { get; set; }
public DbSet PromoCodes { get; set; }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<CustomerPreference>()
        .HasKey(cp => new { cp.CustomerId, cp.PreferenceId });

    modelBuilder.Entity<CustomerPreference>()
        .HasOne(cp => cp.Customer)
        .WithMany(c => c.CustomerPreferences)
        .HasForeignKey(cp => cp.CustomerId);

    modelBuilder.Entity<CustomerPreference>()
        .HasOne(cp => cp.Preference)
        .WithMany(p => p.CustomerPreferences)
        .HasForeignKey(cp => cp.PreferenceId);
}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=mydatabase.db");
}
}
EOF

mkdir -p Repositories
touch Repositories/IRepository.cs
cat <<EOF >Repositories/IRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository
{
Task<IEnumerable> GetAllAsync();
Task GetByIdAsync(int id);
Task AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(int id);
}
EOF

touch Repositories/CustomerRepository.cs
cat <<EOF >Repositories/CustomerRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : IRepository
{
private readonly AppDbContext _context;

public CustomerRepository(AppDbContext context)
{
    _context = context;
}

public async Task<IEnumerable<Customer>> GetAllAsync()
{
    return await _context.Customers.Include(c => c.CustomerPreferences).ThenInclude(cp => cp.Preference).ToListAsync();
}

public async Task<Customer> GetByIdAsync(int id)
{
    return await _context.Customers.Include(c => c.CustomerPreferences).ThenInclude(cp => cp.Preference).FirstOrDefaultAsync(c => c.Id == id);
}

public async Task AddAsync(Customer customer)
{
    await _context.Customers.AddAsync(customer);
    await _context.SaveChangesAsync();
}

public async Task UpdateAsync(Customer customer)
{
    _context.Customers.Update(customer);
    await _context.SaveChangesAsync();
}

public async Task DeleteAsync(int id)
{
    var customer = await _context.Customers.FindAsync(id);
    if (customer != null)
    {
        // Delete associated PromoCode
        if (customer.PromoCode != null)
        {
            _context.PromoCodes.Remove(customer.PromoCode);
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
}
EOF

mkdir -p Controllers
touch Controllers/CustomersController.cs
cat <<EOF >Controllers/CustomersController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
private readonly IRepository _repository;

public CustomersController(IRepository<Customer> repository)
{
    _repository = repository;
}

/// <summary>
/// Gets all customers.
/// </summary>
[HttpGet]
public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
{
    return Ok(await _repository.GetAllAsync());
}

/// <summary>
/// Gets a customer by ID.
/// </summary>
[HttpGet("{id}")]
public async Task<ActionResult<Customer>> GetCustomer(int id)
{
    var customer = await _repository.GetByIdAsync(id);
    if (customer == null)
    {
        return NotFound();
    }
    return Ok(customer);
}

/// <summary>
/// Creates a new customer.
/// </summary>
[HttpPost]
public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
{
    await _repository.AddAsync(customer);
    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
}

/// <summary>
/// Updates a customer.
/// </summary>
[HttpPut("{id}")]
public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
{
    if (id != customer.Id)
    {
        return BadRequest();
    }
    await _repository.UpdateAsync(customer);
    return NoContent();
}

/// <summary>
/// Deletes a customer.
/// </summary>
[HttpDelete("{id}")]
public async Task<ActionResult> DeleteCustomer(int id)
{
    await _repository.DeleteAsync(id);
    return NoContent();
}
}
EOF

cat <<EOF >Controllers/PreferencesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PreferencesController : ControllerBase
{
private readonly AppDbContext _context;

public PreferencesController(AppDbContext context)
{
    _context = context;
}

/// <summary>
/// Gets all preferences.
/// </summary>
[HttpGet]
public async Task<ActionResult<IEnumerable<Preference>>> GetPreferences()
{
    return Ok(await _context.Preferences.ToListAsync());
}
}
EOF

cat <<EOF >Controllers/PromoCodesController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class PromoCodesController : ControllerBase
{
private readonly AppDbContext _context;

public PromoCodesController(AppDbContext context)
{
    _context = context;
}

/// <summary>
/// Gives a promo code to a customer.
/// </summary>
[HttpPost("give")]
public async Task<ActionResult<PromoCode>> GivePromoCodesToCustomersAsync(PromoCode promoCode)
{
    await _context.PromoCodes.AddAsync(promoCode);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GivePromoCodesToCustomersAsync), new { id = promoCode.Id }, promoCode);
}

/// <summary>
/// Gets promo codes from customers.
/// </summary>
[HttpGet("get")]
public async Task<ActionResult<IEnumerable<PromoCode>>> GetPromoCodesFromCustomersAsync()
{
    return Ok(await _context.PromoCodes.ToListAsync());
}
}
EOF

cat <<EOF >Program.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext(options =>
options.UseSqlite("Data Source=mydatabase.db"));
builder.Services.AddScoped<IRepository, CustomerRepository>();
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
EOF

dotnet ef migrations add InitialCreate
dotnet ef database update
# Add Migration for Field Change: Modify one of the fields in any entity,
dotnet ef migrations add UpdateField
