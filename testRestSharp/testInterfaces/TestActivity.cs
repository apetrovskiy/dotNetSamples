/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 7/10/2014
 * Time: 6:13 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testInterfaces
{
	using System;
	
	/// <summary>
	/// Description of TestActivity.
	/// </summary>
	public class TestActivity : ITestActivity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ITestActivityAction[] Action { get; set; }
		public string[] ExpectedResult { get; set; }
		public int ExecutionType { get; set; }
		public bool On { get; set; }
		public string HostId { get; set; }
		public TestActivityStatuses Status { get; set; }
		public int Timeout { get; set; }
		public int Retry { get; set; }
		public bool IsCritical { get; set; }
		public int Order { get; set; }
		public TestActivityTypes ActivityType { get; set; }
	}
}
