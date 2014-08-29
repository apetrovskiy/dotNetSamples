/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 8/29/2014
 * Time: 12:39 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDeserialization
{
    using System;
	using System.Xml;
	using System.Xml.Linq;
    using Nancy;
    using Nancy.ModelBinding;
    
    /// <summary>
    /// Description of Module1.
    /// </summary>
    public class Module1 : NancyModule
    {
        public Module1() : base("/")
        {
            // Post["probe/"] = parameters => {
            Post["probe/"] = _ => {
                // var xDoc = this.Bind<XDocument>();
                // var xDoc = this.Bind<XmlDocument>();
                var xDoc = this.Bind();
                
                if (null != xDoc) {
                    Console.WriteLine(xDoc.GetType().Name);
                    Console.WriteLine(xDoc.Body);
                }
                
                if (null != xDoc)
                    return HttpStatusCode.Created;
                    // if (null != xDoc.Root)
                    // if (null != xDoc.FirstChild)
                    //     return HttpStatusCode.Created;
                return HttpStatusCode.ExpectationFailed;
            };
        }
    }
}
