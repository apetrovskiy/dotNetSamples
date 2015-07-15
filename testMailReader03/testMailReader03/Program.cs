/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/24/2014
 * Time: 6:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testMailReader03
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using S22.Imap;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            using (var client = new ImapClient("192.168.129.21", 143, "report_reader@SPALab.at.local", "Lock12Lock", AuthMethod.Auto, false, null)) {
                
                var listMailboxes = client.ListMailboxes();
                foreach (var mailbox in listMailboxes) {
                    Console.WriteLine(mailbox);
                }
                
                client.DefaultMailbox = "INBOX";
                
                var d1 = DateTime.Now;
                // var uids = client.Search(SearchCondition.Undeleted(), "INBOX");
                var uids = client.Search(SearchCondition.Unseen(), "INBOX");
                // var uids = client.Search(SearchCondition.Unseen(), null);
                var messages = client.GetMessages(uids, FetchOptions.Normal, true, "INBOX");
                Console.WriteLine(uids);
                Console.WriteLine(DateTime.Now - d1);
                var d2 = DateTime.Now;
                // var messages = client.GetMessages(uids, FetchOptions.HeadersOnly, false, "INBOX");
//                var messages = client.GetMessages(uids, FetchOptions.HeadersOnly, false, null);
//                Console.WriteLine(messages);
//                Console.WriteLine(DateTime.Now - d2);
                
                var msg = messages.FirstOrDefault();
                var encoding = null == msg ? Encoding.UTF8 : msg.BodyEncoding;
                using (var writer = new StreamWriter(@"c:\1\mail.htm", false, encoding)) {
                    int i = 0;
                    foreach (var message in messages) {
                        i++;
                        Console.WriteLine(message.Subject);
                        writer.WriteLine(message.Subject);
                        writer.WriteLine(message.Body);
                    }
                    writer.Flush();
                    writer.Close();
                    
                    Console.WriteLine(i);
                }
                
                foreach (var uid in uids)
                    client.DeleteMessage(uid, null);
                
                client.Expunge(null);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}