namespace testSpecFlow002
{
    using System;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Bindings;

    [Binding]
    public class Hooks
    {
        private readonly FeatureContext featureContext;
        private readonly ScenarioContext scenarioContext;
        // private readonly ScenarioBlock scenarioBlock;
        // private readonly StepContext stepContext;

        // public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext, ScenarioBlock scenarioBlock, StepContext stepContext)
        // public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext, StepContext stepContext)
        public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext)
        // public Hooks(FeatureContext featureContext, ScenarioContext scenarioContext, ScenarioBlock scenarioBlock)
        {
            this.featureContext = featureContext;
            this.scenarioContext = scenarioContext;
            // this.scenarioBlock = scenarioBlock;
            // this.stepContext = stepContext;
        }

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
            StaticData.InitialValue = StaticData.Flag;
            Console.WriteLine("Flag = {0}", StaticData.Flag);
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

        [AfterScenarioBlock()]
        public void AfterAnyBlock()
        {
            Console.WriteLine("AfterScearioBlock any");
        }

        [AfterStep()]
        public void AfterAnyStep()
        {
            Console.WriteLine("AfterStep any");
            // this.featureContext.FeatureInfo.
            // this.featureContext.
            // this.scenarioContext.ScenarioInfo.
            // this.scenarioContext.TestError.Message
            // this.scenarioContext.ScenarioInfo.
            // this.scenarioBlock.
            // this.stepContext.
            // this.stepContext.
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
            StaticData.Flag = StaticData.InitialValue;
            StaticData.InitialValue = false;
            Console.WriteLine("Flag = {0}", StaticData.Flag);
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
