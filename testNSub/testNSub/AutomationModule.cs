using System.Windows.Automation;
/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 11/6/2013
 * Time: 3:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNSub
{
    using System;
    using Ninject.Modules;
    
    /// <summary>
    /// Description of AutomationModule.
    /// </summary>
    public class AutomationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAutomationElementAdapter>().To<AutomationElementAdapter>();
                //.ToConstructor(arg =>
                //<AutomationElementAdapter>();
        }
    }
}
