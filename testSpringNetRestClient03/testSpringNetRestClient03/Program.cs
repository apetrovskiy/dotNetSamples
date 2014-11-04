/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 8/20/2014
 * Time: 10:38 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testSpringNetRestClient03
{
	using System;
	using System.Collections.Generic;
	using Spring.Http.Converters.Json;
	using Spring.Rest.Client;
	using Tmx.Interfaces.Remoting;
	using Tmx.Interfaces.Types.Remoting;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			// using variable length arguments
			// string result = restTemplate.GetForObject<string>("http://example.com/hotels/{hotel}/bookings/{booking}", 42, 21);
			
			var restTemplate = new RestTemplate(); //(@"http://localhost:12340/tasks");
			restTemplate.MessageConverters.Add(new DataContractJsonHttpMessageConverter());
			
			// using a IDictionary<string, object>
//			IDictionary<string, object> vars = new Dictionary<string, object>(1);
//			vars.Add("hotel", 42);
//			string result = restTemplate.GetForObject<string>("http://example.com/hotels/{hotel}/rooms/{hotel}", vars);
			// var result = restTemplate.GetForObject<TestTask>(@"http://localhost:12340/tasks/1");
			ITestTask result = restTemplate.GetForObject<TestTask>(@"http://localhost:12340/tasks/1");
			// Console.WriteLine(result);
			Console.WriteLine(result.Name);
			Console.WriteLine(result.Id);
			Console.WriteLine(result.Action);
			Console.WriteLine(result.ActionParameters);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}