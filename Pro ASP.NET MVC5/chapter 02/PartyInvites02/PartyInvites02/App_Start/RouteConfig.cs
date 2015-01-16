using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace PartyInvites02
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes ();
            routes.MapRoute (
                "MyRoute",
                "{controller}/{action}/{id}",
                new {
                    controller = "Home", action = "Index", id = UrlParameter.Optional
                });
        }
    }
}

