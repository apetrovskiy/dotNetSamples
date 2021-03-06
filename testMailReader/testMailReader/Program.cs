
namespace testMailReader
{
    using System;
    using ActiveUp.Net.Imap4;
    using ActiveUp.Net.Mail;
    using OpenPop.Pop3;
    using OpenPop.Common.Logging;
    using OpenPop.Mime;
    using OpenPop.Pop3.Exceptions;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");
            
            var client = new OpenPop.Pop3.Pop3Client();
            // client.Connect("pop.gmail.com", 995, true);
            client.Connect("192.168.129.21", 110, false);
            client.Authenticate("report_reader@SPALab.at.local", "Lock12Lock", AuthenticationMethod.Auto);
            var count = client.GetMessageCount();
            Console.WriteLine(count);
            // var msg01 = client.GetMessage(349);
            var msg01 = client.GetMessage(42);
            foreach (var msgInfo in client.GetMessageInfos()) {
                Console.WriteLine(msgInfo.Identifier + " " + msgInfo.Number + " " + msgInfo.Size);
            }
            for (int i = 1; i <= client.GetMessageCount(); i++) {
                Console.WriteLine(client.GetMessage(i).Headers.Subject);
            }
            // this works
//            for (int i = 1; i <= 10; i++) {
//                client.DeleteMessage(i);
//            }
            
            foreach (var capKey in client.Capabilities().Keys) {
                Console.WriteLine(capKey);
                Console.WriteLine(client.Capabilities()[capKey]);
            }
            
            Console.WriteLine(client.GetMessageCount());
            
            // client.DeleteAllMessages();
            Console.WriteLine(client.GetMessageCount());
            client.Disconnect();
            client.Dispose();
            
            
//            Message message = client.GetMessage(count);
//            Console.WriteLine(message.Headers.Subject);
            

            var pop3Client = new ActiveUp.Net.Mail.Pop3Client();
            // pop3Client.ConnectSsl("pop.gmail.com", 995, "admin@bendytree.com", "YourPasswordHere");
            pop3Client.Connect("192.168.129.21", 110, "report_reader@SPALab.at.local", "Lock12Lock");
            // pop3Client.L
            // Console.WriteLine (pop3Client.MessageCount);
            pop3Client.RetrieveMessage (349);

            var imapClient = new Imap4Client ();
            imapClient.ConnectSsl("imap.gmail.com", 993);
            // imapClient.Login ("report_reader@SPALab.at.local", "Lock12Lock");
            imapClient.Login ("report_reader@SPALab.at.local", "Lock12Lock");

            // var inbox = imapClient.SelectMailbox ("inbox");

            Console.ReadKey ();
        }
    }
}
