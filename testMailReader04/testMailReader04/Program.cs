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
            
            client.Behavior.AutoPopulateFolderMessages = true;
            // client.Behavior.SearchAllNotSupported = 
            client.Behavior.AutoDownloadBodyOnAccess = true;
            client.Behavior.ExamineFolders = true;
            // client.Behavior.MessageFetchMode = MessageFetchMode.Full;
            client.Behavior.MessageFetchMode = MessageFetchMode.Minimal;
            // var msgs = client.Folders.Inbox.Search("UNSEEN");
            // var msgs = client.Folders.Inbox.Search("UNDELETED");
            // var msgs = client.Folders.Inbox.Search("\\UNDELETED");
            // var msgs = client.Folders.Inbox.Search("NEW");
            var msgs = client.Folders.Inbox.Search("FLAGGED");
            
            var messages = client.Folders.Inbox.Messages;
            
            client.Folders.Inbox.Messages.Download("UNSEEN", MessageFetchMode.Full);
            
            
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}