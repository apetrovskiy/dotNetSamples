﻿namespace SportsStore.WebUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "",
                defaults: new { Controller = "Product", action = "List", category = (string)null, page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { Controller = "Product", action = "List", category = (string)null }
                );

            routes.MapRoute(
                name: null,
                url: "{category}",
                defaults: new { Controller = "Product", action = "List", page = 1 }
                );

            routes.MapRoute(
                name: null,
                url: "{category}/Page{page}",
                defaults: new { Controller = "Product", action = "List" },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
