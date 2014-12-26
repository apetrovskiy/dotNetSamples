
namespace testHtmlLetterParser
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using HtmlAgilityPack;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");

            var doc = new HtmlDocument ();
            doc.Load (@"../../../letters/MailDump_SPLab-7x86.SPALab.at.local.htm");
            // doc.DocumentElement.SelectNodes("//input[@id=user1]");
            // doc.DocumentElement.SelectNodes("//input[@id=password1]");
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td[@*]");
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td");
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td[@class]");
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td[@id]");
            var whatCollection = doc.DocumentNode.SelectNodes ("//td[@id]").Where(node => node.Id == "What");
            whatCollection.ToList().ForEach(node => Console.WriteLine (node.Id));
            Console.WriteLine (whatCollection.Count);

            Console.ReadKey ();
        }
    }
}
