/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 5:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace story01
{
    /// <summary>
    /// Description of Freezable.
    /// </summary>
    public static class Freezable
    {
        private static readonly IDictionary<object, IFreezable> _freezables = new Dictionary<object, IFreezable>();
        
        private static readonly ProxyGenerator _generator = new ProxyGenerator();
        
        public static bool IsFreezable(object obj)
        {
            return obj != null && _freezables.ContainsKey(obj);
        }
          
          
        public static void Freeze(object freezable)
        {
            if (!IsFreezable(freezable))
            {
                throw new NotFreezableObjectException(freezable);
            }
            _freezables[freezable].Freeze();
        }
          
        public static bool IsFrozen(object freezable)
        {
            return IsFreezable(freezable) && _freezables[freezable].IsFrozen;
        }
        
        public static TFreezable MakeFreezable<TFreezable>() where TFreezable : class, new()
        {
            var freezableInterceptor = new FreezableInterceptor();
            var proxy = _generator.CreateClassProxy<TFreezable>(new CallLoggingInterceptor(), freezableInterceptor);
            _freezables.Add(proxy, freezableInterceptor);
            return proxy;
        }
    }
}
