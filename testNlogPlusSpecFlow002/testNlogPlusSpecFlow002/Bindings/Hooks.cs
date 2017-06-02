namespace testNlogPlusSpecFlow002.Bindings
{
	using NLog;
	using TechTalk.SpecFlow;

	[Binding]
	public class Hooks
	{
		private static Logger logger = LogManager.GetLogger("SpecFlowLogger");

		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			logger.Log(LogLevel.Info, "Starting tests");
		}

		[BeforeFeature]
		public static void BeforeAnyFeature()
		{
			logger.Log(LogLevel.Info, "Starting feature...");
		}

		[AfterFeature]
		public static void AfterAnyFeature()
		{
			logger.Log(LogLevel.Info, "Finishing the feature...");
		}

		[BeforeStep]
		public void BeforeAnyScenario()
		{
			logger.Log(LogLevel.Info, "Starting scenario...");
		}

		[AfterStep]
		public void AfterAnyScenario()
		{
			logger.Log(LogLevel.Info, "Finishing the scenario");
		}

		[AfterTestRun]
		public static void AfterTestRun()
		{
			logger.Log(LogLevel.Info, "Stopping the test suite");
		}
	}
}