
namespace testDotLiquid
{
	using System;
	using Nancy;
	using Nancy.ModelBinding;

	public class SimpleModule : NancyModule
	{
		public SimpleModule () : base("/simple")
		{
			Get ["/simple"] = _ => {
				return View["simple.htm"];
			};
		}
	}
}

