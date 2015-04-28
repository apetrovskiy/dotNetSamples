/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using System.Diagnostics;
	using Ninject.Extensions.Interception;
	
	/// <summary>
	/// Description of Log4NetAspect.
	/// </summary>
	public class Log4NetAspect : SimpleInterceptor, ILoggerAspect
	{
	    protected override void BeforeInvoke(IInvocation invocation)
	    {
	    	Console.WriteLine("Before Method");
	        // Console.WriteLine("Running " + invocation.ReturnValue);
	        Console.WriteLine("Running " + invocation.Request.Method.Name);
	        base.BeforeInvoke(invocation);
	    }
	
	    public new void Intercept(IInvocation invocation)
	    {
	        try
	        {
	            base.Intercept(invocation);
	        }
	        catch (Exception e)
	        {
	            Debug.WriteLine("Exception: " + e.Message);
	        }
	    }
	
	    protected override void AfterInvoke(IInvocation invocation)
	    {
	        Console.WriteLine("After Method");
	        base.AfterInvoke(invocation);
	    }
	}
}
