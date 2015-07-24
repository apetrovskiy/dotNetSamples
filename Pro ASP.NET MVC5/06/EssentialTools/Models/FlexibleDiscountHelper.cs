namespace EssentialTools.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            // 08
            var discount = totalParam > 100 ? 70 : 25;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}