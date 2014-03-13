/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/13/2014
 * Time: 10:05 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NSubstitute;

namespace testNSubProxyExtensionMethods
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            var class01_01 = Substitute.For<Class01,IIface02>();
            var child01_01 = Substitute.For<IChild>();
            child01_01.Name.Returns("name 1");
            // class01_01.ChildObject.Returns(child01_01);
            // class01_01.ChildObject = child01_01;
            class01_01.ChildObject.Returns<IChild>(child01_01);
            
            
            Console.WriteLine(class01_01.ChildObject.Name);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}