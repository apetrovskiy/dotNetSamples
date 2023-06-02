using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DbSet<Operation> Operations { get; set; }
    public DataContext()
    {

    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
}