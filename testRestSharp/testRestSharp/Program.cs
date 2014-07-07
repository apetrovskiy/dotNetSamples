/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/7/2014
 * Time: 7:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testRestSharp
{
	using System;
	using RestSharp;
	using testInterfaces;
	
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
			
			
			var client = new RestClient("http://localhost:12345");
			// var request = new RestRequest("resource/{id}", Method.POST);
			var request = new RestRequest("/testresults/", Method.POST);
			// request.AddParameter("name", "value");
			// request.AddUrlSegment("id", 123.ToString());
			request.AddHeader("header", "value");
			request.AddBody(new TestResult { Name = "test result ...", Id = "111", TestScenarioId = "222", TestSuiteId = "333" });
			// request.AddFile(path);
			var response = client.Execute(request);
			var content = response.Content;
			Console.WriteLine(content);
			
			IRestResponse<TestResult> response2 = client.Execute<TestResult>(request);
			Console.WriteLine(response2.Content);
			// var name = response2.Data.Name;
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}