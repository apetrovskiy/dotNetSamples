/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/18/2013
 * Time: 10:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testGenericInnerObjects
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            //Class1<Class2> cl11 = new Class1<Class2>(new Class2());
            //Class1<Class3> cl12 = new Class1<Class3>(new Class3());
            Class1 cl11 = new Class1(new Class2());
            Class1 cl12 = new Class1(new Class3());
            
            Console.WriteLine(cl11.GetNumber<Class2>());
            Console.WriteLine(cl12.GetNumber<Class3>());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}