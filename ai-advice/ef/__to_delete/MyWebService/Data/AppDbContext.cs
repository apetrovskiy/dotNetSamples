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
