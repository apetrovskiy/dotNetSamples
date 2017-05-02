namespace testSpecFlow002
{
    using System;
    using TechTalk.SpecFlow;

    [Binding]
    public class Hooks
    {
        [Before("tag01")]
        public void Before()
        {
            Console.WriteLine("Before");
        }

        [BeforeTestRun()]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun");
        }

        [BeforeFeature("BeforeFeature")]
        public static void BeforeFeature()
        {
            Console.WriteLine("BeforeFeature");
        }

        [BeforeScenarioBlock("BeforeScenarioBlock")]
        public void BeforeScenarioBlock()
        {
            Console.WriteLine("BeforeScenarioBlock");
        }

        [BeforeScenario()]
        public void BeforeAnyScenario()
        {
            Console.WriteLine("BeforeScenario Any");
        }

        [BeforeScenario("ScenarioName")]
        public void BeforeScenarioByName()
        {
            Console.WriteLine("BeforeScenario ScenarioName");
        }

        [BeforeScenario("BeforeScenario")]
        public void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario BeforeScenario");
        }

        [BeforeStep("BeforeStep")]
        public void BeforeStep()
        {
            Console.WriteLine("BeforeStep");
        }

        [AfterStep("AfterStep")]
        public void AfterStep()
        {
            Console.WriteLine("AfterStep");
        }

        [AfterScenario("AfterScenario")]
        public void AfterScenario()
        {
            Console.WriteLine("AfterScenario AfterScenario");
        }

        [AfterScenario()]
        public void AfterAnyScenario()
        {
            Console.WriteLine("AfterScenario Any");
        }

        [AfterScenario("ScenarioName")]
        public void AfterScenarioByName()
        {
            Console.WriteLine("AfterScenario ScenarioName");
        }

        [AfterScenarioBlock("AfterScenarioBlock")]
        public void AfterScenarioBlock()
        {
            Console.WriteLine("AfterScenarioBlock");
        }

        [AfterFeature]
        public static void AfterAnyFeature()
        {
            Console.WriteLine("AfterFeature Any");
        }

        [AfterFeature("AfterFeature")]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature AfterFeature");
        }

        [AfterTestRun()]
        public static void AfterTestRun()
        {
            Console.WriteLine("AfterTestRun");
        }

        [After("tag01")]
        public void After()
        {
            Console.WriteLine("After");
        }
    }
}
