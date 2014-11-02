/*
 * Created by SharpDevelop.
 * User: Alexander
 * Date: 10/25/2014
 * Time: 11:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testNancyDotLiquid
{
	using System;
	using Nancy;
	using Nancy.ModelBinding;
	
	/// <summary>
	/// Description of TestModule.
	/// </summary>
	public class TestModule : NancyModule
	{
		public TestModule() //: base("/")
		{
			Get["/products"] = parameters => {
                return View["products_with_layout", null];
            };
		}
	}
}
