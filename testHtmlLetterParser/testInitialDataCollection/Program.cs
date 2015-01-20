/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/19/2015
 * Time: 7:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInitialDataCollection
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class Program
    {
        public static void Main(string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\ada_initial.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\esa_initial.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\fsa_initial.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\sqla_initial.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\vma_initial.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.119\wsa_initial.htm
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/1.1.1.119/ada_initial.htm");
            /*1
            var tableProcessor = new TableProcessor(
                doc.DocumentNode,
                "//table[@id='FirstCollectionTable']",
                "",
                ".");
            */
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='FirstCollectionTable']").First()) {
                ColumnHeaderExpression = "",
                RowItemExpression = "."
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            // tableProcessor.ExportCsv ("/home/alexander/Documents/fsa_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            // $tableProcessor.Exists("Modified", "File", "\tests\test01.txt", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Success", "File", "\tests\test01.txt", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            var isModifiedRecorded = tableProcessor.Exists("Modified", "File", @"\tests\test01.txt", "splab-7x86", @"spanew\suite_admin");
            var isSuccessRecorded = tableProcessor.Exists("Success", "File", @"\tests\test01.txt", "splab-7x86", @"spanew\suite_admin");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}