
namespace testDotLiquid
{
	using System;
	using System.Linq;
	using Nancy;
	using Nancy.ModelBinding;
	using DotLiquid;
	using DotLiquid.NamingConventions;
	using DotLiquid.Tags.Html;
	using DotLiquid.Util;

	public class SimpleModule : NancyModule
	{
		public SimpleModule () : base("/simple")
		{
			Get ["/simple"] = _ => {
				// return View["simple.htm"];
				var data = Holder.Suites.SelectMany(suite => suite.Scenarios
				                                    .SelectMany(scenario => scenario.Results
				            .Select(result => "<td>" + suite.Name + "</td><td>" + suite.Id + "</td><td>" + scenario.Name + "</td><td>" + scenario.Id + "</td><td>" + scenario.Status + "</td><td>" + result.Name + "</td><td>" + result.Id + "</td><td>" + result.Status + "</td>"))).ToArray<string>().ToList();
				return View["simple.htm", data];
			};

			Get ["/results"] = _ => {
				var data = new Holder();
				return View["results.liquid", data];
			};
		}
	}
}

