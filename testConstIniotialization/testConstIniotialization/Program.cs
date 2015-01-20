/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/20/2015
 * Time: 10:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testConstIniotialization
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var test = new Class1 {
                // Data01 = "1",
                // Data02 = "2",
                Data03 = "3",
                Data04 = "4"
            };
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}