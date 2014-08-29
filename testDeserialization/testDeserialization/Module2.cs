/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 8/29/2014
 * Time: 3:27 PM
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
    
    /// <summary>
    /// Description of Module2.
    /// </summary>
    public class Module2 : NancyModule
    {
        public Module2() : base("/probe2")
        {
            Post["/"] = parameters => {
                
                try {
                    // Console.WriteLine("============================= from parameters ======================================");
                    // string str = parameters.content;
                    // Console.WriteLine(str);
                    // Console.WriteLine("============================= from bindings ======================================");
                    // var fileContent = this.Bind();
//                    if (null == fileContent) {
//                        Console.WriteLine("null == fileContent");
//                    } else {
//                        Console.WriteLine("null != fileContent");
//                        Console.WriteLine(fileContent.GetType().Name);
//                    }
                    // Console.WriteLine("============================= from body ======================================");
                    // Console.WriteLine(this.Request);
                    if (null != this.Request.Files) {
                        // foreach (var element in this.Request.Files) {
                            // Console.WriteLine(element.Value);
                            // var file = element as HttpFile;
                            // var file = this.Request.Files[0] as HttpFile;
                            // Console.WriteLine(file.ContentType);
                            // Console.WriteLine(file.Key);
                            // Console.WriteLine(file.Name);
                            // Console.WriteLine(file.Value);
                            // var stream = file.Value as HttpMultipartSubStream;
                            
                            // var fileValue = Request.Files.Single().Value;
                            var fileValue = Request.Files.First().Value;
                            var actualBytes = new byte[fileValue.Length];
                            fileValue.Read(actualBytes, 0, (int)fileValue.Length);
                
                            // var actual = Encoding.ASCII.GetString(actualBytes);
                            var actual = Encoding.UTF8.GetString(actualBytes);
                            Console.WriteLine(actual);
                        // }
                        // var document = XDocument.Load(fileValue);
                        // var document = XDocument.Load(new XmlTextReader(fileValue));
                        // var document = XDocument.Parse(actual);
                        // var doc = new XmlValidatingReader(
                        // var elt = new XElement(actual);
                        // Console.WriteLine(elt);
                        // var document = new XDocument(actual);
                        // document.Add(actual);
                        // Console.WriteLine(document);
                    }
                    
//                    Console.WriteLine(this.Request.Body);
//                    Nancy.IO.RequestStream stream = this.Request.Body;
//                    Console.WriteLine(stream.Length);
//                    Console.WriteLine(stream.ToString());
                    // stream.Read(
                    // Console.WriteLine(this.Request.Files);
                    return HttpStatusCode.Created;
                }
                catch (Exception eeeee) {
                    Console.WriteLine(eeeee.Message);
                }
                return true;
            };
        }
    }
}
