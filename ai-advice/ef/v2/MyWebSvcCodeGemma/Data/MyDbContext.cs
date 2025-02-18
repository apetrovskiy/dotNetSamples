using Microsoft.EntityFrameworkCore;

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
