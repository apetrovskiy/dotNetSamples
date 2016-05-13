/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 11/04/2016
 * Time: 08:12 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testHexConversion
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            int a = 12000;
            int b = 0x2ee0;
            // a == b;
            // You can convert from the string "12000" to an int using int.Parse(). You can format an int as hex with int.ToString("X").
            Console.WriteLine(a.ToString("X"));
            Console.WriteLine(b.ToString("X"));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}