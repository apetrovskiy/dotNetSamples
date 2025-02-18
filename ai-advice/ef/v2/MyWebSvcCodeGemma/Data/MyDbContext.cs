using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Preference> Preferences { get; set; }
    public DbSet<CustomerPreference> CustomerPreferences { get; set; }
    public DbSet<PromoCode> PromoCodes { get; set; }

    public MyDbContext(DbContextOptions options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Customer>()
        .HasOne(c=>c.PromoCode);
        modelBuilder.Entity<PromoCode>()
        .HasOne(pc=>pc.Customer);
    } 

    protected override void OnConfiguring(DbContextOptionsBuilder 
optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
    /*
Unhandled exception. System.InvalidOperationException: The dependent side could not be determined 
for the one-to-one relationship between 'Customer.PromoCode' and 'PromoCode.Customer'. 
To identify the dependent side of the relationship, configure the foreign key property. 
If these navigations should not be part of the same relationship, 
configure them independently via separate method chains in 'OnModelCreating'. 
See https://go.microsoft.com/fwlink/?LinkId=724062 for more details.
    */
}
