/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/2/2013
<<<<<<< HEAD
 * Time: 12:30 PM
=======
 * Time: 12:42 AM
>>>>>>> dd5f22f2ccb47763b46c04e33710fe0afc8c9f63
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NSubstitute;
using System.Windows.Automation;

namespace testNSub
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			//AutomationElement ae = new AutomationElement();
			
			Class2 if2 = NSubstitute.Substitute.For<Class2>();
			if2.Register();
			//Interface2 if2 = NSubstitute.Substitute.For<Interface2>();
			Class1 cl1 = new Class1(if2);
			Interface2 if2returned = cl1.GetInternalObject();
			Console.WriteLine(if2returned.IsRegistered);
			Console.WriteLine(if2.Received().IsRegistered);
			
			Class4 cl4 = new Class4();
			cl4.GetManyElements();
			
			//System.Windows.Automation.IAutomationElement
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}