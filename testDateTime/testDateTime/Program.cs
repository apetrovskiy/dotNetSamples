/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/9/2014
 * Time: 3:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testDateTime
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            var dateTimeAsString = "2014-11-08T15:36:44.4134433-08:00";
            var dateTime = Convert.ToDateTime(dateTimeAsString);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}