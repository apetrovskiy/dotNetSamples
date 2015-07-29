/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 20/07/2015
 * Time: 08:45 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testTimeConversion
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var timeString = @"130817931690000000";
            // Console.WriteLine(DateTime.Parse(timeString));
            // Console.WriteLine(new DateTime(timeString));
            // Console.WriteLine(new DateTime(long.Parse(timeString)));
            // Console.WriteLine(new TimeSpan(long.Parse(timeString)));
            var dateFromString = new DateTime(long.Parse(timeString));
            var spanFromString = new TimeSpan(long.Parse(timeString));
            var newDateFromString = new DateTime(DateTime.Now.Year, dateFromString.Month, dateFromString.Day, dateFromString.Hour, dateFromString.Minute, dateFromString.Second);
            Console.WriteLine(newDateFromString); // the best
            
            Console.WriteLine(dateFromString);
            // Console.WriteLine(dateFromString.ToUniversalTime());
            Console.WriteLine(dateFromString.Year);
            
            Console.WriteLine(spanFromString);
            Console.WriteLine(spanFromString.Days / 365);
            Console.WriteLine(spanFromString.Days % 365);
            
            Console.WriteLine("=================================================================================");
            var nowDate = DateTime.Now;
            Console.WriteLine(nowDate);
            Console.WriteLine(nowDate.Ticks);
            Console.WriteLine(nowDate.ToUniversalTime());
            
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}