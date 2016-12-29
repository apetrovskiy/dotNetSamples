namespace TechTalk.SpecFlow.Bindings
{
    using System.Diagnostics;

    [Binding]
    public class Hooks
    {
        [BeforeFeature()]
        public static void BeforeAllFeatures()
        {
            Trace.WriteLine("before all features");
        }

        [BeforeScenario()]
        public void BeforeAllScenarios()
        {
            Trace.WriteLine("before all scenarios");
        }
    }
}