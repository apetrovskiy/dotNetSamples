/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 5/12/2013
 * Time: 9:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUIARecursive
{
    using System;
    using System.Windows.Automation;
    using System.Diagnostics;
    
    /// <summary>
    /// Description of UIA.
    /// </summary>
    public static class UIA
    {
        static UIA()
        {
        }
        
        public static void GetAllWindowsFromAllProcesses(Process[] processes, string windowName)
        {
            System.Collections.Generic.List<Condition> array = new System.Collections.Generic.List<Condition>();
            
            foreach (Process process in processes) {
                
                System.Windows.Automation.AndCondition processAndCondition =
                    new AndCondition(
                        System.Windows.Automation.Condition.TrueCondition,
                        new PropertyCondition(
                            System.Windows.Automation.AutomationElement.ProcessIdProperty,
                            process.Id));
                
                array.Add(processAndCondition);
            }
            
            if (1 == array.Count) {
                
                array.Add(System.Windows.Automation.Condition.TrueCondition);
            }
            Condition[] conditions = array.ToArray() as Condition[];
            
            Console.WriteLine("conditions = " + conditions.Length.ToString());
            
            System.Windows.Automation.AndCondition processesAndCondition =
                new AndCondition(
                    conditions);
            System.Windows.Automation.PropertyCondition titleCondition =
                new PropertyCondition(
                    System.Windows.Automation.AutomationElement.NameProperty,
                    windowName);
            System.Windows.Automation.AndCondition nextCondition =
                new AndCondition(
                    processesAndCondition,
                    titleCondition);
            System.Windows.Automation.AndCondition rootAndCondition =
                new AndCondition(
                    new PropertyCondition(
                        System.Windows.Automation.AutomationElement.ControlTypeProperty,
                        System.Windows.Automation.ControlType.Window),
                    nextCondition);
            
            System.Windows.Automation.AutomationElementCollection coll = 
                System.Windows.Automation.AutomationElement.RootElement.FindAll(
                    TreeScope.Descendants,
                    rootAndCondition);
            
            Console.WriteLine("Collection length = " + coll.Count.ToString());
            
            foreach (AutomationElement element in coll) {
                
                Console.WriteLine("Name = " + element.Current.Name + "\tAutomationId = " + element.Current.AutomationId);
            }
        }
        
        public static void GetAllWindowsFromEachProcess(Process[] processes)
        {
            
        }
    }
}
