/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/22/2015
 * Time: 8:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStringSplitter
{
    class Program
    {
        public static void Main(string[] args)
        {
            var data = @"aaa
            bbb
            ccc
            ddd
            eee
            
            fff
            ggg";
            var array = data.Split('\r');
            Console.WriteLine(array.Length);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}