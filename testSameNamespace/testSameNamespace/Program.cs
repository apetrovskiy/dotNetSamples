/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/6/2014
 * Time: 12:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSameNamespace
{
    extern alias a1;
    extern alias a2;
    using System;
    using a01 = a1::Same.Namespace;
    using a02 = a2::Same.Namespace;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var element01 = new a1::Same.Namespace.Element();
            Console.WriteLine(element01.GetValue().ToString());
            
            var element02 = new a2::Same.Namespace.Element();
            Console.WriteLine(element02.GetValue().ToString());
            
            var element03 = new a01.Element();
            Console.WriteLine(element03.GetValue().ToString());
            
            var element04 = new a02.Element();
            Console.WriteLine(element04.GetValue().ToString());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}