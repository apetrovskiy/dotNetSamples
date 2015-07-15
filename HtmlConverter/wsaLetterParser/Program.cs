
namespace wsaLetterParser
{
    using System;
    using System.Linq;
    using HtmlAgilityPack;
    using HtmlConverter;

    class MainClass
    {
        public static void Main (string[] args)
        {
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.33.0\wsa_81x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\wsa_7x86.htm
            // C:\Projects\probe\testHtmlLetterParser\letters\7.0.35.0\wsa_empty_7x86.htm
            
            var doc = new HtmlDocument();
            // doc.Load(@"../../../letters/7.0.33.0/wsa_81x86.htm");
            doc.Load(@"../../../letters/7.0.35.0/wsa_7x86.htm");
            // doc.Load(@"../../../letters/7.0.35.0/wsa_empty_7x86.htm");
            
            var tableProcessor = new TableProcessor(doc.DocumentNode.SelectNodes("//table[@id='ChangesTable']").First()) {
                ColumnHeaderExpression = "./text()",
                RowItemExpression = "./pre|./text()"
                // "Action", "Object Type");
            };
            
            Console.WriteLine("is table processor ready? {0}", tableProcessor.Ready);
            if (!tableProcessor.Ready) return;
            
            tableProcessor.ExportCsv (@"../../../reports/wsa_changes.txt");
            
            var list = tableProcessor.GetCollection();
            foreach (var dict in list)
                foreach (var key in dict.Keys)
                    Console.WriteLine ("{0}\t=\t{1}", key, dict[key]);
            
            // $tableProcessor.Exists("Modified", "Registry Key", "Registry\HKEY_LOCAL_MACHINE\system\ControlSet001\services\test01", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Added", "Local User", "System Information\Local Users\test01", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Modified", "Local Group", "System Information\Local Groups\Users", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Modified", "Local User", "System Information\Local Users\test01", "$(hostname)", "$($env:USERDOMAIN)\$($env:USERNAME)");
            // $tableProcessor.Exists("Modified", "Registry Key", "Registry\HKEY_LOCAL_MACHINE\system\CurrentControlSet\services\test01", "$(hostname)", "System");
            /*
            var isModified01Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\ControlSet001\services\test01", "splab-7x86", @"spanew\suite_admin");
            var isAdded01Recorded = tableProcessor.Exists("Added", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin");
            var isModified02Recorded = tableProcessor.Exists("Modified", "Local Group", @"System Information\Local Groups\Users", "splab-7x86", @"spanew\suite_admin");
            var isModified03Recorded = tableProcessor.Exists("Modified", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin");
            var isModified04Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\CurrentControlSet\services\test01", "splab-7x86", @"System");
            */
            var isModified01Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\ControlSet001\services\test01", "splab-7x86", @"spanew\suite_admin", "");
            var isAdded01Recorded = tableProcessor.Exists("Added", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin", "");
            var isModified02Recorded = tableProcessor.Exists("Modified", "Local Group", @"System Information\Local Groups\Users", "splab-7x86", @"spanew\suite_admin", "");
            var isModified03Recorded = tableProcessor.Exists("Modified", "Local User", @"System Information\Local Users\test01", "splab-7x86", @"spanew\suite_admin", "");
            var isModified04Recorded = tableProcessor.Exists("Modified", "Registry Key", @"Registry\HKEY_LOCAL_MACHINE\system\CurrentControlSet\services\test01", "splab-7x86", @"System", "");
            
            Console.ReadKey ();
        }
    }
}
