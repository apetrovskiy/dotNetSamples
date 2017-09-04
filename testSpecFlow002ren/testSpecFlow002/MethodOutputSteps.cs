namespace testSpecFlow002
{
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class MethodOutputSteps
    {
        private int result;

        [Given(@"I have added (.*)")]
        public void GivenIHaveAdded(int data)
        {
            result += data;
        }
        
        [When(@"I press calcs")]
        public void WhenIPressCalcs()
        {
            // 
        }
        
        [Then(@"the result is (.*)")]
        public void ThenTheResultIs(int expectedData)
        {
            Assert.AreEqual(expectedData, result);
        }
        
        [Then(@"the result is shown")]
        public int ThenTheResultIsShown()
        {
            return result;
        }
    }
}
