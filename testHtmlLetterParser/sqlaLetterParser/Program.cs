
namespace sqlaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\sqla_2008R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\sqla_empty_2008R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.111\sqla_2012.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/sqla_2008R2.htm");
            // doc.Load(@"../../../letters/sqla_empty_2008R2.htm");
            doc.Load(@"../../../letters/1.1.1.111/sqla_2012.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']").First()) {
                ColumnHeaderExpression = "./text()",
                RowItemExpression = "./pre|./text()"
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/sqla_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            var aaa = tableProcessor.ColumnHeaders.ToList();
            var bbb = tableProcessor.ColumnHeaderNames.ToList();
            
            var isTableRecorded = tableProcessor.Exists("Added", "Table", @"Databases\test01\Tables\dbo.ddd", "localhost", @"spanew\suite_admin");
            var isTableContentRecorded = tableProcessor.Exists("Added", "Data Row", @"Databases\test01\Tables\dbo.bbb\Data Row", "localhost", @"spanew\suite_admin");
            
            Console.ReadKey ();
        }
    }
}
