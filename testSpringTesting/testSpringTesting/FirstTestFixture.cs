
namespace testSpringTesting
{
	using System;
	using NUnit.Framework;
	using Spring.Rest.Client.Testing;

	[TestFixture]
	public class FirstTestFixture
	{
		public FirstTestFixture ()
		{
		}

		[Test]
		public void test01()
		{
			var server = MockRestServiceServer.CreateServer (new Spring.Rest.Client.RestTemplate ());
			// server.`
		}
	}
}

