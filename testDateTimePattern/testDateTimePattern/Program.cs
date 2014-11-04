/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 5/19/2014
 * Time: 7:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testDateTimePattern
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			DateTime dateTime = System.DateTime.ParseExact("19/05/2014 18:13:06 PM", "dd/MM/yyyy HH:mm:ss tt", null);
			Console.WriteLine(dateTime);
			
//			DateTime dateTime3 = System.Convert.ToDateTime("19/05/2014 18:13:06 PM",);
//			Console.WriteLine(dateTime3);
			
			Console.WriteLine(Convert.ToDateTime("07:00:00"));
			Console.WriteLine(Convert.ToDateTime("07:00:00").TimeOfDay);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}