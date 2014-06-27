/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 6/20/2014
 * Time: 9:26 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenFact
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var g = new Bag<Gucci>();
            Console.WriteLine(g.Price);
            
            var p = new Bag<Poochy>();
            Console.WriteLine(p.Price);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}