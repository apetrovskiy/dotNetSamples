/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 7:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Linq;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace testXmlToColl
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            XDocument xdoc = XDocument.Load(@"C:\Projects\NW\TestData\SPCR\Workflow.xml");
            var steps =
                from step in xdoc.Element("workflow").Elements("steps").Elements("step")
                where step.Element("active").Value == "0"
                select step;
            
            foreach (var step in steps) {
                Console.WriteLine(step.Value);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}