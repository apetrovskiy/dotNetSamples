
namespace testDotLiquid
{
	using System;
	using System.Collections.Generic;
	using DotLiquid;

	public class User : Drop
	{
		public string Name { get; set; }
		public List<Task> Tasks { get; set; }
	}
}

