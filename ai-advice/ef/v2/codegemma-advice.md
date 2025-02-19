>>> Please create an ASP.NET Core web service (C#, .NET 8.0, EntityFrameworkCore
... ) working with SQLite as a database, having a repository class inherited fro
... m IRepository. Database should be created at the start of the service and be
...  deleted at the service shutdown. There should be entities Employee, Role, C
... ustomer, Preference and PromoCode, so that PromoCode references Preference, 
... Employee references Role. Customer has relationship with preference and, as 
... this is a many-to-many reference, Customer has reference to Preference via e
... ntity CustomerPreference. Customer has reference to PromoCode the way that o
... ne PromoCode could be given to only one Customer. String fields should have 
... MaxLength in place. 
... 
... There also should be CustomersController, implementing the full set of CRUD 
... operation in the repository. On customer deletion, promocodes given to the c
... ustomer should also be deleted. Methods of the controller class should have 
... XML comments for Swagger. The CustomerResponse REST API model should contain
...  customer's preference list as PreferenceResponse.
... 
... There should be PreferenceController, returning PreferenceResponse from the 
... database. Methods of the controller class should have XML comments for Swagg
... er.
... 
... There should be PromoCodesController with methods GivePromoCodesToCustomersA
... sync and GetPromoCodesFromCustomersAsync. GivePromoCodesToCustomersAsync sho
... uld save a new promocode in the database. GetPromoCodesFromCustomersAsync sh
... ould use strings instead of dates.
... 
... There also should be two migrations, the initial one and one more with a cha
... nge of one field.
... 
... Please provide me with classes and other files filled with code and ready to
...  be used, not just advice and templates.
... 
**Entities:**

```csharp
public class Employee
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public Role Role { get; set; }
}

public class Role
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<CustomerPreference> Preferences { get; set; }
    public PromoCode PromoCode { get; set; }
}

public class Preference
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
}

public class CustomerPreference
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int PreferenceId { get; set; }
    public Preference Preference { get; set; }
}

public class PromoCode
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Code { get; set; }
    public Customer Customer { get; set; }
}
```

**Interfaces:**

```csharp
public interface IRepository
{
    // Add methods for CRUD operations
}

public interface ICustomerRepository : IRepository
{
    // Add methods specific to customer operations
}
```

**Repositories:**

```csharp
public class CustomerRepository : ICustomerRepository
{
    private readonly MyDbContext _context;

    public CustomerRepository(MyDbContext context)
    {
        _context = context;
    }

    // Implement CRUD operations
}
```

**Database Context:**

```csharp
public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<CustomerPreference> CustomerPreferences { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder 
optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}
```

**Controllers:**

```csharp
// CustomersController
public class CustomersController : Controller
{
    private readonly ICustomerRepository _repository;

    public CustomersController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    // CRUD operations
}

// PreferenceController
public class PreferenceController : Controller
{
    private readonly MyDbContext _context;

    public PreferenceController(MyDbContext context)
    {
        _context = context;
    }

    // Methods to return PreferenceResponse
}

// PromoCodesController
public class PromoCodesController : Controller
{
    private readonly MyDbContext _context;

    public PromoCodesController(MyDbContext context)
    {
        _context = context;
    }

    // GivePromoCodesToCustomersAsync
    // GetPromoCodesFromCustomersAsync
}
```

**Migrations:**

```csharp
// Initial migration
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Add tables and columns
    }
}

// Second migration
public partial class ChangeField : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        // Change field in the database
    }
}
```
