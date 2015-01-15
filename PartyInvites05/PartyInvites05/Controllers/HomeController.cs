using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites05.Models;

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
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            // return View("Thanks", guestResponse);
            if (ModelState.IsValid)
                return View("Thanks", guestResponse);
            else
                return View();
        }
    }
}