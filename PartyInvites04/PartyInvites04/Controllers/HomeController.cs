
namespace PartyInvites04.Controllers
{
    using System;
    using System.Web.Mvc;
    
    /// <summary>
    /// Description of HomeController.
    /// </summary>
    public class HomeController : Controller
    {
        /*
        public string Index()
        {
            return "Hello World";
        }
        */

        // GET: Home
        public ActionResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }
    }
}