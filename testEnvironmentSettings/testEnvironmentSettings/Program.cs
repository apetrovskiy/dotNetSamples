/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/17/2014
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testEnvironmentSettings
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			Console.WriteLine(Environment.TickCount);
			Console.WriteLine(Environment.MachineName);
			Console.WriteLine(Environment.OSVersion);
			Console.WriteLine(Environment.UserDomainName);
			Console.WriteLine(Environment.UserInteractive);
			Console.WriteLine(Environment.UserName);
			Console.WriteLine(Environment.Version);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}