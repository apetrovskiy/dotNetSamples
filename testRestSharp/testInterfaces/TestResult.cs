/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/7/2014
 * Time: 7:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testInterfaces
{
	/// <summary>
	/// Description of TestResult.
	/// </summary>
	public class TestResult : ITestResult
	{
		public string Name { get; set; }
		public string Id { get; set; }
		public string TestSuiteId { get; set; }
		public string TestScenarioId { get; set; }
	}
}
