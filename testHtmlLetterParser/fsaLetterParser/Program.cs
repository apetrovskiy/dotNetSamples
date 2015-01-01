
namespace fsaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_7x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\fsa_empty_7x86.htm
            
            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/fsa_7x86.htm");
            
            var tableProcessor = new TableProcessor(
                doc.DocumentNode.SelectNodes ("//table[@id='ChangesTable']").First(),
                // "//table//td[. = 'User name']|//table//td[. = 'Email']|//table//td[. = 'Expires in']",
                "./text()",
                "",
                "./text()");
            tableProcessor.Process ();
            var list = tableProcessor.GetCollection ();
            tableProcessor.ExportCsv ("/home/alexander/Documents/fsa_changes.txt");
            
            Console.WriteLine ("Hello World!");
        }
    }
}
