/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 03/02/2016
 * Time: 11:53 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testStringData
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var data = "print {0} print {0}";
            Console.WriteLine(string.Format(data, "aaa"));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}