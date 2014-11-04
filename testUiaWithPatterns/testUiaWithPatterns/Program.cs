/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/7/2013
 * Time: 2:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUiaWithPatterns
{
    using System;
    using System.Windows.Automation;
    using UIAutomation;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            
            AutomationElementCollection wnds1 =
                AutomationElement.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsOffscreenProperty,
                        false));
            
            AutomationElementCollection wnds2 =
                AutomationElement.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsWindowPatternAvailableProperty,
                        true));
            
            AutomationElementCollection wnds3 =
                AutomationElement.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsWindowPatternAvailableProperty,
                        false));
            
//            foreach (AutomationElement element in wnds) {
//                Console.WriteLine("=======================================================================");
//                Console.WriteLine(element.Current.Name);
//                Console.WriteLine(element.Current.AutomationId);
//                Console.WriteLine(element.Current.ClassName);
//                Console.WriteLine(element.Current.ControlType.ProgrammaticName);
//                
//                AutomationPattern[] patterns = element.GetSupportedPatterns();
//                foreach (AutomationPattern pattern in patterns) {
//                    Console.WriteLine(pattern.ProgrammaticName);
//                }
//            }
            
            Console.WriteLine(wnds1.Count.ToString());
            Console.WriteLine(wnds2.Count.ToString());
            Console.WriteLine(wnds3.Count.ToString());
            
            
            // AutomationFactory.Init();
            // IMySuperWrapper element1 = AutomationFactory.GetMySuperWrapper(AutomationElement.RootElement);
            
            // IMySuperWrapper element2 = AutomationFactory.GetMySuperWrapperStatic(AutomationElement.RootElement);
            
            
            IMySuperCollection coll1 =
                MySuperWrapper.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsOffscreenProperty,
                        false));
            
            IMySuperCollection coll2 =
                MySuperWrapper.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsWindowPatternAvailableProperty,
                        true));
            
            IMySuperCollection coll3 =
                MySuperWrapper.RootElement.FindAll(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.IsWindowPatternAvailableProperty,
                        false));
            
            Console.WriteLine(coll1.Count.ToString());
            Console.WriteLine(coll2.Count.ToString());
            Console.WriteLine(coll3.Count.ToString());
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}