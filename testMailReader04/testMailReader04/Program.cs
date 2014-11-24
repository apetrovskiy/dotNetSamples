/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/24/2014
 * Time: 7:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testMailReader04
{
    using System;
    using ImapX;
    using ImapX.Enums;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new ImapClient("192.168.129.21", false, false);
            
            if (client.Connect()) {
                var result = client.Login("report_reader@SPALab.at.local", "Lock12Lock");
                Console.WriteLine(result);
            }
            
            client.Folders.Inbox.Messages.Download("UNSEEN", MessageFetchMode.Headers);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}