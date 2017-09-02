namespace testSpecFlow002.Steps
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    // using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public class TestTableAsDictionarySteps
    {
        string _username;
        string _password;

        [Given(@"I have a test")]
        public void GivenIHaveATest()
        {
            // ScenarioContext.Current.Pending();
        }
        
        [When(@"User enter credentials")]
        public void WhenUserEnterCredentials(Table table)
        {
            // ScenarioContext.Current.Pending();
            table.Rows.ToList().ForEach(row => row.Keys.ToList().ForEach(key => Console.WriteLine("{0}={1}", key, row[key])));
        }
        
        [Then(@"the result should be '(.*)' and '(.*)' returned")]
        public void ThenTheResultShouldBeAndReturned(string username, string password)
        {
            // ScenarioContext.Current.Pending();
            Assert.AreEqual(username, _username);
            Assert.AreEqual(password, _password);
        }
    }
}
