
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	using Nancy;
	using Nancy.ModelBinding;
	using DotLiquid;
	using DotLiquid.NamingConventions;
	using DotLiquid.Tags.Html;
	using DotLiquid.Util;
	using System.Dynamic;
	using System.Linq;
	using Nancy.ViewEngines;

	public class DotLiquidModule:NancyModule
	{
		public DotLiquidModule ():base("/probe")
		{
			Get ["/probe"] = parameters => {
				var user = new User {
					Name = "Tim Jones",
					Tasks = new List<Task>
					{
						new Task { Name = "Documentation" },
						new Task { Name = "Code comments" }
					}
				};
				return View["probe.liquid", user];
			};

			Get ["/probe.htm"] = parameters => {
				var user = new User {
					Name = "Tim Jones",
					Tasks = new List<Task>
					{
						new Task { Name = "Documentation" },
						new Task { Name = "Code comments" }
					}
				};
				// return View["probe.htm", user];
				return View["probe.htm", user];
				// return DotLiquid.Document
			};
		}
	}
}

