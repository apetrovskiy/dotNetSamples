/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/1/2014
 * Time: 4:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample10
{
	using System;
	using Microsoft.Owin.Hosting;
	
	class Program
	{
		public static void Main(string[] args)
		{
			// var url = "http://+:8080";
			var url = "http://+:44444";
			
			using (WebApp.Start<Startup>(url))
			{
				var carModule = new CarModule(new CarRepository());
//				carModule.Get["/status"] = _ => "Hello World";
				
				Console.WriteLine("Running on {0}", url);
				Console.WriteLine("Press enter to exit");
				Console.ReadLine();
			}
		}
	}
}