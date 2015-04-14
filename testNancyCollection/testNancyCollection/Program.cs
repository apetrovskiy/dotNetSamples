/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 14/04/2015
 * Time: 08:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNancyCollection
{
    using System;
    using Nancy.Diagnostics;
    using Nancy.Hosting.Self;
    using test.Interfaces;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var host = new NancyHost(new Uri(Constants.BaseUrl));
            // DiagnosticsHook.Disable();
            host.Start();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}