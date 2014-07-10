/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/10/2014
 * Time: 6:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestServiceTests
{
	using Nancy;
	using Nancy.Testing;
	using Xunit;
	using NUnit.Framework;
	using Xunit.Sdk;
	
	/// <summary>
	/// Description of TestResultsTestFixture.
	/// </summary>
	public class TestResultsTestFixture
	{
		[Fact][Test]
		public void Should_add_test_result()
		{
			var sut = new Browser(new DefaultNancyBootstrapper());
			
			var testResult = new testInterfaces.TestResult { Id = "111", Name = "aaaa", TestSuiteId = "222", TestScenarioId = "333" };
			var actual = sut.Post("/v1/testresults/", (with) => {
			                      	//with.JsonBody<ITestResult>(testResult, null);
			                      	// with.M
			                      }
			                     );
			
			// Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
			NUnit.Framework.Assert.AreEqual(HttpStatusCode.OK, actual.StatusCode);
			// var testResult = actual.Body.DeserializeJson<ITestResult>();
			// Assert.Equal(1, testResult
		}
	}
}
