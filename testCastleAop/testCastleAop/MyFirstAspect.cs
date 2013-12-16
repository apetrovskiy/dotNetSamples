/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 12/14/2013
 * Time: 12:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testCastleAop
{
    using System;
    using Castle.DynamicProxy;
    
    /// <summary>
    /// Description of MyFirstAspect.
    /// </summary>
    public class MyFirstAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("before invocation");
            invocation.Proceed();
            Console.WriteLine("after invocation");
        }
    }
}
