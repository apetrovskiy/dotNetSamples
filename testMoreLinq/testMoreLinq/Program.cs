/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/23/2014
 * Time: 7:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testMoreLinq
{
    using System;
    using MoreLinq;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            int[] iArray = { 1, 2, 3 };
            foreach (var element in iArray.Prepend(0).Prepend(5)) {
                Console.WriteLine(element);
            }
            Console.WriteLine("===================================================");
            iArray.ForEach(i => i++);
            foreach (var element in iArray) {
                Console.WriteLine(element);
            }
            Console.WriteLine("===================================================");
            foreach (var element in iArray.Prepend(0).Prepend(5).TakeEvery(2)) {
                Console.WriteLine(element);
            }
            Console.WriteLine("===================================================");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}