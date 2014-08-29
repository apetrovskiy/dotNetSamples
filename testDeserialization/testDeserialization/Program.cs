/*
 * Created by SharpDevelop.
 * User: shuran
 * Date: 8/29/2014
 * Time: 11:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy.Hosting.Self;

namespace testDeserialization
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			var host = new NancyHost(new Uri[] { new Uri("http://localhost:12340") });
			host.Start();
			Console.WriteLine("server has started");
			
			Console.WriteLine("Press any key to stop the server . . . ");
			Console.ReadKey(true);
			host.Stop();
			Console.WriteLine("server has been stopped");
		}
	}
}