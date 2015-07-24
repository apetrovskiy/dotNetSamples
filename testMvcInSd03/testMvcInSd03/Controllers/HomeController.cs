/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/24/2015
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Web.Mvc;

namespace testMvcInSd03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            return View();
        }
    }
}
