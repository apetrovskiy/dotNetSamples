/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/31/2014
 * Time: 6:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace penLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/7.0.33.0/pen_81x86.htm ");
            
            var tables = doc.DocumentNode.SelectNodes("//table");
            
            var tableProcessor = new TableProcessor(
                doc.DocumentNode.SelectNodes ("//table").First(),
                // "//table//td[. = 'User name']|//table//td[. = 'Email']|//table//td[. = 'Expires in']",
                "self::td",
                "",
                "self::td");
            tableProcessor.Process ();
            var list = tableProcessor.GetCollection ();
            tableProcessor.ExportCsv ("/home/alexander/Documents/pen_changes.txt");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}