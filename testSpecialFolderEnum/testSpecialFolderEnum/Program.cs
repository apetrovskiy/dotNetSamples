/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 5/20/2014
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testSpecialFolderEnum
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
//			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
//			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles));
//			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
//			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
//			Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Programs));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}