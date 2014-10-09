/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/29/2014
 * Time: 6:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NwxTestReporting.Modules
{
    using System;
    using System.IO;
    using System.Net;
    using Nancy;
    using Nancy.ModelBinding;
    using Tmx.Server;
    
    /// <summary>
    /// Description of NwxModule.
    /// </summary>
    public class NwxModule : NancyModule
    {
        const string _reportPath = @"\Nwx\report.htm";
        
        public NwxModule()
        {
            Get[@"Nwx/sources.htm"] = parameters => {
                
                var path = (new TmxServerRootPathProvider()).GetRootPath() + _reportPath;
Console.WriteLine("GET sources.htm - beginning");
                try {
                    if (File.Exists(path))
Console.WriteLine("GET sources.htm - deleting file");
                        File.Delete(path);
                    }
                catch (Exception e) {
Console.WriteLine(e.Message);
                }
                return View[@"Nwx/sources.htm"];
            };
            
            Get[@"Nwx/report.htm"] = _ => {
                var path = (new TmxServerRootPathProvider()).GetRootPath() + _reportPath;
Console.WriteLine("GET report.htm - beginning");
                do {
                    System.Threading.Thread.Sleep(100);
Console.WriteLine("GET report.htm - file does not exist");
                }
                while(!File.Exists(path));
Console.WriteLine("GET report.htm - file exists");
                return View[@"Nwx/report.htm"];
            };
        }
    }
}
