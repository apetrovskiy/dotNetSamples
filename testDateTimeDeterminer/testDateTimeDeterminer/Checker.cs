/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 31/03/2015
 * Time: 04:01 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
namespace testDateTimeDeterminer
{
    using System;
    using Xunit;
    using Xunit.Sdk;

	/// <summary>
    /// Description of Checker.
    /// </summary>
    public class Checker
    {
	    TimeOperations _timeOps;

	    public Checker()
	    {
		    _timeOps = new TimeOperations();
	    }

        public void Run()
        {
	        var timeOps = new TimeOperations();

			// a not started test run
	        ProcessTest(DateTime.MinValue, new DateTime(), new DateTime(2000, 1, 1, 10, 10, 10), "00:00:00");
			ProcessTest(DateTime.MinValue, new DateTime(), new DateTime(1800, 12, 31, 23, 59, 59), "00:00:00");
			ProcessTest(DateTime.MinValue, new DateTime(), new DateTime(2000, 1, 1, 10, 10, 10), "00:00:00");

			// a started test run
	        ProcessTest(new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(), new DateTime(2000, 1, 1, 0, 0, 1), "00:00:01");
			ProcessTest(new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(), new DateTime(2000, 1, 1, 0, 1, 1), "00:01:01");
			ProcessTest(new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(), new DateTime(2000, 1, 1, 1, 1, 1), "01:01:01");
			ProcessTest(new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(), new DateTime(2000, 1, 1, 0, 55, 0), "00:55:00");

			// an early finished test run
			ProcessTest(new DateTime(2000, 1, 1, 0, 0, 0), new DateTime(), new DateTime(2000, 1, 1, 0, 0, 1), "00:00:01");
		}

	    void ProcessTest(DateTime startTime, DateTime finishTime, DateTime now, string expected)
	    {
		    _timeOps.StartTime = startTime;
		    _timeOps._finishTime = finishTime;
		    var result = _timeOps.GetTimeTaken(now);
		    Assert.Equal(expected, result);
			Console.WriteLine("expected: {0}, result = OK", expected);
	    }
    }
}
