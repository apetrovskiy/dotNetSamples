/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 10/25/2014
 * Time: 10:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNancyDotLiquid
{
	using System;
	using Nancy.Hosting.Self;
	using Nancy.ViewEngines.DotLiquid;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			var host = new NancyHost(new Uri(@"http://localhost:12340"));
			host.Start();
			
			// TODO: Implement Functionality Here
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}