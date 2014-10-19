
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;

	public class Data
	{
		public Data ()
		{
			Suites = new List<Suite> ();
		}

		public static List<Suite> Suites { get; set; }
	}
}

