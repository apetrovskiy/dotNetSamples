/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 13/08/2015
 * Time: 09:15 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testConstructorsChain
{
    using System;
    
    class Program
    {
        public static void Main(string[] args)
        {
            var child = new SomeImpl02();
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}