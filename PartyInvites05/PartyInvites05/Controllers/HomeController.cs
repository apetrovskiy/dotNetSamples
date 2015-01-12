using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyInvites05.Controllers
{
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