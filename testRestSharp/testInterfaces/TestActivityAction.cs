/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 6:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	using System;
	using System.Collections.Generic;
	
	/// <summary>
	/// Description of TestActivityAction.
	/// </summary>
	public class TestActivityAction : ITestActivityAction
	{
		public string Code { get; set; }
		public Dictionary<string, object> Parameters { get; set; }
	}
}
