namespace EssentialTools.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    // 1
    // public class LinqValueCalculator
    // 2
    public class LinqValueCalculator : IValueCalculator
    {
        // 4
        // public decimal ValueProducts(IEnumerable<Product> products)
        // {
        //     return products.Sum(p => p.Price);
        // }

        // 5
        IDiscountHelper _discounter;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            _discounter = discountParam;
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}