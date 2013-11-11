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
        
        //public void GetManyElements()
        public IAutomationElementCollection GetManyElements()
        {
            Console.WriteLine("before getting the window " + System.DateTime.Now.ToLongTimeString());
            
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
            
            Console.WriteLine("before getting one menu item " + System.DateTime.Now.ToLongTimeString());
            
            IAutomationElementAdapter ad = new AutomationElementAdapter(ae);
            
            //AutomationElement.ro
            //AutomationElement ae2 =
//            IAutomationElementAdapter ad2 =
//                ad.FindFirst(
//                    TreeScope.Descendants,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.MenuItem));

            IAutomationElementAdapter ad2 =
                ad.FindFirst(
                    TreeScope.Descendants,
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.MenuItem),
                        new PropertyCondition(
                            AutomationElement.NameProperty,
                            "Debug")));
            
            Console.WriteLine("before getting multiple menu items " + System.DateTime.Now.ToLongTimeString());
            
            AutomationElement ae2 = ad2.SourceElement;
            
            Console.WriteLine(ae2.Current.Name);
            Console.WriteLine(ae2.Current.AutomationId);
            Console.WriteLine(ae2.Current.ClassName);
            Console.WriteLine(ae2.Current.ControlType.ProgrammaticName);
            
//            IAutomationElementCollection adc =
//                ad.FindAll(
//                    TreeScope.Descendants,
//                    new PropertyCondition(
//                        AutomationElement.ControlTypeProperty,
//                        ControlType.MenuItem));

            IAutomationElementCollection adc =
                ad.FindAll(
                    TreeScope.Descendants,
                    new AndCondition(
                        new PropertyCondition(
                            AutomationElement.ControlTypeProperty,
                            ControlType.MenuItem),
                        new PropertyCondition(
                            AutomationElement.NameProperty,
                            "Debug")));
            
            Console.WriteLine("after all " + System.DateTime.Now.ToLongTimeString());
            
            Console.WriteLine(adc.Count);
            Console.WriteLine(adc.GetType().Name);
            Console.WriteLine("==============================");
            foreach (AutomationElement element in adc) {
                Console.WriteLine(element.Current.Name);
                Console.WriteLine(element.GetType().Name);
                Console.WriteLine("==============================");
            }
            
            return adc;
        }
    }
}
