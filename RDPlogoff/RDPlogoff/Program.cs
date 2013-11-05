/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/20/2013
 * Time: 5:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace RDPlogoff
{
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            //System.IntPtr handleServer = NativeMethods.WTSOpenServer("10.0.0.237");
            System.IntPtr handleServer = NativeMethods.WTSOpenServer("10.0.1.214");
            Console.WriteLine(handleServer.ToInt32().ToString());
            
            bool result = NativeMethods.WTSLogoffSession(handleServer, 2, true);
            Console.WriteLine(result.ToString());
            
            List<string> list = new List<string>();
            Console.WriteLine("enumerating sessions...");
            Console.WriteLine("10.0.1.214");
            //NativeMethods.WTSEnumerateSessions(handleServer, null, 0, 
            //TSManager tsm = new TSManager();
            handleServer = TSManager.OpenServer("10.0.1.214");
            list = TSManager.ListSessions("10.0.1.214");
            foreach (string session in list) {
                Console.WriteLine(session);
            }
            Console.WriteLine("=============================================");
            
            Console.WriteLine("10.0.1.143");
            handleServer = TSManager.OpenServer("10.0.1.143");
            list = TSManager.ListSessions("10.0.1.143");
            foreach (string session in list) {
                Console.WriteLine(session);
            }
            Console.WriteLine("=============================================");
            
            Console.WriteLine("10.0.0.237");
            handleServer = TSManager.OpenServer("10.0.0.237");
            list = TSManager.ListSessions("10.0.0.237");
            foreach (string session in list) {
                Console.WriteLine(session);
            }
            Console.WriteLine("=============================================");
            
            Console.WriteLine("10.0.1.81");
            handleServer = TSManager.OpenServer("10.0.1.81");
            list = TSManager.ListSessions("10.0.1.81");
            foreach (string session in list) {
                Console.WriteLine(session);
            }
            Console.WriteLine("=============================================");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}