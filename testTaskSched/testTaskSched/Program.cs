/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 12/26/2014
 * Time: 3:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testTaskSched
{
    using System;
    using Microsoft.Win32.TaskScheduler;
    
    
    class Program
    {
        public static void Main(string[] args)
        {
            using (var taskService = new TaskService()) {
                var taskDefinition = taskService.NewTask();
                taskDefinition.RegistrationInfo.Description = "test task";
                
                var weeklyTrigger = new WeeklyTrigger {
                    StartBoundary = DateTime.Today.AddDays(1),
                    DaysOfWeek = DaysOfTheWeek.Monday | DaysOfTheWeek.Saturday,
                    WeeksInterval = 2
                };
                
                taskDefinition.Triggers.Add(weeklyTrigger);
                
                taskDefinition.Actions.Add(new ExecAction("notepad.exe", @"e:\20141225\1.txt", null));
                
                taskService.RootFolder.RegisterTaskDefinition("my task", taskDefinition);
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}