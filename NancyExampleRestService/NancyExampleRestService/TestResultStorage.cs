/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/10/2014
 * Time: 6:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using System.Collections.Generic;
	using testInterfaces;
	
	/// <summary>
	/// Description of TestResultStorage.
	/// </summary>
	public class TestResultStorage
	{
		public static List<ITestResult> TestResults { get; set; }
	}
}
