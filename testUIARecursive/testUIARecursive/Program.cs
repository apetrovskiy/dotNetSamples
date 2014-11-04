/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/12/2013
 * Time: 9:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUIARecursive
{
    using System;
    using System.Diagnostics;
    using System.Windows.Automation;
    using System.Reflection;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            Condition cond =
                new AndCondition(
                    new PropertyCondition(
                        AutomationElement.AutomationIdProperty,
                        "id"),
                    new PropertyCondition(
                        AutomationElement.ClassNameProperty,
                        "ccc"),
                    new PropertyCondition(
                        ValuePattern.ValueProperty,
                        "vvv"));
            MethodInfo mInfo =
                cond.
            
            
            if (null != args[0] && string.Empty != args[0]) {
                
                Process[] allProcesses =
                    System.Diagnostics.Process.GetProcesses();
                
                Console.WriteLine("all processes: " + allProcesses.Length.ToString());
                
                System.Collections.Generic.List<Process> neededProcesses =
                    new System.Collections.Generic.List<Process>();
                
                foreach (Process process in allProcesses) {
                    
                    if (args[0].ToUpper() == process.ProcessName.ToUpper()) {
                        
                        neededProcesses.Add(process);
                    }
                }
                
                if (0 != neededProcesses.Count) {
                    
                    
                    Process[] processes = neededProcesses.ToArray() as Process[];
                    
                    //UIA.GetAllWindowsFromAllProcesses((Process[])neededProcesses.ToArray());
                    UIA.GetAllWindowsFromAllProcesses(processes, args[1]);
                    
                } else {
                    
                    Console.WriteLine("There are no such processes");
                }
                
            } else {
                
                Console.WriteLine("wrong input!!!");
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}