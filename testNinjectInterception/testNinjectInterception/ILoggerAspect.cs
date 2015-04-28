/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:39 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using Ninject.Extensions.Interception;
	
	/// <summary>
	/// Description of ILoggerAspect.
	/// </summary>
	public interface ILoggerAspect : IInterceptor
	{
		void Intercept(IInvocation invocation);
	}
}
