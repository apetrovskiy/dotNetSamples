namespace TechTalk.SpecFlow.Bindings
{
    using Maths;
    using NUnit.Framework;

    [Binding]
    public class CalcSteps
    {
        [Given(@"I have entered (.*) as a first operand")]
        public void GivenIHaveEnteredIntoTheCalculator(long operandOne)
        {
            ScenarioContext.Current.Add(Constants.OperandOneKey, operandOne);
        }

        [When(@"I have added (.*) to the first operand")]
        public void WhenIPressAdd(long operandTwo)
        {
            ScenarioContext.Current.Add(Constants.Result, ((long)ScenarioContext.Current[Constants.OperandOneKey]).Add(operandTwo));
        }

        [When(@"I have substracted (.*) from the first operand")]
        public void WhenIHaveSubstractedFromTheFirstOperand(long operandTwo)
        {
            ScenarioContext.Current.Add(Constants.Result, ((long)ScenarioContext.Current[Constants.OperandOneKey]).Substract(operandTwo));
        }

        [When(@"I have divided the first operand by (.*)")]
        public void WhenIHaveDividedTheFirstOperandBy(long operandTwo)
        {
            ScenarioContext.Current.Add(Constants.Result, ((long)ScenarioContext.Current[Constants.OperandOneKey]).DivideBy(operandTwo));
        }

        [Then(@"the long result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(long expectedResult)
        {
            var actualResult = ((long) ScenarioContext.Current[Constants.Result]);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Then(@"the float result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(float expectedResult)
        {
            var actualResult = ((float)ScenarioContext.Current[Constants.Result]);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}