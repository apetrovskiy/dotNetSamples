﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    // 05
    // public class DefaultDiscountHelper : IDiscountHelper
    // {
    //     public decimal ApplyDiscount(decimal totalParam)
    //     {
    //         return (totalParam - (10m / 100m * totalParam));
    //     }
    // }

    // 06
    //public class DefaultDiscountHelper : IDiscountHelper
    //{
    //    public decimal DiscountSize { get; set; }

    //    public decimal ApplyDiscount(decimal totalParam)
    //    {
    //        return (totalParam - (DiscountSize / 100m * totalParam));
    //    }
    //}

    // 07
    public class DefaultDiscountHelper : IDiscountHelper
    {
        decimal discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (discountSize / 100m * totalParam));
        }
    }
}