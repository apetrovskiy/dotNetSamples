/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/25/2013
 * Time: 6:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace linqtoxmlreader
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.IO;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            string filePath =
                //@"D:\Products\Data\ADCR\AD Change Reporter\Data\castaway.at.local\DataCollectionSettings_castaway.at.local.xml";
                @"D:\Products\Data\ADCR\AD Change Reporter\Rules\castaway%at%local\Changes_x0020_to_x0020_Admin_x0020_Group_x0020_Memberships 1.xml";
            
            XDocument xdoc;
            using (StreamReader sr = new StreamReader(filePath, true))
            {
                xdoc = XDocument.Load(sr);
            }
            
            var custs = from c in xdoc.Elements()
                select c;
            
            // Create the query 
            //var custs = from c in XElement.Load("Customers.xml").Elements("Customers") 
//            var custs = from c in XElement.Load(filePath).Elements() //("Customers")
//                      select c ;
            
            // Execute the query 
            foreach (var customer in custs) 
            { 
                 Console.WriteLine("==========================Attribute:================================");
                 Console.WriteLine(customer);
                 Console.WriteLine("==========================Value:================================");
                 Console.WriteLine(customer.Value);
                 //Console.WriteLine(customer.Ancestors()
                 Console.WriteLine("==========================Ancestry:================================");
                 var ancestors = customer.Ancestors();
                 foreach (var element in ancestors) {
                     Console.WriteLine(element.Name);
                 }
            }
            
            //Pause the application 
            Console.ReadLine();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}