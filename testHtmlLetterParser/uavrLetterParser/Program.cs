﻿
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
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/1.1.1.218/UAVR.htm");
            
            var tableProcessor = new TableProcessor (
                                     doc.DocumentNode,
                                     "//table",
                                     ".", // "self::td",
                                     ".", // "self::td");
                                     "Date", "Start time", "End time", "Duration", "Computer", "User");
            
            tableProcessor.Process ();
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/uavr_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}
