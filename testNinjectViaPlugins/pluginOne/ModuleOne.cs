/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/11/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pluginOne
{
    using System;
    using Ninject.Modules;
    
    /// <summary>
    /// Description of ModuleOne.
    /// </summary>
    public class ModuleOne : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestOne>().To<TestOne>();
        }
    }
}
