using System;
using System.Collections.Generic;

namespace testLinqQueries
{
	public class Suite
	{
		public Suite ()
		{
		}

		public string Id { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public List<Scenario> Scenarios { get; set; }
	}
}

