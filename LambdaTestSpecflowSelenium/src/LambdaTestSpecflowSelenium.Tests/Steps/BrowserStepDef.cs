// <copyright file="BrowserStepDef.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LambdaTestSpecflowSelenium.Tests.Steps;

using System;
using LambdaTestSpecflowSelenium.Tests.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

[Binding]
public class BrowserStepDef
{
    private readonly ScenarioContext scenarioContext;
    private IWebDriver driver;

    public BrowserStepDef(ScenarioContext scenarioContext) => this.scenarioContext = scenarioContext;

    [Given(@"I navigate to LambdaTest App on following environment")]
    public void GivenInavigatetoLambdaTestApponfollowingenvironment(Table table)
    {
        // For local
        this.driver = this.scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

        this.driver.Url = "https://lambdatest.github.io/sample-todo-app/";
    }

    [Given(@"I select the first item")]
    public void GivenIselectthefirstitem()
    {
        this.driver.FindElement(By.Name("li1")).Click();
    }

    [Given(@"I select the second item")]
    public void GivenIselecttheseconditem()
    {
        this.driver.FindElement(By.Name("li2")).Click();
    }

    [Given(@"I enter the new value in textbox")]
    public void GivenIenterthenewvalueintextbox()
    {
        this.driver.FindElement(By.Id("sampletodotext")).SendKeys("sampletodotext");
    }

    [When(@"I click the Submit button")]
    public void WhenIclicktheSubmitbutton()
    {
        this.driver.FindElement(By.Id("addbutton")).Click();
    }

    [Then(@"I verify whether the item is added to the list")]
    public void ThenIverifywhethertheitemisaddedtothelist()
    {
        Assert.That(this.driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span")).Text, Is.EqualTo(string.Empty));
    }
}