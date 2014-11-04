/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/1/2013
 * Time: 4:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */




namespace GetCorrIdProbe
{
    using System;
    using System.Runtime.InteropServices;
    
    class Program
    {
        [DllImport("advapi32.dll")]
        public static extern uint EventActivityIdControl(uint controlCode, ref Guid activityId);
        public const uint EVENT_ACTIVITY_CTRL_GET_ID = 1;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            System.Guid g = System.Guid.Empty;
            EventActivityIdControl(EVENT_ACTIVITY_CTRL_GET_ID, ref g);
                       
            Console.WriteLine(g.ToString());
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}