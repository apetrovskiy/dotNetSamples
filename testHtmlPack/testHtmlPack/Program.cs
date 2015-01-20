/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 3/11/2014
 * Time: 2:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHtmlPack
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;
    using HtmlAgilityPack;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            #region commented
            /*
            var doc0 = new HtmlDocument();
            doc0.Load(@"D:\HTML\TPAMmenu.htm");
            // doc.Load(@"D:\HTML\TPAMmenu_wrong.htm");
            
            if (null != doc0.ParseErrors || doc0.ParseErrors.Any()) {
                Console.WriteLine("there are errors:");
                
                foreach (var htmlParseError in doc0.ParseErrors) {
                    Console.WriteLine(htmlParseError.Code);
                    Console.WriteLine(htmlParseError.SourceText);
                }
            }
            
            foreach (HtmlNode link in doc0.DocumentNode.SelectNodes("//a[@href]")) {
                // var attribute = link["href"];
                // attribute.valu
                Console.WriteLine(link.Name);
                Console.WriteLine(link.Id);
                Console.WriteLine(link.InnerHtml);
                Console.WriteLine(link.InnerText);
            }
            
            
            
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(@"<html><body><p><table id=""foo""><tr><th>hello</th></tr><tr><td>world</td></tr></table></body></html>");
            foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table")) {
                Console.WriteLine("Found: " + table.Id);
                foreach (HtmlNode row in table.SelectNodes("tr")) {
                    Console.WriteLine("row");
                    foreach (HtmlNode cell in row.SelectNodes("th|td")) {
                        Console.WriteLine("cell: " + cell.InnerText);
                    }
                }
            }
            
//            var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
//                        from row in table.SelectNodes("tr").Cast<HtmlNode>()
//                        from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
//                        select new {Table = table.Id, CellText = cell.InnerText};
            
            var query = from table in doc.DocumentNode.SelectNodes("//table")
                        from row in table.SelectNodes("tr")
                        from cell in row.SelectNodes("th|td")
                        select new {Table = table.Id, CellText = cell.InnerText};
            
            foreach(var cell in query) {
                Console.WriteLine("{0}: {1}", cell.Table, cell.CellText);
            }
            
            */
            #endregion commented
            
            var web = new HtmlWeb();
            web.Load(@"http://10.0.1.214/reportserver", "10.0.1.214", 80, @"outcast\spmgmtaccount", @"Lock12Lock");
            
            
            var letter = new HtmlAgilityPack.HtmlDocument();
            // letter.Load(@"D:\20140311\0943.htm");
            letter.Load(@"D:\20140311\0944.htm");
            
            // letter.ge
            
            Console.WriteLine("========================================================================================================================");
            
            // using (var xmlWriter = new XmlTextWriter(@"D:\20140311\0943.xml", Encoding.UTF8)) {
            using (var xmlWriter = new XmlTextWriter(@"D:\20140311\0944.xml", Encoding.UTF8)) {
                // var xmlWriter = XmlWriter.Create(@"D:\20140311\0943.xml");
                letter.DocumentNode.WriteTo(xmlWriter);
            }
            
            
            var tables = letter.DocumentNode.SelectNodes("//table[@id='changes']");
            if (null == tables) {
                Console.WriteLine("null == tables");
            } else {
                Console.WriteLine("null != tables");
                if (0 == tables.Count) {
                    Console.WriteLine("0 == tables.Count");
                } else {
                    Console.WriteLine("0 != tables.Count, {0}", tables.Count);
                    foreach (var table in tables) {
                        Console.WriteLine("name = {0}", table.Name);
                        Console.WriteLine("id = {0}", table.Id);
                    }
                }
            }
            
            Console.WriteLine("========================================================================================================================");
            
            try {
                foreach (HtmlNode tableNode in letter.DocumentNode.SelectNodes("//table[@id='changes']")) {
                    Console.WriteLine(tableNode.Name);
                    Console.WriteLine(tableNode.Id);
                    
                    foreach (var tableRow1 in tableNode.ChildNodes) {
                        Console.WriteLine("===========================================================");
                        
                        foreach (var tableCell in tableRow1.ChildNodes) {
                            Console.WriteLine(tableCell.InnerText);
                        }
                        
                    }
                }
            }
            catch (Exception eParsing) {
                Console.WriteLine(eParsing.Message);
            }
            
            
            Console.WriteLine("========================================================================================================================");
            // 20140321
            // var mhtml = new HtmlDocument();
            // mhtml.Load(@"D:\20140321\dashboard\All SharePoint Changes by Date.mhtml");
            var mhtmlPage = new HtmlWeb();
            // var cred = new netwo
            var mhtml = 
                mhtmlPage.Load(
                    @"http://vl-w8x86-client/ReportServer/Pages/ReportViewer.aspx?%2fNetwrix+Enterprise+Overview+Reports%2fEnterprise-Wide+Reports%2fSharePoint+Server%2fAll+SharePoint+Changes+by+Date&rs:Command=Render",
                    "GET", //"PUT", //"POST", // "GET", //string.Empty, // "10.0.1.214",
                    // 0, //80,
                    null,
                    new NetworkCredential() {
                        // UserName = @"outcast\spmgmtaccount",
                        UserName = @"spmgmtaccount",
                        Password = "Lock12Lock"});
            
            var allNodes = mhtml.DocumentNode.SelectNodes("//*");
            
            if (null == allNodes) {
                Console.WriteLine("null == allNodes");
            } else {
                Console.WriteLine("null != allNodes");
                foreach (var singleNode in allNodes) {
                    Console.WriteLine(singleNode.InnerText);
                }
            }
            
            var allTables = mhtml.DocumentNode.SelectNodes("//table");
            
            if (null == allTables) {
                Console.WriteLine("null == allTables");
            } else {
                Console.WriteLine("null != allTables");
                foreach (var singleTable in allTables) {
                    Console.WriteLine(singleTable.InnerText);
                }
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}