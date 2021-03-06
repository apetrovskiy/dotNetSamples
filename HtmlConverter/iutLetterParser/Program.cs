﻿
namespace iutLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/iut_7x86.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First()) {
                ColumnHeaderExpression = ".", // "self::td",
                RowItemExpression = ".", // "self::td");
                ColumnNames = new[] { "Account Name", "E-Mail" }
            };
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/iut_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}
