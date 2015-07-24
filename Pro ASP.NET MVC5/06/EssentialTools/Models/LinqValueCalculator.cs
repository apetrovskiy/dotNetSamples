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
        // 04
        // public decimal ValueProducts(IEnumerable<Product> products)
        // {
        //     return products.Sum(p => p.Price);
        // }

        // 05
        //IDiscountHelper _discounter;
        //public LinqValueCalculator(IDiscountHelper discountParam)
        //{
        //    _discounter = discountParam;
        //}
        // 09
        IDiscountHelper _discounter;
        static int counter = 0;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            _discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
        }

        // 05
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return _discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}