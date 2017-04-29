using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTest04.Controllers
{
    public class HomeController : Controller
    {
        /*
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
    }
}