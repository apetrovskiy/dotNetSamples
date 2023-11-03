// <copyright file="SeleniumDriver.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace LambdaTestSpecflowSelenium.Tests.Drivers;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

public class SeleniumDriver
{
    private readonly ScenarioContext scenarioContext;

    private IWebDriver driver;

    public SeleniumDriver(ScenarioContext scenarioContext) => this.scenarioContext = scenarioContext;

    public IWebDriver Setup()
    {
        // Hardcoded FirefoxOption
        var firefoxOptions = new FirefoxOptions();

        this.driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxOptions.ToCapabilities());

        // Set the driver
        this.scenarioContext.Set(this.driver, "WebDriver");
        this.driver.Manage().Window.Maximize();
        return this.driver;
    }
}
