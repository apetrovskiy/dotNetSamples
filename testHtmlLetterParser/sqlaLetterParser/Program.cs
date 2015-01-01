
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
                // "//table//td[. = 'User name']|//table//td[. = 'Email']|//table//td[. = 'Expires in']",
                "./text()",
                "",
                "./text()");
            tableProcessor.Process ();
            var list = tableProcessor.GetCollection ();
            tableProcessor.ExportCsv ("/home/alexander/Documents/sqla_changes.txt");
            
            Console.WriteLine ("Hello World!");
        }
    }
}
