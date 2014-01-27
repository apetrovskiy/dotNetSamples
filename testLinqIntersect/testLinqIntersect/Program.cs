/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 1/27/2014
 * Time: 4:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testLinqIntersect
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
            
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 }; 
            int[] numbersB = { 1, 3, 5, 7, 8 }; 
            
            var commonNumbers = numbersA.Intersect(numbersB); 
            
            Console.WriteLine("Common numbers shared by both arrays:"); 
            foreach (var n in commonNumbers) 
            { 
                Console.WriteLine(n); 
            } 
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}