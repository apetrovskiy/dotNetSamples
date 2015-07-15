
namespace fsaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_7x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_empty_7x86.htm
            
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\fsa_7x86.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/7.0.35.0/fsa_7x86.htm");
            // doc.Load(@"../../../letters/7.0.35.0/fsa_7x86.htm");
            doc.Load(@"../../../letters/1.1.1.369/2008R2_FSA.htm");
            
            const string hostname = "splab-2008r2";
            const string fqdn = hostname + ".spalab.at.local";
            
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
            Console.WriteLine(tableProcessor.Exists("Modified", "File", @"\tests\test01.txt", hostname, @"spanew\suite_admin", ""));
            Console.WriteLine(tableProcessor.Exists("Read", "File", @"\tests\test01.txt", hostname, @"spanew\suite_admin", ""));
            
            Console.ReadKey ();
        }
    }
}
