namespace testSpecFlow002
{
    using System;
    using TechTalk.SpecFlow;
    using TechTalk.SpecFlow.Assist;

    [Binding]
    public class TestTableWithAssistSteps
    {
        [Given(@"I entered the following data into the new account form:")]
        public void GivenIEnteredTheFollowingDataIntoTheNewAccountForm(Table table)
        {
            var account = table.CreateInstance<Account>();
        }
        
        [When(@"I do test")]
        public void WhenIDoTest()
        {
            // ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be displayed")]
        public void ThenTheResultShouldBeDisplayed()
        {
            // ScenarioContext.Current.Pending();
        }
    }

    public class Account
    {
    }
}
