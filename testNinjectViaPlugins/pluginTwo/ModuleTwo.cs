/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/11/2014
 * Time: 12:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace pluginTwo
{
    using System;
    using Ninject.Modules;
    
    /// <summary>
    /// Description of ModuleTwo.
    /// </summary>
    public class ModuleTwo : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestTwo>().To<TestTwo>();
        }
    }
}
