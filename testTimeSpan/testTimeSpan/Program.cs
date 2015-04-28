/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/24/2015
 * Time: 2:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testTimeSpan
{
	using System;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			var span01 = new TimeSpan();
			var span02 = new TimeSpan(1, 1, 1);
			var span03 = TimeSpan.FromMilliseconds(111111111);
			// TimeSpan.FromSeconds(spn02);
			Console.WriteLine(span01);
			Console.WriteLine(span02);
			Console.WriteLine(span03);
			Console.WriteLine(span03 + TimeSpan.FromMilliseconds(1000 - span03.Milliseconds));
			Console.WriteLine(span03.TotalHours + " " + span03.TotalMinutes + " " + span03.TotalSeconds);
			Console.WriteLine(string.Format("{0:00}:{0:00}:{1:00}", span03.TotalHours % 60, span03.TotalMinutes % 60, span03.TotalSeconds % 60));
			Console.WriteLine(string.Format("{0:00}:{0:00}:{1:00}", span03.TotalHours % 60, span03.TotalMinutes % 60));
			Console.WriteLine(string.Format("{0:00}:{0:00}:{0:00}", span03.TotalHours % 60, span03.TotalMinutes % 60));
			Console.WriteLine(string.Format("{0:00}:{1:00}:{2:00}", span03.TotalHours % 60, span03.TotalMinutes % 60, span03.TotalSeconds % 60));
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}