/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/1/2014
 * Time: 3:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDeserialization
{
    using System;
	using System.Xml.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of Module3.
    /// </summary>
    public class Module3 : NancyModule
    {
        // public Module3() : base("/probe3")
        public Module3() : base("/")
        {
            // Post["/"] = _ => {
            Post["probe3/"] = _ => {
//                Console.WriteLine("======================Body=========================");
//                Console.WriteLine(Request.Body);
//                
//                Console.WriteLine("======================Files=========================");
//                foreach (var file in Request.Files) {
//                    Console.WriteLine(file);
//                }
//                
//                Console.WriteLine("======================Form=========================");
//                Console.WriteLine(Request.Form);
//                
//                Console.WriteLine("======================Headers=========================");
//                foreach (var header in Request.Headers) {
//                    Console.WriteLine(header);
//                }
//                
//                Console.WriteLine("======================Path=========================");
//                Console.WriteLine(Request.Path);
//                
//                Console.WriteLine("======================Query=========================");
//                Console.WriteLine(Request.Query);
//                
//                Console.WriteLine("======================Url=========================");
//                Console.WriteLine(Request.Url);
//                
//                Console.WriteLine("======================UserHostAddress=========================");
//                Console.WriteLine(Request.UserHostAddress);
                
                var s = this.Bind<string>();
                var xDoc = XDocument.Parse(s);
                Console.WriteLine(xDoc.Root);
                
                // return true;
                return HttpStatusCode.Created;
            };
        }
    }
}
