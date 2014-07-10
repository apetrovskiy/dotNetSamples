/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 7/3/2014
 * Time: 1:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExampleRestService
{
	using System;
	using Nancy;
	using Nancy.Bootstrapper;
	
	/// <summary>
	/// Description of Bootstrapper.
	/// </summary>
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override NancyInternalConfiguration InternalConfiguration
		{
			get {
				return NancyInternalConfiguration.Default;
			}
		}
	}
}
