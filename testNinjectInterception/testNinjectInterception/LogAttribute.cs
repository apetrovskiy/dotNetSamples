/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:36 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using Ninject;
	using Ninject.Extensions.Interception.Infrastructure;
	using Ninject.Extensions.Interception;
	using Ninject.Extensions.Interception.Attributes;
	using Ninject.Extensions.Interception.Request;
	using Ninject.Extensions.Interception.Infrastructure.Language;
	
	/// <summary>
	/// Description of LogAttribute.
	/// </summary>
	public class LogAttribute : InterceptAttribute
	{
	    public override IInterceptor CreateInterceptor(IProxyRequest request)
	    {
	        return request.Context.Kernel.Get<ILoggerAspect>();
	    }
	}
}
