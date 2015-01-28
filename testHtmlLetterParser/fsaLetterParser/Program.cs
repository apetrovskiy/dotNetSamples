
namespace fsaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_7x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_empty_7x86.htm
            
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\fsa_7x86.htm
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/7.0.35.0/fsa_7x86.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']").First()) {
                ColumnHeaderExpression = "./text()",
                RowItemExpression = "./pre|./text()"
            };
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/fsa_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            // $tableProcessor.Exists("Modified", "File", "\tests\test01.txt", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Success", "File", "\tests\test01.txt", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            var isModifiedRecorded = tableProcessor.Exists("Modified", "File", @"\tests\test01.txt", "splab-7x86", @"spanew\suite_admin");
            var isSuccessRecorded = tableProcessor.Exists("Success", "File", @"\tests\test01.txt", "splab-7x86", @"spanew\suite_admin");
            
            Console.ReadKey ();
        }
    }
}
