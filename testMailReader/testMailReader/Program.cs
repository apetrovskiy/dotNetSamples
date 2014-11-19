using OpenPop.Pop3;
using OpenPop.Common.Logging;
using OpenPop.Mime;
using OpenPop.Pop3.Exceptions;

namespace testMailReader
{
    using System;
    using ActiveUp.Net.Imap4;
    using ActiveUp.Net.Mail;

    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine ("Hello World!");
            
            var client = new OpenPop.Pop3.Pop3Client();
            // client.Connect("pop.gmail.com", 995, true);
            client.Connect("192.168.129.21", 25, false);
            client.Authenticate("report_reader@SPALab.at.local", "Lock12Lock", AuthenticationMethod.Auto);
            var count = client.GetMessageCount();
//            Message message = client.GetMessage(count);
//            Console.WriteLine(message.Headers.Subject);
            

            var pop3Client = new Pop3Client ();
            // pop3Client.ConnectSsl("pop.gmail.com", 995, "admin@bendytree.com", "YourPasswordHere");
            pop3Client.Connect("192.168.129.21", 25, "report_reader@SPALab.at.local", "Lock12Lock");
            // pop3Client.L
            // Console.WriteLine (pop3Client.MessageCount);
            pop3Client.RetrieveMessage (1);

            var imapClient = new Imap4Client ();
            imapClient.ConnectSsl("imap.gmail.com", 993);
            imapClient.Login ("report_reader@SPALab.at.local", "Lock12Lock");

            // var inbox = imapClient.SelectMailbox ("inbox");

            Console.ReadKey ();
        }
    }
}
