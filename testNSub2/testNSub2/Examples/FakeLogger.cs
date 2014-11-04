/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/15/2013
 * Time: 6:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub2
{
	using System;

	/// <summary>
	/// Description of FakeLogger.
	/// </summary>
	public class FakeLogger : ILogger
	{
		public string LastError;
		public void LogError(string message)
		{
		    Console.WriteLine(message);
			LastError = message;
		}
		public string LogError2(string message)
		{
		    Console.WriteLine(message);
			LastError = message;
			return message + "+";
		}
	}
}
