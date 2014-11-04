/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 2/20/2014
 * Time: 6:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testInheritanceWithIfaces
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			var baseClassObject = new BaseClass();
			baseClassObject.InterfaceMethod();
			
			var childClassObject = new ChildClass();
			childClassObject.InterfaceMethod();
			
			var oneMoreChild = new ChildClass();
			var ifaceObject = oneMoreChild as ITest;
			ifaceObject.InterfaceMethod();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}