/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 06:16 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testEwsNet35
{
    using System;
    using System.Threading;
    using Microsoft.Exchange.WebServices.Data;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var service = new ExchangeService();
            
            // service.Url = new Uri(@"https://192.168.129.3/EWS/Exchange.asmx");
            service.Url = new Uri(@"http://192.168.129.3/EWS/Exchange.asmx");
            
            // service.Credentials = new WebCredentials("user_with_access@example.com", "password");
            service.Credentials = new WebCredentials("suite_admin@SPALab.at.local", "Lock12Lock");
            // service.AutodiscoverUrl("a_valid_user@example.com");
            // service.AutodiscoverUrl("suite_admin@SPALab.at.local");
            
            var userMailbox = new Mailbox("report_reader@SPALab.at.local");
            var folderId = new FolderId(WellKnownFolderName.Inbox, userMailbox);
            
            var itemView = new ItemView(20);   // page size
            var userItems = service.FindItems(folderId, itemView);
            
            foreach (var item in userItems)
            {
                // do something with item (nb: it might not be a message)
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}