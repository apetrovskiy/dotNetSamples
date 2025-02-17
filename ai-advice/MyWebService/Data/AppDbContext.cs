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
