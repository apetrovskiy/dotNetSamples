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
	using System.IO;
    using System.Linq;
	using System.Text;
	using System.Xml;
	using System.Xml.Linq;
    using Nancy;
    using Nancy.ModelBinding;
	using testInterfaces;
    
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
                try {
                    // string stringData = string.Empty;
Console.WriteLine("000000000000000000000000001");
                    // this.BindTo(stringData);
                    // try { stringData = this.BindAndValidate<string>(); } catch (Exception eeee) { Console.WriteLine(eeee.Message); }
                    // var objectData = this.Context.Items["data"];
                    // var stringData = objectData.ToString();
                    // var stringData = this.Context.Items["data"];
                    // var stringData = this.;
                    
                    // var data = this.Bind<Class1>();
                    // var stringData = data.Data;
                    
                    // var data = this.Request.Body.Length.;
                    // var fileValue = Request.Files.Single().Value;
                    // var fileValue = Request.Files.First().Value;
                    var actualBytes = new byte[Request.Body.Length];
                    Request.Body.Read(actualBytes, 0, (int)Request.Body.Length);
        
                    // var actual = Encoding.ASCII.GetString(actualBytes);
                    var actual = Encoding.UTF8.GetString(actualBytes);
                    
                    // var data = this.Bind<XElement>();
                    // Console.WriteLine(data.FirstNode);
                    // Console.WriteLine(data);
                    
                    // stringData = this.Text;
//Console.WriteLine(stringData);
//var writer = new StreamWriter(@"e:\20140828\tttttt.xml");
//writer.Write(stringData);
//writer.Flush();
//writer.Close();
Console.WriteLine("000000000000000000000000002");
Console.WriteLine("===========================================================================================================");
                    // var s = this.Bind<object>();
                    // var s = this.Bind<string[]>();
                    // var s = this.Bind<char[]>();
                    // var xDoc = XDocument.Parse(stringData, LoadOptions.PreserveWhitespace);
Console.WriteLine("000000000000000000000000003");
// Console.WriteLine(stringData);
                    // var xDoc = XDocument.Parse(s.ToString());
                    // var xDoc = XDocument.Parse(s.Aggregate((s1, s2) => s1 + s2));
                    var xDoc = XDocument.Parse(actual);
var writer = new StreamWriter(@"e:\20140828\tttttt.xml");
writer.Write(xDoc.Root);
writer.Flush();
writer.Close();
//                    Console.WriteLine(xDoc.FirstNode);
Console.WriteLine("000000000000000000000000004");
                    return HttpStatusCode.OK;
                }
                catch (Exception eeeeeee) {
                    Console.WriteLine("000000000000000000000000005");
                    Console.WriteLine(eeeeeee.Message);
                    Console.WriteLine("000000000000000000000000006");
                    return HttpStatusCode.ExpectationFailed;
                }
                // return true;
                // return HttpStatusCode.Created;
                // return this.Response.AsText(
                // return HttpStatusCode.OK;
            };
        }
    }
}
