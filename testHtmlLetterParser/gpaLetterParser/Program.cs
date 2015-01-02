
namespace gpaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\gpa_errors_2008R2.htm

            var doc = new HtmlDocument();
            doc.Load(@"../../../letters/gpa_errors_2008R2.htm");

            var tableProcessor = new TableProcessor(
                doc.DocumentNode.SelectNodes ("//table").First(),
                // "//table//td[. = 'User name']|//table//td[. = 'Email']|//table//td[. = 'Expires in']",
                ".",
                "",
                ".");
            tableProcessor.Process ();
            var list = tableProcessor.GetCollection ();
            tableProcessor.ExportCsv ("/home/alexander/Documents/gpa_errors.txt");

            Console.WriteLine ("Hello World!");
        }
    }
}
