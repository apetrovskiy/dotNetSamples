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
	/// Description of testBucket.
	/// </summary>
	public class TestBucket : ITestBucket
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ITestBucketAction[] Action { get; set; }
		public string[] ExpectedResult { get; set; }
		public int ExecutionType { get; set; }
		public bool Active { get; set; }
		public string HostId { get; set; }
		// public int Status { get; set; }
		// public bool Accepted { get; set; }
		public TestBucketStatuses Status { get; set; }
	}
}
