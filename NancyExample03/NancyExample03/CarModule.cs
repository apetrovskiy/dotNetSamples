/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 6/30/2014
 * Time: 3:58 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Nancy;

namespace NancyExample03
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
