/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 04/02/2016
 * Time: 12:07 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testFlags
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            const int mask = 01010101;
            const int flag01 = 00000100;
            const int flag02 = 00000000;
            const int flag03 = 00010000;
            
            Console.WriteLine(mask);
            Console.WriteLine("results:");
            
            var mask01 = mask;
            Console.WriteLine("mask &= flag01");
            Console.WriteLine((mask01 &= flag01));
            
            var mask02 = mask;
            Console.WriteLine("mask &= ~flag01");
            Console.WriteLine((mask02 &= ~flag01));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}