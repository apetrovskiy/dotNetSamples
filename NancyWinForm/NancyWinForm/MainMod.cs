/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/6/2015
 * Time: 10:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyWinForm
{
    using System;
    using Nancy;
    
    /// <summary>
    /// Description of MainMod.
    /// </summary>
    public class MainMod : NancyModule
    {
        // public MainMod()
        public MainMod(PracticeConfigManager mgr)
        {
            // Get["/"] = x => "Wee hoo! - no more little green monster...";
            Get ["/"] = x => {
                // return View ["skirts"];
                return View["views/skirts.html"]; 
            };

            Post["/NiceNancy"] = y => {
                if (Request.Form["HowNice"].HasValue) {
                    if (Request.Form["HowNice"] == "1")
                        return View["views/nice.html"];
                    else if (Request.Form["HowNice"] == "2")
                        return View["views/very.html"];
                    else
                        return View["views/skirts.html"];
                }
                else {
                    return View["views/skirts.html"];
                }
            };

            Get ["/config"] = x => {
                // return mgr.config.DateFormat;
                return View["views/config.html", mgr.config];
            };
        }
    }
}
