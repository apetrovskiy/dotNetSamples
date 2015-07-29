/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/24/2015
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace testMvcInSd03
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                });
        }
        
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
