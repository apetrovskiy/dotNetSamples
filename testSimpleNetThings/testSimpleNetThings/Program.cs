/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/22/2014
 * Time: 7:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSimpleNetThings
{
	using System;
	using System.IO;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			string tempFile = Path.GetTempFileName();
			// Path.
			Console.WriteLine(tempFile);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}