using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapTest04.Controllers
{
    public class TestController : Controller
    {
        /*
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        */

        [HttpGet]
        public ViewResult Test01()
        {
            return View("Test01");
        }

        [HttpGet]
        public ViewResult Test04_1()
        {
            return View("Test04_1");
        }

        [HttpGet]
        public ViewResult Test04_2()
        {
            return View("Test04_2");
        }

        [HttpGet]
        public ViewResult Test04_3()
        {
            return View("Test04_3");
        }

        [HttpGet]
        public ViewResult Test04_4()
        {
            return View("Test04_4");
        }

        [HttpGet]
        public ViewResult Test04_5()
        {
            return View("Test04_5");
        }
    }
}