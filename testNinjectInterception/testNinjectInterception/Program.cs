/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using Ninject;
	using Ninject.Extensions.Interception.Advice;
	
	class Program
	{
		public static void Main(string[] args)
		{
			// http://stackoverflow.com/questions/9988204/cant-get-ninject-extensions-interception-working
			
			IAdviceFactory aaa = new AdviceFactory();
			Console.WriteLine("Hello World!");
			
			var app = new AppConfiguration();
			var kernel = app.Kernel; // new StandardKernel(new MyModule());
			
			var myClass = kernel.Get<MyClass>();
			myClass.Test01();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}