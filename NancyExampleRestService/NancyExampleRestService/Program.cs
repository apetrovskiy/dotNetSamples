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
	using System.Collections.Generic;
	using Nancy.Hosting.Self;
	using testInterfaces;
	
	class Program
	{
		// const string url = "http://localhost:12345";
		const string url = "http://localhost:13001";
		
		public static void Main(string[] args)
		{
			// preparation of data
			TestBucketsStorage.TestBuckets =
				new List<ITestActivity> {
				new TestActivity {
					Id = 123,
					Name = "bucket 01",
					HostId = "w2"
				},
				new TestActivity {
					Id = 567,
					Name = "bucket 02",
					HostId = "W1"
					// HostId = "w1"
				},
				new TestActivity {
					Id = 789,
					Name = "bucket 03",
					HostId = "w3"
				}
			};
			
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