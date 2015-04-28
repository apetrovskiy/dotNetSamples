/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:35 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using Ninject.Modules;
//	using Ninject.Extensions.Interception;
//	using Ninject.Extensions.Interception.Infrastructure;
//	using Ninject.Extensions.Interception.Invocation;
//	using Ninject.Extensions.Interception.Wrapper;
//	using Ninject.Extensions.Interception.Attributes;
//	using Ninject.Extensions.Interception.ProxyFactory;
//	using Ninject.Extensions.Interception.Activation;
//	using Ninject.Extensions.Interception.Advice;
//	using Ninject.Extensions.Interception.Injection;
//	using Ninject.Extensions.Interception.Parameters;
//	using Ninject.Extensions.Interception.Planning;
//	using Ninject.Extensions.Interception.Registry;
//	using Ninject.Extensions.Interception.Request;
	using Ninject.Extensions.Interception.Infrastructure.Language;
	
	/// <summary>
	/// Description of Module.
	/// </summary>
	public class MyModule : NinjectModule
	{
		public override void Load()
		{
			this.Bind<MyClass>().ToSelf().Intercept().With<ILoggerAspect>();
		}
	}
}
