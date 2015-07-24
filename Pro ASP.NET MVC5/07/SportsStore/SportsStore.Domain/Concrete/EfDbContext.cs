namespace SportsStore.Domain.Concrete
{
    using SportsStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
