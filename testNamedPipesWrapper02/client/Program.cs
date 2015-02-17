/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/02/2015
 * Time: 05:13 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace client
{
    using System;
    using NamedPipeWrapper;
    using interfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var client = new NamedPipeClient<ISomething>("MyServerPipe");
            client.ServerMessage += (conn, message) => Console.WriteLine("Server says: {0}", message.Name);
            client.Error += exception => Console.WriteLine(exception.Message);

            // Start up the client asynchronously and connect to the specified server pipe.
            // This method will return immediately while the client runs in a separate background thread.
            client.Start();
            /*
            client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
            client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
            client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
            client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
            */
            /*
            while (KeepRunning)
            {
                // Do nothing - wait for user to press 'q' key

                client.PushMessage(new Something { Id = 5, Name = "aaaaaaaaaaaaaaaaaaaa" });
                client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
                System.Threading.Thread.Sleep(1000);
            }
            */
            while (true)
            {
                client.PushMessage(new Something { Id = new Random().Next(), Name = "aaaaaaaaaaaaaaaaaaaa" });
                System.Threading.Thread.Sleep(1000);
            }

            client.Stop();
            // client.PushMessage(new Something { Id = 5, Name = "aaaaaaaaaaaaaaaaaaaa" });

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        static bool KeepRunning
        {
            get
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                    return false;
                return true;
            }
        }
    }
}