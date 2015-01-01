
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
                // "//table//td[. = 'User name']|//table//td[. = 'Email']|//table//td[. = 'Expires in']",
                                     ".", // "self::td",
                                     "",
                                     "."); // "self::td");
            tableProcessor.Process ();
            var list = tableProcessor.GetCollection ();
            tableProcessor.ExportCsv ("/home/alexander/Documents/iut_changes.txt");
            
            Console.WriteLine ("Hello World!");
        }
    }
}
