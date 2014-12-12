/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/12/2014
 * Time: 6:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStringInit
{
    class Program
    {
        public static void Main(string[] args)
        {
            var cl1 = new Class1();
            Console.WriteLine(null == cl1.StringData);
            Console.WriteLine(string.IsNullOrEmpty(cl1.StringData));
            Console.WriteLine(string.Empty == cl1.StringData);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}