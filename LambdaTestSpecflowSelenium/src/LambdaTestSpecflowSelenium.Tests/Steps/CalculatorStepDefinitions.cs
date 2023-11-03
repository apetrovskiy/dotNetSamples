// <copyright file="CalculatorStepDefinitions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LambdaTestSpecflowSelenium.Tests.Steps;

using TechTalk.SpecFlow;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly ScenarioContext scenarioContext;

    public CalculatorStepDefinitions(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [Given("the first number is (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        this.scenarioContext.Pending();
    }

    [Given("the second number is (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        this.scenarioContext.Pending();
    }

    [When("thw two numbers are added")]
    public void WhenTwoNumbersAreAdded()
    {
        this.scenarioContext.Pending();
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        this.scenarioContext.Pending();
    }
}
