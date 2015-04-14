/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 31/03/2015
 * Time: 03:59 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDateTimeDeterminer
{
    using System;
    
    /// <summary>
    /// Description of TimeOperations.
    /// </summary>
    public class TimeOperations
    {
        public DateTime _finishTime;
        public DateTime StartTime;
        
        public string GetTimeTaken(DateTime dateTime)
        {
            TimeSpan resultSpan;
            // TODO: DI
            // var timeOperations = new TimeOperations();
            // var timeOperations = TinyIocContainer
            if (DateTime.MinValue == StartTime)
                return string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            if (DateTime.MinValue < _finishTime)
                resultSpan = _finishTime - StartTime;
            else
                resultSpan = GetCurrentDateTime(dateTime) - StartTime;
			// return string.Format("{0:00}:{1:00}:{2:00}", resultSpan.TotalHours % 60, resultSpan.TotalMinutes % 60, resultSpan.TotalSeconds % 60);
			return string.Format("{0:00}:{1:00}:{2:00}", (int)resultSpan.TotalHours % 60, (int)resultSpan.TotalMinutes % 60, (int)resultSpan.TotalSeconds % 60);
		}
        
        DateTime GetCurrentDateTime(DateTime dateTime)
        {
            return dateTime;
        }
    }
}
