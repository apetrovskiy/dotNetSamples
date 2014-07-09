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
			if (null == response)
				Console.WriteLine("null == response");
			if (null == response.Content)
				Console.WriteLine("null == response.Content");
			Console.WriteLine(response.StatusCode);
			if (0 == response.StatusCode)
				return;
			var content = response.Content;
			Console.WriteLine("======= 01 =======");
			Console.WriteLine(content);
			Console.WriteLine("======= 02 =======");
			
			request = new RestRequest("/testresults/", Method.POST);
			request.AddBody(new TestResult { Name = "test result 2 ...", Id = "1112", TestScenarioId = "2222", TestSuiteId = "3332" });
			IRestResponse<TestResult> response2 = client.Execute<TestResult>(request);
			Console.WriteLine(response2.Content);
			// var name = response2.Data.Name;
			
			request = new RestRequest("/testresults/suites/", Method.POST);
			request.AddBody(new TestSuite { Name = "test suite 001", Id = "333" });
			response = client.Execute(request);
			Console.WriteLine("======= 03 =======");
			Console.WriteLine(response.Content);
			
			request = new RestRequest("/testresults/scenarios/", Method.POST);
			request.AddBody(new TestScenario { Name = "test scenario 001", Id = "222", TestSuiteId = "333" });
			response = client.Execute(request);
			Console.WriteLine("======= 04 =======");
			Console.WriteLine(response.Content);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}