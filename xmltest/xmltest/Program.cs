/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 4/3/2013
 * Time: 12:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace xmltest
{
    using System;
    using System.Management.Automation;
    using HtmlAgilityPack;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            string html = "<html><body><td>1</td><td>2</td><td>3</td></body></html>";
            //var x = (System.Xml.XmlDocument.XmlElement)html;
            //var x = new System.Xml.XmlDocument(
            
            var x = (System.Xml.XmlElement)((object[])html.Split(new char[]{'\r','\n'}));
            
            //System.Management.Automation.CmdletInfo c;
            
            HtmlDocument doc =
                new HtmlDocument();
            doc.LoadHtml(html);
            //var x = new System.Xml.XmlDocument(doc);
            //doc.
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}