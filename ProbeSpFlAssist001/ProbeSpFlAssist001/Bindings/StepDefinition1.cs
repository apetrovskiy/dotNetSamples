namespace ProbeSpFlAssist001.Bindings
{
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class StepDefinition1
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        private int storage = 0;
        private int result = 0;

        public StepDefinition1()
        {
            this.storage = 0;
            this.result = 0;
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see http://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            this.storage += number;
        }

        [When("I press add")]
        public void WhenIPressAdd()
        {
            //TODO: implement act (action) logic

            this.result = this.storage;
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            Assert.AreEqual(result, this.result);
        }
    }
}
