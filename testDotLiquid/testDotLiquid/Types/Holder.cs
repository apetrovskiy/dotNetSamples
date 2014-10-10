
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;

	public static class Holder
	{
		static Holder()
		{
			Suites = new List<Suite> ();
		}

		public static List<Suite> Suites { get; set; }
	}
}

