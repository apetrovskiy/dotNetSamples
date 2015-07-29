/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 20/07/2015
 * Time: 11:55 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testStringComparison
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var string01 = "aaabbb";
            var string02 = "aaabbb";
            var string03 = "aaa";
            var string04 = "aaabbbccc";
            Console.WriteLine(string.Compare(string01, string02, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Compare(string01, string03, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Compare(string01, string04, StringComparison.OrdinalIgnoreCase));
            
            Console.WriteLine(string.Compare(string03, string01, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Compare(string04, string01, StringComparison.OrdinalIgnoreCase));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}