/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 4/28/2015
 * Time: 1:33 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNinjectInterception
{
	using System;
	using Ninject;
	using Ninject.Extensions.Interception.Infrastructure.Language;
	
	/// <summary>
	/// Description of AppConfiguration.
	/// </summary>
	class AppConfiguration 
	{
	
	    internal AppConfiguration( )
	    {
	        // var settings = new NinjectSettings() { LoadExtensions = false };
	        // Kernel = new StandardKernel(settings);
	        Kernel = new StandardKernel();
	        Load();
	    }
	
	    internal StandardKernel Kernel { get; set; }
	
	    public static AppConfiguration Instance
	    {
	        get { return _instance ?? (_instance = new AppConfiguration()); }
	    }
	
	    static AppConfiguration _instance;
	
	    void Load()
	    {
	        Kernel.Bind<ILoggerAspect>().To<Log4NetAspect>().InSingletonScope();
	        Kernel.Bind<MyClass>().ToSelf().Intercept().With<ILoggerAspect>();
	    }
	
	    internal static StandardKernel Resolver()
	    {
	        return Instance.Kernel;
	    }
	}
}
