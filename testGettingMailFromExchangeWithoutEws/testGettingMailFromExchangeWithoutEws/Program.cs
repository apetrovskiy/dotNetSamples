/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 06/07/2015
 * Time: 03:58 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testGettingMailFromExchangeWithoutEws
{
    using System;
    using OpenPop.Mime;
    using OpenPop.Pop3;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var client = new Pop3Client();
            // client.Connect("pop.gmail.com", 995, true);
            client.Connect("192.168.129.3", 143, true);
            client.Authenticate(@"SPANEW\suite_admin", "Lock12Lock");
            var count = client.GetMessageCount();
            Message message = client.GetMessage(count);
            Console.WriteLine(message.Headers.Subject);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}