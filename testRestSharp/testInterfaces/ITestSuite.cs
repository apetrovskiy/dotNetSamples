/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/7/2014
 * Time: 7:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace testInterfaces
{
	/// <summary>
	/// Description of ITestSuite.
	/// </summary>
	public interface ITestSuite
	{
		string Name { get; set; }
		string Id { get; set; }
	}
}
