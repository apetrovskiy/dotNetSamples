/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/02/2015
 * Time: 05:06 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNamedPipesWrapper02
{
    using System;
    using NamedPipeWrapper;
    using interfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var server = new NamedPipeServer<ISomething>("MyServerPipe");
            server.ClientConnected += conn =>
            {
                Console.WriteLine("Client {0} is now connected!", conn.Id);
                conn.PushMessage(new Something {Id = new Random().Next(), Name = "Welcome!"});
            };
            server.ClientMessage += (conn, message) => Console.WriteLine("Client {0} says: {1}", conn.Id, message.Name);
            server.Error += exception => Console.WriteLine(exception.Message);

            // Start up the server asynchronously and begin listening for connections.
            // This method will return immediately while the server runs in a separate background thread.
            server.Start();
            while (KeepRunning)
            {
                // Do nothing - wait for user to press 'q' key
            }
            server.Stop();

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