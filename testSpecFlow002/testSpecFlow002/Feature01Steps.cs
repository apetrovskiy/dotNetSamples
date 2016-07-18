using System;
using TechTalk.SpecFlow;

namespace testSpecFlow002
{
    [Binding]
    public class Feature01Steps
    {
        int _numbers;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            _numbers += p0;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            // nothing
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            if (_numbers == p0)
                Console.WriteLine("OK");
            else
                Console.WriteLine("not OK");
        }

    }
}
