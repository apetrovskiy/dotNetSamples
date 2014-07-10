/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/10/2014
 * Time: 3:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using System.Collections.Generic;
	using testInterfaces;
	
	/// <summary>
	/// Description of TestBucketsStorage.
	/// </summary>
	public class TestBucketsStorage
	{
		public static List<ITestBucket> TestBuckets { get; set; }
	}
}
