﻿
namespace vmaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // "C:\Projects\probe\testHtmlLetterParser\letters\7.0.34.0\Netwrix Auditor VMware Change Summary - https172.28.1.11.htm"
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.34.0\vma_change.htm
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/7.0.34.0/vma_change.htm");
            
            var tableProcessor = new TableProcessor (
                                     doc.DocumentNode,
                                     "//table[@id='ChangesTable']",
                                     "./text()",
                                     "./text()"); // ,
                                     // "Action", "Object Type");
            
            tableProcessor.Process ();
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/vma_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}
