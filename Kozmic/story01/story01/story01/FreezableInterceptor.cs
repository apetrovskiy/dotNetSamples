/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 5:57 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Castle.DynamicProxy;

namespace story01
{
    /// <summary>
    /// Description of FreezableInterceptor.
    /// </summary>
    internal class FreezableInterceptor : IInterceptor, IFreezable
    {
        private bool _isFrozen;
      
        public void Freeze()
        {
            _isFrozen = true;
        }
      
        public bool IsFrozen
        {
            get { return _isFrozen; }
        }
      
        public void Intercept(IInvocation invocation)
        {
            if (_isFrozen && invocation.Method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
            {
                throw new ObjectFrozenException();
            }
      
            invocation.Proceed();
        }
    }
}
