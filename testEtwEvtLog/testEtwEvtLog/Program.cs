/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 27/07/2015
 * Time: 07:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testEtwEvtLog
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Tx.Windows;
//    using Tx.Windows;
    
    class Program
    {
        public static void Main(string[] args)
        {
//            var eventLogObservable = EvtxObservable.FromLog("System");
//            // var eventLogObservable = EvtxObservable.FromLog("NetWrixChangeReporter");
//            eventLogObservable.Subscribe(aaa => Console.WriteLine(aaa.Properties[0].Value)); // .Select(evt => Console.WriteLine(evt.Properties[0].Value));
            // var records = EvtxEnumerable.FromFiles(@"\\192.168.129.25\C$\Windows\System32\winevt\Logs\NetWrixChangeReporter.evtx");
            var records = EvtxEnumerable.FromFiles(@"E:\20150727\NetWrixChangeReporter.evtx");
            records.Select(record => record.Properties[5].Value).ToList().ForEach(record => Console.WriteLine(record));
            
            // var eventLog = new EventLog("Application", "myserver", "newsource");
            // var eventLog = new EventLog("Application");
            // var eventLog = new EventLog("NetWrixChangeReporter", Environment.MachineName, "Netwrix Auditor for File Servers"); // "Netwrix Auditor for Active Directory");
            // var eventLog = new EventLog("System");
            var eventLog = new EventLog("NetWrixChangeReporter", "192.168.129.25", "Netwrix Auditor for File Servers");
            // eventLog1.WriteEntry("Test");
            // eventLog.Entries
            Console.WriteLine(eventLog.Entries.Count);

            for (int i = 0; i < eventLog.Entries.Count; i++)
            {
                var entry = eventLog.Entries[i];

                Console.WriteLine(entry.Message);
            }

            foreach (EventLogEntry entry in eventLog.Entries) {
            // foreach (EventLogEntry entry in eventLog.Entries.Cast<EventLogEntry>().ToList<EventLogEntry>()) {
                // Console.WriteLine(entry.Message);
                // string[] message = new string[] { entry.Message };
                // Console.WriteLine(message);
                entry.GetLifetimeService();
                Console.WriteLine(entry.Message);
                Console.WriteLine("========================");
                Console.WriteLine(entry.GetType().Name);
                Console.WriteLine(entry.Message.GetType().Name);
                // Console.WriteLine(message.GetType().Name);
                // Console.WriteLine(message.ToString());
                Console.WriteLine("=================================================================================================");
            }
            
            EventLog log = new EventLog("NetWrixChangeReporter");
            var query = from EventLogEntry entry in log.Entries
                // where entry.EntryType == EventLogEntryType.Error // &&
                // entry.TimeGenerated > DateTime.Now.Subtract(new TimeSpan(6, 0, 0))
                select entry.Message;
            // Console.WriteLine("There were " + query.Count<string>( ) + " Application Event Log error messages in the last 6 hours!");
            foreach (string message in query)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("There were " + query.Count<string>( ) + " Event Log messages at all");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}