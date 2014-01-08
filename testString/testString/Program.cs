/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/5/2014
 * Time: 8:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testString
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            string s = string.Empty;
            
            switch (s.ToUpper()) {
                case "TRUE":
                    Console.WriteLine("$true");
                    break;
                case "FALSE":
                    Console.WriteLine("$false");
                    break;
                case "":
                    Console.WriteLine("''");
                    break;
                default:
                    Console.WriteLine("default");
                	break;
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}