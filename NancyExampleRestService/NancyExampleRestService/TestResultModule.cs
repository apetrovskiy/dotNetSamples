/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/4/2014
 * Time: 11:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
    using System;
    using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using testInterfaces;
    
    /// <summary>
    /// Description of TestResultModule.
    /// </summary>
    public class TestResultModule : NancyModule
    {
        public TestResultModule() : base("/v1")
        {
            // Get["/{id}/{name}/{status}"] = parameter => { return GetTestResult(parameter.id, parameter.name, parameter.status); };
            Get["/{id}/{name}/{status}"] = parameters => {
                var result = new { Id = parameters.id, Name = parameters.name, Status = parameters.status };
                return Response.AsJson(result).WithStatusCode(HttpStatusCode.OK);
            };
            
            Get["/testresults/{id}"] = parameters => {
                var testResult = this.Bind<TestResult>();
				// testResult.Name += " processed (get).";
				var testResultInStorage = TestResultStorage.TestResults.First(tr => tr.Id == testResult.Id);
				// testResultInStorage.Name += " processed (get).";
				// return Response.AsJson<ITestResult>(testResult, HttpStatusCode.OK);
				return Response.AsJson<ITestResult>(testResultInStorage, HttpStatusCode.OK);
            };
            
//            Post["/{id}/{name}/{status}"] = parameter => {
//                var result = new { Id = parameter.id, Name = parameter.name, Status = parameter.status };
//                return Response.AsJson(result).WithStatusCode(HttpStatusCode.OK); 
//            };
            
            // Post["/"] = pa
            // this.Request.Body
            //             Post["/rel"] = parameters => new StreamReader(this.Request.Body).ReadToEnd();
            // Request.Body.
            
			Post["/TestResults/"] = _ => {
            	try { var testResult = this.Bind<TestResult>();
				testResult.Name += " processed (post).";
				TestResultStorage.TestResults.Add(testResult);
				return Response.AsJson<ITestResult>(testResult, HttpStatusCode.OK);
				} catch (Exception e) { throw new Exception("getting the test result supplied. " + e.Message); }
			};
            
            Post["/TestSuites/"] = _ => {
                var testSuite = this.Bind<TestSuite>();
                testSuite.Name += " processed (post). ";
                return Response.AsJson<ITestSuite>(testSuite, HttpStatusCode.OK);
            };
            
            Post["/TestScenarios/"] = _ => {
                var testScenario = this.Bind<TestScenario>();
                testScenario.Name += " processed (post).";
                return Response.AsJson<ITestScenario>(testScenario, HttpStatusCode.OK);
            };
        }
    }
}
