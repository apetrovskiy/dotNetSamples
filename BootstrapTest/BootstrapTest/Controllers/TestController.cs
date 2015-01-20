using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTest.Controllers
{
    public class TestController : Controller
    {
        /*
        public ActionResult Index()
        {
            return View ();
        }
        */
        // [HttpGet]
        public ViewResult Test01()
        {
            return View ("Test01");
        }
    }
}
