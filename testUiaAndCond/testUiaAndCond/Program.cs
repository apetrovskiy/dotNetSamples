/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 11/28/2013
 * Time: 8:05 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUiaAndCond
{
    using System;
    using System.Windows.Automation;
    
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // TODO: Implement Functionality Here
            
            AutomationElement wnd = 
                AutomationElement.RootElement.FindFirst(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        "testUiaAndCond - SharpDevelop"));
            
            if (null == wnd) {
                Console.WriteLine("null == wnd");
            } else {
                Console.WriteLine(wnd.Current.Name);
            }
            
            AutomationElementCollection texts =
                wnd.FindAll(
                    TreeScope.Descendants,
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.Text),
                        new PropertyCondition(
                            AutomationElement.AutomationIdProperty,
                            "paneTitle"),
                        new PropertyCondition(
                            AutomationElement.ClassNameProperty,
                            "TextBlock"),
                        new PropertyCondition(
                            AutomationElement.NameProperty,
                            "Projects")));
            
//            Get-UIAPane -Class '#32769' | `
//Get-UIAWindow -Class 'Window' -Name 'testUiaAndCond - SharpDevelop' | `
//Get-UIAText -AutomationId 'paneTitle' -Class 'TextBlock' -Name 'Projects'
            
            if (null == texts) {
                Console.WriteLine("null == text");
            } else {
                Console.WriteLine(texts.Count.ToString());
                foreach (AutomationElement element in texts) {
                    Console.WriteLine(element.Current.Name);
                }
            }
//            if (null == text.Current) {
//                Console.WriteLine("null == text.Current");
//            }
            
            AutomationElement text =
                wnd.FindFirst(
                    TreeScope.Descendants,
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        "Project"));
            
            Console.WriteLine(text.Current.Name);
            Console.WriteLine(text.Current.AutomationId);
            Console.WriteLine(text.Current.ClassName);
            Console.WriteLine(text.Current.ControlType.ProgrammaticName.Substring(12));
            
            AutomationElement menuItem =
                wnd.FindFirst(
                    TreeScope.Descendants,
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.NameProperty,
                            "Project"),
                        new PropertyCondition(
                            AutomationElement.ClassNameProperty,
                            "MenuItem"),
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.MenuItem),
                        new PropertyCondition(
                            AutomationElement.IsOffscreenProperty,
                            false),
                        new PropertyCondition(
                            AutomationElement.IsEnabledProperty,
                            true),
                        new PropertyCondition(
                            AutomationElement.AutomationIdProperty,
                            "")));
            
            Console.WriteLine(menuItem.Current.Name);
            Console.WriteLine(menuItem.Current.AutomationId);
            Console.WriteLine(menuItem.Current.ClassName);
            Console.WriteLine(menuItem.Current.ControlType.ProgrammaticName);
            Console.WriteLine(menuItem.Current.IsEnabled);
            Console.WriteLine(menuItem.Current.IsOffscreen);
            
            //string name = text.Current.Name;
            //Console.WriteLine(text.Current.Name);
            //Console.WriteLine(text.Current.AutomationId);
            //Console.WriteLine(text.Current.ClassName);
            //Console.WriteLine(text.Current.ControlType.ProgrammaticName.Substring(12));
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}