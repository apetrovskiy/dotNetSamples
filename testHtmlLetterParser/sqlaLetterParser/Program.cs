
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
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/sqla_2008R2.htm");
            
            var tableProcessor = new TableProcessor(
                doc.DocumentNode.SelectNodes ("//table[@id='ChangesTable']").First(),
                "./text()",
                "",
                "./text()");
            tableProcessor.Process ();
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/sqla_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
        }
    }
}
