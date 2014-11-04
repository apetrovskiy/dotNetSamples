/*
 * Created by SharpDevelop.
 * User: APetrovsky
 * Date: 12/16/2013
 * Time: 6:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Castle.DynamicProxy;

namespace story01
{
    /// <summary>
    /// Description of CallLoggingInterceptor.
    /// </summary>
    public class CallLoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name);
        }
    }
}
