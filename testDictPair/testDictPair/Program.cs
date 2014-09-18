/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 9/18/2014
 * Time: 4:09 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace testDictPair
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var dict = new Dictionary<string, string>();
            dict.Add("aaa", "bbb");
            foreach (var element in dict.Keys) {
                Console.WriteLine(element);
                Console.WriteLine(element.GetType().Name);
                Console.WriteLine(dict[element]);
            }
            foreach (var element in dict) {
                Console.WriteLine(element);
                Console.WriteLine(element.GetType().Name);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}