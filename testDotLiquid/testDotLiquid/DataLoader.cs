/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 10/14/2014
 * Time: 2:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace testDotLiquid
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of DataLoader.
    /// </summary>
    public class DataLoader
    {
        public void LoadData()
        {
			// var holder = new Holder ();
			Holder.Suites = new List<Suite>();

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
			Holder.Suites.Add (suite);

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
			Holder.Suites.Add (suite);
        }
    }
}
