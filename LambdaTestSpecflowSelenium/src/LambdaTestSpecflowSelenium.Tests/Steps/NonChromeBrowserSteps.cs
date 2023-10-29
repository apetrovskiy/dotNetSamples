// <copyright file="NonChromeBrowserSteps.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LambdaTestSpecflowSelenium.Tests.Steps;

using System;
using TechTalk.SpecFlow;

// [Binding]
public class StepDefinitions
{
    private readonly ScenarioContext scenarioContext;

    public StepDefinitions(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [Given(@"I navigate to LambdaTest App on following environment")]
    public void GivenInavigatetoLambdaTestApponfollowingenvironment(Table table)
    {
        this.scenarioContext.Pending();
    }

    [Given(@"I select the first item")]
    public void GivenIselectthefirstitem()
    {
        this.scenarioContext.Pending();
    }

    [Given(@"I select the second item")]
    public void GivenIselecttheseconditem()
    {
        this.scenarioContext.Pending();
    }

    [Given(@"I enter the new value in textbox")]
    public void GivenIenterthenewvalueintextbox()
    {
        this.scenarioContext.Pending();
    }

    [When(@"I click the Submit button")]
    public void WhenIclicktheSubmitbutton()
    {
        this.scenarioContext.Pending();
    }

    [Then(@"I verify whether the item is added to the list")]
    public void ThenIverifywhethertheitemisaddedtothelist()
    {
        this.scenarioContext.Pending();
    }
}
