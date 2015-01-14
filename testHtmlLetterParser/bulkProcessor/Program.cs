/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 1/14/2015
 * Time: 4:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace bulkProcessor
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using testHtmlLetterParser;
    
    class Program
    {
        public static void Main(string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.112\MailDump_SPLab-2012.SPALab.at.local.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\1.1.1.112\MailDump_SPLab-7x86.SPALab.at.local.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\MailDump_SPLab-2012.SPALab.at.local.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\MailDump_SPLab-7x86.SPALab.at.local.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/1.1.1.112/MailDump_SPLab-2012.SPALab.at.local.htm");
            // doc.Load(@"../../../letters/1.1.1.112/MailDump_SPLab-7x86.SPALab.at.local.htm");
            // doc.Load(@"../../../letters/7.0.35.0/MailDump_SPLab-2012.SPALab.at.local.htm");
            doc.Load(@"../../../letters/7.0.35.0/MailDump_SPLab-7x86.SPALab.at.local.htm");
            
            var tableCollection = doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']");
            
            int counter = 30;
            foreach (var tableNode in tableCollection) {
                counter++;
                var tableProcessor = new TableProcessor(tableNode, "./text()", "./pre|./text()");
                Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
                if (!tableProcessor.Ready) continue;
                tableProcessor.ExportCsv("/home/alexander/Documents/many_changes" + counter + ".txt");
                
                var list = tableProcessor.GetCollection ();
                foreach (var dict in list)
                    foreach (var key in dict.Keys)
                        Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            }
            
            Console.ReadKey(true);
        }
    }
}