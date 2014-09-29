/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/21/2014
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testEasyDumpToXml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var list = new List<Class1>();
            list.Add(new Class1 { Id = 1, Name = "aaa" });
            list.Add(new Class1 { Id = 100, Name = "sadfr asf awsfd" });
            list.Add(new Class1 { Id = 1000000, Name = " safd sadf as " });
            var rootNode = new XElement("objects",
                                        from item in list
                                        select new XElement("object", new XAttribute("id", item.Id), new XAttribute("name", item.Name)));
            var xDoc = new XDocument(rootNode);
            xDoc.Save(@"e:\aaaabbbbcccc.xml");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}