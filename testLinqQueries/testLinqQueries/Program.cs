using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace testLinqQueries
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			var suite01 = new Suite {
				Id = "1",
				Name = "s01",
				Status = "PASSED",
				Scenarios = new List<Scenario> {
					new Scenario {
						Id = "1",
						Name = "sc01",
						Status = "PASSED"
					},
					new Scenario {
						Id = "2",
						Name = "sc01",
						Status = "PASSED"
					},
					new Scenario {
						Id = "3",
						Name = "sc03",
						Status = "PASSED"
					}}
			};

			var query = from scenario in suite01.Scenarios
				select scenario.Name;

			Console.WriteLine (query.GetType ().Name);
			// Console.WriteLine (query.ToList<Scenario>());

			var result01 = suite01.Scenarios.Select (scenario => scenario.Name).ToList ();
			foreach (var aaa in result01) {
				Console.WriteLine (aaa);
			}

			var result02 = suite01.Scenarios.SelectMany (scenario => { return new Scenario[] { new Scenario { Id = scenario.Id, Name = scenario.Name, Status = scenario.Status } }; });
			foreach (var aaa in result02) {
				Console.WriteLine (aaa);
			}

			Console.ReadKey ();
		}
	}
}
