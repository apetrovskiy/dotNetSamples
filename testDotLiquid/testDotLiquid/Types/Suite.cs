
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;

	public class Suite
	{
		public Suite()
		{
			Scenarios = new List<Scenario> ();
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public List<Scenario> Scenarios { get; set; }
	}
}

