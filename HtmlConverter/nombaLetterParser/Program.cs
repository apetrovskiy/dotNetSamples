/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 03/07/2015
 * Time: 07:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace nombaLetterParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class Program
    {
        public static void Main(string[] args)
        {
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/1.1.1.457/nomba.htm");
            // doc.Load(@"../../../letters/1.1.1.457/__NOMBA__.htm");
            doc.Load(@"../../../letters/1.1.1.457/1.htm");
            
            
            var table = doc.DocumentNode.SelectNodes("//table").First();
            if (table.Descendants().Any())
                Console.WriteLine("Any!");
            IEnumerable<HtmlNode> descendants = table.Descendants().AsEnumerable();
            var children = table.ChildNodes;
            var selectedNodes = table.SelectNodes(".//tr");
            foreach (var element in table.Descendants()) {
                Console.WriteLine(element.Name);
            }
            var rows1 = table.Descendants();
            
            var tds = doc.DocumentNode.SelectNodes("//td");
            
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table").First(), true) {
                ColumnHeaderExpression = ".[@class='dt']", // "./text()", // ".", // "./text()",
                RowItemExpression = ".[@class='dt1'|@class='dt2']", // "./pre|./text()",
                ColumnNames = new[] { "Who Accessed", "When Accessed", "Mailbox", "Server", "Access Type", "Details" }
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/nomba_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
//            var isModified01Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\ControlSet001\services\test01", "splab-7x86", @"spanew\suite_admin");
//            var isAdded01Recorded = tableProcessor.Exists("Added", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin");
//            var isModified02Recorded = tableProcessor.Exists("Modified", "Local Group", @"System Information\Local Groups\Users", "splab-7x86", @"spanew\suite_admin");
//            var isModified03Recorded = tableProcessor.Exists("Modified", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin");
//            var isModified04Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\CurrentControlSet\services\test01", "splab-7x86", @"System");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}