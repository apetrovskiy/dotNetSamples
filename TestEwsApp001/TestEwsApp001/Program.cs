using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEwsApp001
{
    using Microsoft.Exchange.WebServices.Data;

    class Program
    {
        static void Main(string[] args)
        {
            var service = new ExchangeService();

            // service.Url = new Uri(@"https://192.168.129.3/EWS/Exchange.asmx");
            // service.Url = new Uri(@"http://192.168.129.3/EWS/Exchange.asmx");
            // service.Url = new Uri(@"https://SPLab-Exchange.SPALab.at.local/EWS/Exchange.asmx");
            service.Url = new Uri(@"http://SPLab-Exchange.SPALab.at.local/EWS/Exchange.asmx");

            // service.Credentials = new WebCredentials("user_with_access@example.com", "password");
            // service.Credentials = new WebCredentials("suite_admin@SPALab.at.local", "Lock12Lock");
            service.Credentials = new WebCredentials("suite_admin", "Lock12Lock", "SPANEW");
            // service.Credentials = new WebCredentials(@"SPANEW\suite_admin", "Lock12Lock");
            // service.AutodiscoverUrl("a_valid_user@example.com");
            // service.AutodiscoverUrl("suite_admin@SPALab.at.local");

            var findResults01 = service.FindItems(
                new FolderId(WellKnownFolderName.Inbox, new Mailbox("suite_admin@SPALab.at.local")),
                new ItemView(10));

            var findResults02 = service.FindItems(
                new FolderId(WellKnownFolderName.Inbox, new Mailbox("report_reader@SPALab.at.local")),
                new ItemView(10));

            var userMailbox = new Mailbox("suite_admin@SPALab.at.local");
            var folderId = new FolderId(WellKnownFolderName.Inbox, userMailbox);

            var itemView = new ItemView(20);   // page size
            var userItems = service.FindItems(folderId, itemView);

            foreach (var item in userItems)
            {
                // do something with item (nb: it might not be a message)
            }



            userMailbox = new Mailbox("report_reader@SPALab.at.local");
            folderId = new FolderId(WellKnownFolderName.Inbox, userMailbox);

            itemView = new ItemView(20);   // page size
            userItems = service.FindItems(folderId, itemView);

            foreach (var item in userItems)
            {
                // do something with item (nb: it might not be a message)
            }
        }
    }
}
