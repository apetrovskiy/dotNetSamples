/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/3/2014
 * Time: 1:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using Nancy.Hosting.Self;
	
	class Program
	{
		const string url = "http://localhost:12345";
		
		public static void Main(string[] args)
		{
			// create a new self-host server
			var nancyHost = new NancyHost(new Uri(url));
			// start
			nancyHost.Start();
			Console.WriteLine("REST service listening on " + url);
			//stop with an <Enter> key press
			Console.ReadLine();
			nancyHost.Stop();
		}
	}
}