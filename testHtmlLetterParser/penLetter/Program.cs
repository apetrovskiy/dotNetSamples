/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
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
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.135\pen.2012.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.135\pen.2012R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.135\pen.81x86.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/7.0.33.0/pen_81x86.htm");
            // doc.Load(@"../../../letters/1.1.1.135/pen.2012.htm");
            // doc.Load(@"../../../letters/1.1.1.135/pen.2012R2.htm");
            doc.Load(@"../../../letters/1.1.1.135/pen.81x86.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='OuterChangesTable']").First()) {
                ColumnHeaderExpression = ".", // "self::td",
                RowItemExpression = ".", // "self::td");
                ColumnNames = new[] { "User name", "Email", "Expires in" }
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/pen_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}