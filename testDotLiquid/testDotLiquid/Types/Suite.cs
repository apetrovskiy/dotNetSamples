
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	// using DotLiquid;

	public class Suite // : Drop, ILiquidizable
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

