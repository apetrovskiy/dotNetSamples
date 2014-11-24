/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/24/2014
 * Time: 6:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testMailReader02
{
    using System;
    using OpenPop.Pop3;
    using OpenPop.Common.Logging;
    using OpenPop.Mime;
    using OpenPop.Pop3.Exceptions;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new OpenPop.Pop3.Pop3Client();
            // client.Connect("pop.gmail.com", 995, true);
            client.Connect("192.168.129.21", 110, false);
            client.Authenticate("report_reader@SPALab.at.local", "Lock12Lock", AuthenticationMethod.Auto);
            var count = client.GetMessageCount();
            Console.WriteLine(count);
//            Message message = client.GetMessage(count);
//            Console.WriteLine(message.Headers.Subject);
            
            var list = client.GetMessageInfos();
            Console.WriteLine(list.Count);
            Console.ReadKey(true);
            foreach (var message in list) {
                Console.WriteLine(message.Identifier + " " + message.Number + " " + message.Size);
            }

            var pop3Client = new Pop3Client ();
            // pop3Client.ConnectSsl("pop.gmail.com", 995, "admin@bendytree.com", "YourPasswordHere");
//            pop3Client.Connect("192.168.129.21", 110, "report_reader@SPALab.at.local", "Lock12Lock");
//            // pop3Client.L
//            // Console.WriteLine (pop3Client.MessageCount);
//            pop3Client.RetrieveMessage (1);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}