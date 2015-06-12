/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 09/06/2015
 * Time: 06:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testIfExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var aaa = (if (1) { 1; });
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}