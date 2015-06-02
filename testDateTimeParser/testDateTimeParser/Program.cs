/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 29/05/2015
 * Time: 10:06 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace testDateTimeParser
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var dateString = "04/13/2015 00:01:33";
            var dateFormat = "MM/dd/yyyy HH:mm:ss";
            
            try {
                // Console.WriteLine(DateTime.Parse(dateString, new provider
                // Console.WriteLine(DateTime.Parse(dateString));
                // Console.WriteLine(DateTime.ParseExact(dateString, dateFormat, null));
                Console.WriteLine(DateTime.ParseExact(dateString, dateFormat, new CultureInfo("en-US"), DateTimeStyles.None));
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}