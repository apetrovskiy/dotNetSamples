
namespace uavrLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.218\UAVR.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.168\uavr_2008R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.168\uavr_2012.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.168\uavr_2012R2.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.168\uavr_7x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.168\uavr_8.1x86.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/1.1.1.218/UAVR.htm");
            // doc.Load(@"../../../letters/1.1.1.168/UAVR_2008R2.htm");
            // doc.Load(@"../../../letters/1.1.1.168/UAVR_2012R2.htm");
            doc.Load(@"../../../letters/1.1.1.347/uavr_2012.htm");
            var hostname = "SPLab-2012"; // "SPLab-2012R2"; // "splab-2012r2"; // "splab-2008r2";
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First()) {
                ColumnHeaderExpression = ".", // "self::td",
                RowItemExpression = ".", // "self::td");
                ColumnNames = new[] { "Date", "Start time", "End time", "Duration", "Computer", "User" }
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/uavr_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.WriteLine(
                tableProcessor.Exists(hostname +  ".SPALab.at.local", @"SPANEW\suite_admin")
               );
            
            Console.ReadKey ();
        }
    }
}
