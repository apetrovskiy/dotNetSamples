/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 3/11/2014
 * Time: 12:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace centralLib
{
    using System;
    using System.Linq;
    using Ninject;
	using Ninject.Modules;
    using Ninject.Parameters;
    
    /// <summary>
    /// Description of ObjectsFactory.
    /// </summary>
    public static class ObjectsFactory
    {
        internal static IKernel Kernel { get; set; }
        
        public static void Init(params INinjectModule[] modules)
        {
            if (null != Kernel) {
                var currentModules = Kernel.GetModules();
                // if (null != currentModules && 0 < currentModules.Count()) {
                if (null != currentModules && currentModules.Any()) {
                    modules.Union(currentModules);
                }
            }
            Kernel = new StandardKernel(modules);
        }
        
        public static T Resolve<T>(params IParameter[] parameters)
        {
            return Kernel.Get<T>(parameters);
        }
    }
}
