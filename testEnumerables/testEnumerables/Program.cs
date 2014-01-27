/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 1/27/2014
 * Time: 12:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testEnumerables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            string[] outer = { "aaaa", "bbbb", "cccc" };
            string[] inner = { "aaaa", "bbbb", "cccc" };
            
            foreach (var outerElement in outer) {
                bool matchFound = false;
                foreach (var innerElement in inner) {
                    Console.WriteLine("outer = {0}, inner = {1}", outerElement, innerElement);
                    if (innerElement == outerElement) {
                        Console.WriteLine("OK");
                        matchFound = true;
                        break;
                    }
                }
                if (matchFound) break;
            }
            
            if (outer.All(x => inner.Contains(x))) {
                Console.WriteLine("there is global match");
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}