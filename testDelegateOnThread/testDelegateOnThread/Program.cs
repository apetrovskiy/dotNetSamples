/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 8/5/2014
 * Time: 11:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testDelegateOnThread
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			var someClass = new SomeClass();
			someClass.DoBackgroundWork();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}