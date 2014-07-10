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
	using System.IO;
	using System.Windows.Forms;
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
            Get["/{id}/{name}/{status}"] = parameter => {
                var result = new { Id = parameter.id, Name = parameter.name, Status = parameter.status };
                return Response.AsJson(result).WithStatusCode(HttpStatusCode.OK);
            };
            
            Get["/testresults/{id}"] = parameter => {
                var testResult = this.Bind<TestResult>();
				testResult.Name += " processed (get).";
				return Response.AsJson<ITestResult>(testResult, HttpStatusCode.OK);
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
				var testResult = this.Bind<TestResult>();
				testResult.Name += " processed (post).";
				return Response.AsJson<ITestResult>(testResult, HttpStatusCode.OK);
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
