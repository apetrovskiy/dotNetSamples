namespace testSpecFlow002.Steps
{
    // using NUnit.Framework;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
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
