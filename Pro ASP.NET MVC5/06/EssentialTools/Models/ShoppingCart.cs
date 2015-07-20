namespace EssentialTools.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ShoppingCart
    {
        // 1
        // LinqValueCalculator _calc;
        // 2
        IValueCalculator _calc;

        // 1
        // public ShoppingCart(LinqValueCalculator calcParam)
        // 2
        public ShoppingCart(IValueCalculator calcParam)
        {
            _calc = calcParam;
        }

        public IEnumerable<Product> Products { get; set; }

        public decimal CalculateProductTotal()
        {
            return _calc.ValueProducts(Products);
        }
    }
}