My workspace
View
context
Below is a complete implementation of an ASP.NET Core web service that meets your specifications, using .NET 8.0 and Entity Framework Core with SQLite as the database. The project includes the necessary entities, repositories, controllers, and CRUD operations, as well as the required migrations.

Step 1: Create the ASP.NET Core Web Service
Create a new ASP.NET Core project:

 copy
bash

dotnet new webapi -n MyWebService
cd MyWebService
Add Entity Framework Core and SQLite packages:

 copy
bash

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
Create the Data and Models:

Create a folder named Models and add the following entities:
Models/Employee.cs
 copy
csharp

using System.ComponentModel.DataAnnotations;

public class Employee
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }
}
Models/Role.cs
 copy
csharp

using System.ComponentModel.DataAnnotations;

public class Role
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Title { get; set; }
}
Models/Customer.cs
 copy
csharp

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
Models/Preference.cs
 copy
csharp

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Preference
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }

    public ICollection<CustomerPreference> CustomerPreferences { get; set; } = new List<CustomerPreference>();
}
Models/CustomerPreference.cs
 copy
csharp

public class CustomerPreference
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int PreferenceId { get; set; }
    public Preference Preference { get; set; }
}
Models/PromoCode.cs
 copy
csharp

using System.ComponentModel.DataAnnotations;

public class PromoCode
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Code { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
}
Step 2: Create the DbContext
Data/AppDbContext.cs
 copy
csharp

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }

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
Step 3: Create the Repository Interface and Implementation
Repositories/IRepository.cs
 copy
csharp

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
Repositories/CustomerRepository.cs
 copy
csharp

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : IRepository<Customer>
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
Step 4: Create the Controllers
Controllers/CustomersController.cs
 copy
csharp

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IRepository<Customer> _repository;

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
Controllers/PreferenceController.cs
 copy
csharp

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
Controllers/PromoCodesController.cs
 copy
csharp

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
Step 5: Program Configuration
Program.cs
 copy
csharp

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=mydatabase.db"));
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Create the database and tables
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
Step 6: Migrations
Run the following commands to create the migrations:

Add Initial Migration:

 copy
bash

dotnet ef migrations add InitialCreate
Update Database:

 copy
bash

dotnet ef database update
Add Migration for Field Change: Modify one of the fields in any entity, then run:

 copy
bash

dotnet ef migrations add UpdateField
Update Database Again:

 copy
bash

dotnet ef database update
Conclusion
This implementation covers the requested requirements, including the setup of entities, repositories, controllers, and migrations using Entity Framework Core with SQLite in an ASP.NET Core Web API. You can further enhance and customize the application as needed.

View
context
16:06
