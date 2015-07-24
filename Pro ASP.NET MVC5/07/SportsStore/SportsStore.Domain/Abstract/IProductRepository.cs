namespace SportsStore.Domain.Abstract
{
    using SportsStore.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
