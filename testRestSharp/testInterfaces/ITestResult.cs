﻿/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/7/2014
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	/// <summary>
	/// Description of ITestResult.
	/// </summary>
	public interface ITestResult
	{
		string Name { get; set; }
		string Id { get; set; }
		string TestSuiteId { get; set; }
		string TestScenarioId { get; set; }
	}
}