/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/15/2013
 * Time: 6:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace xmlMerge
{
    using System;
    using System.Xml;
    using System.Data;
    using System.Xml.Linq;
    using System.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            try
        	{
        		XmlTextReader xmlreader1 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
        		XmlTextReader xmlreader2 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
        
        		DataSet ds = new DataSet();
        		ds.ReadXml(xmlreader1);
        		DataSet ds2 = new DataSet();
        		ds2.ReadXml(xmlreader2);
        		ds.Merge(ds2);
        		ds.WriteXml(@"C:\Projects\tests\xmlMerge\xmlMerge\merged_FSCR0001.xml");
        		Console.WriteLine("Completed merging XML documents");
        		
        		xmlreader1 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
        		xmlreader2 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
        		DataSet dsr = new DataSet();
        		dsr.ReadXml(xmlreader1);
        		DataSet dsr2 = new DataSet();
        		dsr2.ReadXml(xmlreader2);
        		dsr.Merge(dsr2, true);
        		dsr.WriteXml(@"C:\Projects\tests\xmlMerge\xmlMerge\merged2_FSCR0001.xml");
        		Console.WriteLine("Completed merging XML documents");
        		
        		xmlreader1 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
        		xmlreader2 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
        		DataSet dsrr = new DataSet();
        		dsrr.ReadXml(xmlreader1);
        		DataSet dsrr2 = new DataSet();
        		dsrr2.ReadXml(xmlreader2);
        		dsrr.Merge(dsrr2, false);
        		dsrr.WriteXml(@"C:\Projects\tests\xmlMerge\xmlMerge\merged3_FSCR0001.xml");
        		Console.WriteLine("Completed merging XML documents");
        		
        		xmlreader1 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
        		xmlreader2 = new XmlTextReader(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
        		DataSet dsr_ = new DataSet();
        		dsr_.ReadXml(xmlreader1);
        		DataSet dsr2_ = new DataSet();
        		dsr_.ReadXml(xmlreader2);
        		//dsr_.m
        		dsr_.WriteXml(@"C:\Projects\tests\xmlMerge\xmlMerge\merged2_2_FSCR0001.xml");
        		Console.WriteLine("Completed merging XML documents");
        		
        		
        		var xml1 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
                var xml2 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
                
                //Combine and remove duplicates
                System.Collections.Generic.IEnumerable<XElement> combinedUnique =
                    xml1.Descendants()
                    .Union(xml2.Descendants());
                XDocument doc1 =
                    new XDocument(
                        new XElement(
                            "FSCR",
                            combinedUnique));
                Console.WriteLine("new document");
                doc1.Save(@"C:\Projects\tests\xmlMerge\xmlMerge\combined_FSCR0001.xml");
                
                xml1 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
                xml2 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
                
                //Combine and keep duplicates
                System.Collections.Generic.IEnumerable<XElement> combinedWithDups =
                    xml1.Descendants()
                    .Concat(xml2.Descendants());
                XDocument doc2 =
                    new XDocument(
                       new XElement(
                           "FSCR",
                           combinedWithDups));
                Console.WriteLine("new document");
                doc2.Save(@"C:\Projects\tests\xmlMerge\xmlMerge\combinedWithDups_FSCR0001.xml");
                
                xml1 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
                xml2 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
                
                //Combine and remove duplicates
                System.Collections.Generic.IEnumerable<XNode> combined3 =
                    xml1.DescendantNodes()
                    .Union(xml2.DescendantNodes());
                XDocument doc3 =
                    new XDocument(
                        new XElement(
                            "FSCR",
                            combinedUnique));
                Console.WriteLine("new document");
                doc3.Save(@"C:\Projects\tests\xmlMerge\xmlMerge\combined3_FSCR0001.xml");
                
                xml1 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0001.xml");
                xml2 = XDocument.Load(@"C:\Projects\tests\xmlMerge\xmlMerge\FSCR0002.xml");
                
                //Combine and keep duplicates
                System.Collections.Generic.IEnumerable<XNode> combined4 =
                    xml1.DescendantNodes()
                    .Concat(xml2.DescendantNodes());
                XDocument doc4 =
                    new XDocument(
                       new XElement(
                           "FSCR",
                           combinedWithDups));
                Console.WriteLine("new document");
                doc4.Save(@"C:\Projects\tests\xmlMerge\xmlMerge\combined4_FSCR0001.xml");
                
//                //Combine and join
//                System.Collections.Generic.IEnumerable<XElement> combinedJoin =
//                    xml1.Descendants()
//                    .DescendantNodes
//                    //.Join(xml2.Descendants(),);
//                XDocument doc4 =
//                    new XDocument(
//                       new XElement(
//                           "FSCR",
//                           combinedJoin));
//                Console.WriteLine("new document");
//                doc4.Save(@"C:\Projects\tests\xmlMerge\xmlMerge\combinedJoin_FSCR0001.xml");
        	}
        	catch (System.Exception ex)
        	{
        		Console.Write(ex.Message);
        	}
            //Console.Read();
            
//            try
//        	{
//        		XmlTextReader xmlreader1 = new XmlTextReader("C:\\Books2.xml");
//        		XmlTextReader xmlreader2 = new XmlTextReader("C:\\Books1.xml");
//        
//        		DataSet ds = new DataSet();
//        		ds.ReadXml(xmlreader1);
//        		DataSet ds2 = new DataSet();
//        		ds2.ReadXml(xmlreader2);
//        		ds.Merge(ds2);
//        		ds.WriteXml("C:\\Books.xml");
//        		Console.WriteLine("Completed merging XML documents");
//        	}
//        	catch (System.Exception ex)
//        	{
//        		Console.Write(ex.Message);
//        	}
            //Console.Read();	
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}