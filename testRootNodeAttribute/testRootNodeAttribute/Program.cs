/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 17/02/2015
 * Time: 07:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRootNodeAttribute
{
    using System;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var path = @"E:\20150217\8.1x86\TestResult\1111.xml";
            
            var xDoc = XDocument.Load(path);
            
            Console.WriteLine(xDoc.Root.FirstAttribute.Name);
            Console.WriteLine(xDoc.Root.FirstAttribute.Value);
            
            xDoc.Root.FirstAttribute.Value = "zzzzz";
            xDoc.Save(path);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}