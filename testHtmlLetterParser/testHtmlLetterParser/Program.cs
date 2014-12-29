
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
            // doc.Load (@"../../../letters/MailDump_SPLab-7x86.SPALab.at.local.htm");
            doc.Load (@"../../../letters/1111.htm");
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
            //this works
            /*
            var changeCollection = doc.DocumentNode.SelectNodes("//td[@id='Action']");
            changeCollection.ToList().ForEach(node => {
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
            Console.WriteLine (changeCollection.Count());
            */

            int counter = 0;
            foreach (var table in doc.DocumentNode.SelectNodes ("//table[@id='ChangesTable']")) {
                counter++;
                Console.WriteLine ("===================================== {0} =====================================", counter);
                var tableProcessor = new TableProcessor (table, true);
                tableProcessor.Process ();
                tableProcessor.ColumnHeaders.ToList ().ForEach (node => Console.WriteLine(node.InnerText));
                tableProcessor.Rows.ToList ().ForEach (node => {
                    string rowItems = string.Empty;
                    Console.WriteLine(node.InnerText);
                    Console.WriteLine("/////////////////////////////////");
                    node.SelectNodes("//table[@id='ChangesTable']/descendant:td").ToList().ForEach(tdNode => {
                        rowItems += "|";
                        rowItems += tdNode.InnerText.Trim();
                    });
                    Console.WriteLine(rowItems);
                    Console.WriteLine("===========================================================================================================================");
                    Console.ReadKey();
                });
            }
            /*
            counter = 0;
            foreach (var table in doc.DocumentNode.SelectNodes ("//table[@id='ChangesTable']")) {
                counter++;
                Console.WriteLine ("===================================== {0} =====================================", counter);
                var tableProcessor = new TableProcessor (table, true);
                tableProcessor.Process ();
                tableProcessor.Rows.ToList ().ForEach (node => Console.WriteLine(node.InnerText));
            }
            */
            Console.ReadKey ();
        }
    }
}
