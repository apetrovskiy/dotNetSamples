﻿namespace testJdi003.Tests.TutorialTests.Career.PageObjects.Pages
{
    using System;
    using System.Linq;
    using Enums;
    using Epam.JDI.Web.Attributes;
    using Epam.JDI.Web.Selenium.Elements.Complex.table;
    using Epam.JDI.Web.Selenium.Elements.Complex.table.interfaces;
    using Epam.JDI.Web.Selenium.Elements.Composite;
    using OpenQA.Selenium;

    public class JobListingPage : WebPage
    {
        [FindBy(ClassName = "search-result-list")]
        public ITable jobsList = (ITable)new Table(null,
            By.XPath(".//li[%s]//div"),
            By.XPath(".//li//div[%s]"))
            .HasColumnHeaders(Enum.GetNames(typeof(JobListHeaders)).ToList());

        public void getJobRowByName(string jobName)
        {
            // it is java
            //MapArray<String, ICell> row = jobsList.row(jobName, column(JOB_NAME.toString()));
            //row.get(APPLY.toString()).select();
        }

    }
}