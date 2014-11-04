/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 7:18 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace NancyExample07
{
	using System;
	using StructureMap;
	using StructureMap.Graph;
	
	
	/// <summary>
	/// Description of StructureMapContainer.
	/// </summary>
	public class StructureMapContainer
	{
		public static void Configure(IContainer container)
		{
			container.Configure(config => config.Scan(c =>
			                                          {
			                                          	c.TheCallingAssembly();
			                                          	c.WithDefaultConventions();
			                                          }));
		}
	}
}
