/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/22/2013
 * Time: 1:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testStatic
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            Class1 cl11 = new Class1();
            Console.WriteLine(cl11.GetValue().ToString());
            Class1.SetOn(true);
            Class1 cl12 = new Class1();
            Console.WriteLine(cl12.GetValue().ToString());
            Console.WriteLine(cl11.GetValue().ToString());
            Console.WriteLine("=============================================");
            
            Class2 cl21 = new Class2();
            Console.WriteLine(cl21.GetValue().ToString());
            Class2.SetOn(true);
            Class2 cl22 = new Class2();
            Console.WriteLine(cl22.GetValue().ToString());
            Console.WriteLine(cl21.GetValue().ToString());
            Console.WriteLine("=============================================");
            
            Class3 cl31 = new Class3();
            Console.WriteLine(cl31.GetValue().ToString());
            Class3.SetOn(true);
            Class3 cl32 = new Class3();
            Console.WriteLine(cl32.GetValue().ToString());
            Console.WriteLine(cl31.GetValue().ToString());
            Console.WriteLine("=============================================");
            
            Class4 cl41 = new Class4();
            Console.WriteLine(cl41.GetValue().ToString());
            Class4.SetOn(true);
            Class4 cl42 = new Class4();
            Console.WriteLine(cl42.GetValue().ToString());
            Console.WriteLine(cl41.GetValue().ToString());
            Console.WriteLine("=============================================");
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}