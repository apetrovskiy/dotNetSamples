
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
            // this works
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td[@id]").Where(node => node.Id == "What");
            // this works
            // var whatCollection = doc.DocumentNode.SelectNodes ("//td[@id='What']|//td[@id='Who']");
            var whatCollection = doc.DocumentNode.SelectNodes("//td[@id='Action']");
            whatCollection.ToList().ForEach(node => {
                                                Console.WriteLine ("id={0}, text={1}", node.Id ?? string.Empty, node.InnerText ?? string.Empty);
                                                var nextNode = node.NextSibling;
                                                try {
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                    nextNode = nextNode.NextSibling;
                                                    Console.WriteLine("id={0}, text={1}", nextNode.Id ?? string.Empty, nextNode.InnerText ?? string.Empty);
                                                }
                                                catch (Exception ee) {
                                                    Console.WriteLine(ee.Message);
                                                }
                                            });
            Console.WriteLine (whatCollection.Count());

            Console.ReadKey ();
        }
    }
}
