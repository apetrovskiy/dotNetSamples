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
			
			
			var client = new RestClient("http://localhost:12345/v1");
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
			
			// ==================================================================================
			
			request = new RestRequest("/somethings/", Method.POST);
			request.AddBody(new Something { Id = 1, Name = "s1", Description = "s001" });
			var smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0001 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/" + smthResponse.Data.Id, Method.GET);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0002 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/", Method.POST);
			request.AddBody(new Something { Id = 100, Name = "s100", Description = "s0010000000", Status = 5 });
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0003 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/" + smthResponse.Data.Id, Method.GET);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0004 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/1", Method.GET);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0005 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/1", Method.PUT);
			smthResponse.Data.Status = 10;
			request.AddBody(smthResponse.Data);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0006 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/1", Method.GET);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0007 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			request = new RestRequest("/somethings/100", Method.GET);
			smthResponse = client.Execute<Something>(request);
			Console.WriteLine("======= 0008 =======");
			Console.WriteLine(smthResponse.Content);
			Console.WriteLine(smthResponse.Data);
			
			// ==================================================================================
			
			// for (int i = 0; i < 1000000; i++) {
			
				request = new RestRequest("/testresults/", Method.POST);
				request.AddBody(new TestResult {
					Name = "test result 2 ...",
					Id = "1112",
					TestScenarioId = "2222",
					TestSuiteId = "3332"
				});
				IRestResponse<TestResult> response2 = client.Execute<TestResult>(request);
				Console.WriteLine(response2.Content);
				
				request = new RestRequest("/testresults/" + response2.Data.Id, Method.GET);
				var testResultResponse = client.Execute<TestResult>(request);
				Console.WriteLine(testResultResponse.Content);
				// var testResult = testResultResponse.Data;
			
				request = new RestRequest("/testsuites/", Method.POST);
				request.AddBody(new TestSuite { Name = "test suite 001", Id = "333" });
				response = client.Execute(request);
				Console.WriteLine("======= 03 =======");
				Console.WriteLine(response.Content);
			
				request = new RestRequest("/testscenarios/", Method.POST);
				request.AddBody(new TestScenario {
					Name = "test scenario 001",
					Id = "222",
					TestSuiteId = "333"
				});
				response = client.Execute(request);
				Console.WriteLine("======= 04 =======");
				Console.WriteLine(response.Content);
				
				request = new RestRequest("testresults/1112?name=testresultname&testsuiteid=8888&testscenarioid=9999", Method.GET);
				response = client.Execute(request);
				Console.WriteLine("======= 05 =======");
				Console.WriteLine(response.Content);
				
				request = new RestRequest("/TestBuckets/freebucket?hostid=w1", Method.GET);
				// request = new RestRequest("/TestBuckets/567?name=ttttt&hostid=w1", Method.GET);
				// IRestResponse<TestBucket> testBucketResponse = client.Execute<TestBucket>(request);
				var testBucketResponse = client.Execute<TestBucket>(request);
				Console.WriteLine("======= 101 =======");
				Console.WriteLine(testBucketResponse.Content);
				var testBucket = testBucketResponse.Data;
//				Console.WriteLine(testBucket.Name);
				Console.WriteLine(testBucket.HostId);
				Console.WriteLine(testBucket.Id);
				
				request = new RestRequest("/TestBuckets/" + testBucket.Id, Method.PUT);
				testBucket.Status = TestBucketStatuses.Accepted;
				Console.WriteLine(testBucket.Status);
				request.AddBody(testBucket);
				testBucketResponse = client.Execute<TestBucket>(request);
				
				request = new RestRequest("/TestBuckets/" + testBucket.Id, Method.GET);
				testBucketResponse = client.Execute<TestBucket>(request);
				Console.WriteLine("======= 102 =======");
				Console.WriteLine(testBucketResponse.Content);
				testBucket = testBucketResponse.Data;
				Console.WriteLine(testBucket.HostId);
				Console.WriteLine(testBucket.Id);
				
				request = new RestRequest("/TestBuckets/" + testBucket.Id, Method.PUT);
				testBucket.Status = TestBucketStatuses.CompletedSuccessfully;
				request.AddBody(testBucket);
				testBucketResponse = client.Execute<TestBucket>(request);
				
				request = new RestRequest("/TestBuckets/" + testBucket.Id, Method.GET);
				testBucketResponse = client.Execute<TestBucket>(request);
				Console.WriteLine("======= 103 =======");
				Console.WriteLine(testBucketResponse.Content);
				testBucket = testBucketResponse.Data;
				Console.WriteLine(testBucket.HostId);
				Console.WriteLine(testBucket.Id);
				
			// }
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}