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
**Entities:**

```C#
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
    public List<Preference> Preferences { get; set; }
    public PromoCode PromoCode { get; set; }
}

public class Preference
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public List<Customer> Customers { get; set; }
}

public class PromoCode
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Code { get; set; }
    public Customer Customer { get; set; }
}
```

**Repository Interface:**

```C#
public interface IRepository : IDisposable
{
    // CRUD operations for Employee, Role, Customer, Preference, PromoCode
}
```

**Repository Class:**

```C#
public class SQLiteRepository : IRepository
{
    // DbContext instance
}
```

**CustomersController:**

```C#
[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IRepository _repository;

    // Constructor
}

// CRUD operations
}
```

**PreferenceController:**

```C#
[Route("api/[controller]")]
[ApiController]
public class PreferenceController : ControllerBase
{
    private readonly IRepository _repository;

    // Constructor
}
```

**PromoCodesController:**

```C#
[Route("api/[controller]")]
[ApiController]
public class PromoCodesController : ControllerBase
{
    private readonly IRepository _repository;

    // Constructor
}
```

**Migrations:**

```C#
// Initial migration
public partial class InitialCreate : Migration
{
    // Migration code
}

// Second migration
public partial class UpdatePromoCodeField : Migration
{
    // Migration code
}
```
