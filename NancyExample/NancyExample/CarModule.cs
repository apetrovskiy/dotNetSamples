/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 3:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;

namespace NancyExample
{
	/// <summary>
	/// Description of CarModule.
	/// </summary>
	public class CarModule : NancyModule
	{
		public CarModule()
		{
			Get["/status"] = _ => "Hello World";
		}
	}
}
