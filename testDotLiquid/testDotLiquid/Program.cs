
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	using Nancy;
	using Nancy.Hosting;
	using Nancy.Hosting.Self;
	using Nancy.Conventions;

	class MainClass
	{
		public static void Main (string[] args)
		{
			var suite = new Suite { Id = "1", Name = "s01" };
			var scenario = new Scenario { Id = "1", Name = "sc01", Status = "PASSED" };
			scenario.Results.AddRange (
				new[] {
				new Result { Id = "1", Name = "tr01", Status = "PASSED" },
				new Result { Id = "2", Name = "tr02", Status = "PASSED" },
				new Result { Id = "3", Name = "tr03", Status = "PASSED" },
				new Result { Id = "4", Name = "tr04", Status = "PASSED" }
			});
			suite.Scenarios.Add (scenario);
			scenario = new Scenario { Id = "2", Name = "sc02", Status = "PASSED" };
			scenario.Results.AddRange (
				new[] {
				new Result { Id = "1", Name = "tr01", Status = "PASSED" },
				new Result { Id = "2", Name = "tr02", Status = "PASSED" },
				new Result { Id = "3", Name = "tr03", Status = "PASSED" },
				new Result { Id = "4", Name = "tr04", Status = "PASSED" }
			});
			suite.Scenarios.Add (scenario);
			scenario = new Scenario { Id = "3", Name = "sc03", Status = "FAILED" };
			scenario.Results.AddRange (
				new[] {
				new Result { Id = "1", Name = "tr01", Status = "PASSED" },
				new Result { Id = "2", Name = "tr02", Status = "PASSED" },
				new Result { Id = "3", Name = "tr03", Status = "FAILED" },
				new Result { Id = "4", Name = "tr04", Status = "PASSED" }
			});
			suite.Scenarios.Add (scenario);

			suite = new Suite { Id = "2", Name = "s02" };
			scenario = new Scenario { Id = "1", Name = "sc01", Status = "PASSED" };
			scenario.Results.AddRange (
				new[] {
				new Result { Id = "1", Name = "tr01", Status = "PASSED" },
				new Result { Id = "2", Name = "tr02", Status = "PASSED" },
				new Result { Id = "3", Name = "tr03", Status = "PASSED" },
				new Result { Id = "4", Name = "tr04", Status = "PASSED" }
			});
			suite.Scenarios.Add (scenario);
			scenario = new Scenario { Id = "2", Name = "sc02", Status = "PASSED" };
			scenario.Results.AddRange (
				new[] {
				new Result { Id = "1", Name = "tr01", Status = "PASSED" },
				new Result { Id = "2", Name = "tr02", Status = "PASSED" },
				new Result { Id = "3", Name = "tr03", Status = "PASSED" },
				new Result { Id = "4", Name = "tr04", Status = "PASSED" }
			});
			suite.Scenarios.Add (scenario);

			StaticConfiguration.DisableErrorTraces = false;

			using (var host = new NancyHost(new Uri("http://localhost:1234")))
			{
				host.Start();
				Console.WriteLine ("Press any key to stop server...");
				Console.ReadLine();
			}
		}
	}
}
