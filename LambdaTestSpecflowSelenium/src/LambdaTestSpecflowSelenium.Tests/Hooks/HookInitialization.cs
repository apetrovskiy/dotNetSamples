// <copyright file="HookInitialization.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LambdaTestSpecflowSelenium.Tests.Hooks;

using LambdaTestSpecflowSelenium.Tests.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

[Binding]
public class HookInitialization
{
    private readonly ScenarioContext scenarioContext;

    public HookInitialization(ScenarioContext scenarioContext) => this.scenarioContext = scenarioContext;

    [BeforeScenario]
    public void BeforeScenario()
    {
        SeleniumDriver seleniumDriver = new(this.scenarioContext);
        this.scenarioContext.Set(seleniumDriver, "SeleniumDriver");
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Selenium webdriver quit");
        this.scenarioContext.Get<IWebDriver>("WebDriver").Quit();
    }
}
