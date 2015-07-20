namespace EssentialTools.Controllers
{
    using EssentialTools.Models;
    using Ninject;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    // 1
    // public class HomeController
    // 2
    public class HomeController : Controller
    {
        Product[] products = {
                                 new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
                                 new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
                                 new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
                                 new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
                             };
        // 4
        IValueCalculator calc;

        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        public ActionResult Index()
        {
            // 1
            // var calc = new LinqValueCalculator();
            // 2
            // IValueCalculator calc = new LinqValueCalculator();
            // 3
            // var kernel = new StandardKernel();
            // kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            // var calc = kernel.Get<IValueCalculator>();
            // 4

            var cart = new ShoppingCart(calc) { Products = products };
            var totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}