﻿
namespace sqlaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\sqla_2008R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\sqla_empty_2008R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.111\sqla_2012.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.125\SQLA.2008R2.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/sqla_2008R2.htm");
            // doc.Load(@"../../../letters/sqla_empty_2008R2.htm");
            // doc.Load(@"../../../letters/1.1.1.111/sqla_2012.htm");
            // doc.Load(@"../../../letters/1.1.1.125/SQLA.2008R2.htm");
            doc.Load(@"../../../letters/1.1.1.183/sqla_2012.htm");
            doc.Load(@"../../../letters/1.1.1.369/2008R2_SQLA.htm");
            
            const string hostname = "splab-2008r2";
            const string fqdn = hostname + ".spalab.at.local";
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']").First()) {
                ColumnHeaderExpression = "./text()",
                RowItemExpression = "./pre|./text()" //"./pre|./text()"
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/sqla_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            var aaa = tableProcessor.ColumnHeaders.ToList();
            var bbb = tableProcessor.ColumnHeaderNames.ToList();
            
            var isTableRecorded = tableProcessor.Exists("Added", "Table", @"Databases\test01\Tables\dbo.ddd", "localhost", @"spanew\suite_admin", hostname);
            var isTableContentRecorded = tableProcessor.Exists("Added", "Data Row", @"Databases\test01\Tables\dbo.bbb\Data Row", "localhost", @"spanew\suite_admin", hostname);

            Console.WriteLine(isTableRecorded);
            Console.WriteLine(isTableContentRecorded);
            
            Console.ReadKey ();
        }
    }
}
