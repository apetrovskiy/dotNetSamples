using System;
/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 2/18/2014
 * Time: 2:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testUsageOfLoadFrom
{
    using System.Reflection;
    using System.Linq;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Extensions.Conventions;
    
    /// <summary>
    /// Description of ObjectModule.
    /// </summary>
    public class ObjectModule : NinjectModule
    {
        public override void Load()
        {
            Assembly externalAssembly = Assembly.LoadFrom(@"C:\Projects\probe\testUsageOFLoadFrom\lib\bin\Debug\lib.dll");
            Type neededType = externalAssembly.GetTypes().Where(t => t.Name == "MyClass").First();
            Bind(neededType).ToSelf();
            Kernel.Bind(r => r.FromThisAssembly().SelectAllClasses().BindToSelf());
            // Kernel.Bind(r => r.FromAssembliesMatching("lib").SelectAllClasses().BindToSelf());
        }
    }
}
