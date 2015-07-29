/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 18/07/2015
 * Time: 04:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testDateTimeDifference
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var currentDate = DateTime.Now;
            var pastDate = currentDate - new TimeSpan(10000000 * 10);
            Console.WriteLine(currentDate);
            Console.WriteLine(pastDate);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}