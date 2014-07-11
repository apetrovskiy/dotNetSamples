/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/7/2014
 * Time: 7:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testInterfaces
{
	/// <summary>
	/// Description of TestSuite.
	/// </summary>
	public class TestSuite : ITestSuite
	{
		public string Name { get; set; }
		public string Id { get; set; }
	}
}
