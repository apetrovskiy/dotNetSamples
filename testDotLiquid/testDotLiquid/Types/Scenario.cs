namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	// using DotLiquid;

	public class Scenario // : Drop, ILiquidizable
	{
		public Scenario ()
		{
			Results = new List<Result> ();
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public List<Result> Results { get; set; }
	}
}

