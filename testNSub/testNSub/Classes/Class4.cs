/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/5/2013
 * Time: 12:01 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub
{
    using System;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of Class4.
    /// </summary>
    public class Class4
    {
        public Class4()
        {
        }
        
        public void GetManyElements()
        {
            AutomationElement ae =
            //IAutomationElement ae =
                AutomationElement.RootElement.FindFirst(
                    TreeScope.Children,
                    new PropertyCondition(
                        AutomationElement.NameProperty,
                        "testNSub - SharpDevelop"));
            
            //IAutomationElement iae = (IAutomationElement)ae;
            //IAutomationElement iae = ae as IAutomationElement;
            
            Console.WriteLine(ae.Current.Name);
            Console.WriteLine(ae.Current.AutomationId);
            Console.WriteLine(ae.Current.ClassName);
            Console.WriteLine(ae.Current.ControlType.ProgrammaticName);
            
            IAutomationElementAdapter ad = new AutomationElementAdapter(ae);
            
            //AutomationElement.ro
            //AutomationElement ae2 =
            IAutomationElementAdapter ad2 =
                ad.FindFirst(
                    TreeScope.Descendants,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.MenuItem));
            
            AutomationElement ae2 = ad2.SourceElement;
            
            Console.WriteLine(ae2.Current.Name);
            Console.WriteLine(ae2.Current.AutomationId);
            Console.WriteLine(ae2.Current.ClassName);
            Console.WriteLine(ae2.Current.ControlType.ProgrammaticName);
            
            IAutomationElementCollection adc =
                ad.FindAll(
                    TreeScope.Descendants,
                    new PropertyCondition(
                        AutomationElement.ControlTypeProperty,
                        ControlType.MenuItem));
            
            Console.WriteLine(adc.Count);
            Console.WriteLine(adc.GetType().Name);
            Console.WriteLine("==============================");
            foreach (AutomationElement element in adc) {
                Console.WriteLine(element.Current.Name);
                Console.WriteLine(element.GetType().Name);
                Console.WriteLine("==============================");
            }
            
        }
    }
}
