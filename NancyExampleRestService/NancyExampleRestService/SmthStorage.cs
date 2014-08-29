/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/11/2014
 * Time: 2:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using System.Collections.Generic;
	using testInterfaces;
	
	/// <summary>
	/// Description of SmthStorage.
	/// </summary>
	public static class SmthStorage
	{
		public static List<ISomething> Somethings { get; set; }
		
		static SmthStorage()
		{
			Somethings = new List<ISomething>();
		}
	}
}
