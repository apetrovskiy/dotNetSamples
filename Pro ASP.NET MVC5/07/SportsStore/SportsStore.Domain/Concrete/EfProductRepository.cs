namespace SportsStore.Domain.Concrete
{
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EfProductRepository : IProductRepository
    {
        EfDbContext context = new EfDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}
