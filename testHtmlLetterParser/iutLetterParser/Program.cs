
namespace iutLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/iut_7x86.htm");
            
            var tableProcessor = new TableProcessor (
                                     doc.DocumentNode.SelectNodes ("//table").First (),
                                     ".", // "self::td",
                                     "",
                                     "."); // "self::td");
            tableProcessor.Process ();
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/iut_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
        }
    }
}
