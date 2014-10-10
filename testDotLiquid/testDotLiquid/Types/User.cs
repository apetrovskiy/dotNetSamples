
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	using DotLiquid;

	[LiquidType("user")]
	public class User : Drop, ILiquidizable
	{
		public string Name { get; set; }
		public List<Task> Tasks { get; set; }
	}
}

