
namespace wsaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.33.0\wsa_81x86.htm
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/7.0.33.0/wsa_81x86.htm");
            
            var tableProcessor = new TableProcessor(
                doc.DocumentNode,
                "//table[@id='ChangesTable']",
                "./text()",
                "./text()",
                "Action", "Object Type");
            
            tableProcessor.Process ();
            
            tableProcessor.ExportCsv ("/home/alexander/Documents/wsa_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            Console.ReadKey ();
        }
    }
}
