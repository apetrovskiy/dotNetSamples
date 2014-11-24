﻿/*
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
                // var uids = client.Search((SearchCondition.Unseen(), "INBOX");
                var uids = client.Search(SearchCondition.Unseen(), null);
                Console.WriteLine(uids);
                Console.WriteLine(DateTime.Now - d1);
                var d2 = DateTime.Now;
                // var messages = client.GetMessages(uids, FetchOptions.HeadersOnly, false, "INBOX");
                var messages = client.GetMessages(uids, FetchOptions.HeadersOnly, false, null);
                Console.WriteLine(messages);
                Console.WriteLine(DateTime.Now - d2);
                
                int i = 0;
                foreach (var message in messages) {
                    i++;
                    Console.WriteLine(message.Subject);
                }
                Console.WriteLine(i);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}