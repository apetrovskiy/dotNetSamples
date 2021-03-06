﻿
namespace gpaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\gpa_errors_2008R2.htm

            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/gpa_errors_2008R2.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First()) {
                ColumnHeaderExpression = ".",
                RowItemExpression = ".",
                ColumnNames = new[] { "Location", "Type", "Message" }
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/gpa_errors.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}
