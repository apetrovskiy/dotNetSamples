namespace testSpecFlow002.Steps
{
    using TechTalk.SpecFlow;

    [Binding]

    public class CommonSteps
    {
        [Given(@"I set flag=(.*)")]
        [Then(@"I set flag=(.*)")]
        public void GivenISetFlag(bool value)
        {
            StaticData.Flag = value;
        }
    }
}