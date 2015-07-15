
namespace adaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.36.0\ada_empty.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.36.0\ada.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/7.0.36.0/ada_empty.htm");
            // doc.Load(@"../../../letters/7.0.36.0/ada.htm");
            doc.Load(@"../../../letters/1.1.1.369/2008R2_ADA.htm");
            
            const string hostname = "splab-2008r2";
            const string fqdn = hostname + ".spalab.at.local";
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']").First()) {
                ColumnHeaderExpression = "./text()",
                RowItemExpression = "./pre|./text()"
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/ada_changes.txt");
            
            var list = tableProcessor.GetCollection ();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            // objPath=\local\at\SPALab\TestOu\testGroup0001, objType=group, what=1, who=SPANEW\suite_admin, where=SPLab-DC.SPALab.at.local, wst=Workstation:splab-2012.spalab.at.local(MAC:)
            // objPath=\local\at\SPALab\TestOu, objType=organizationalUnit, what=1, who=SPANEW\suite_admin, where=SPLab-DC.SPALab.at.local, wst=Workstation:splab-2012.spalab.at.local(MAC:)
            
            // var isAdded01Recorded = tableProcessor.Exists("Added", "group", @"\local\at\SPALab\TestOu\testGroup0001", "SPLab-DC.SPALab.at.local", @"spanew\suite_admin");
            // var isAdded02Recorded = tableProcessor.Exists("Added", "organizationalUnit", @"\local\at\SPALab\TestOu", "SPLab-DC.SPALab.at.local", @"spanew\suite_admin");
            Console.WriteLine(tableProcessor.Exists("Added", "group", string.Format(@"\local\at\SPALab\{0}-ou\{1}-group", hostname, hostname), "SPLab-DC.SPALab.at.local", @"spanew\suite_admin", fqdn));
            Console.WriteLine(tableProcessor.Exists("Added", "organizationalUnit", string.Format(@"\local\at\SPALab\{0}-ou", hostname), "SPLab-DC.SPALab.at.local", @"spanew\suite_admin", fqdn));
            
            Console.ReadKey ();
        }
    }
}
