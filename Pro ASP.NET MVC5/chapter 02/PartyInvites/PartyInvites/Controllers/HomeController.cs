using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        /*
        public string Index() {
            return "Hello World";
        }
        */
        public ActionResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Evening";
            return View ();
        }
    }
}

