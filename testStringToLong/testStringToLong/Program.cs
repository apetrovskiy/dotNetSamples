/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 18/07/2015
 * Time: 09:21 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStringToLong
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Console.WriteLine(new DateTime(long.Parse("130817124710000006")));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}