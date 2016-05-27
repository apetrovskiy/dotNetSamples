﻿namespace testJdi003.Tests.TutorialTests.Career.PageObjects.Sections
{
    using Entities;
    using Enums;
    using Epam.JDI.Core.Interfaces.Common;
    using Epam.JDI.Core.Interfaces.Complex;
    using Epam.JDI.Web.Attributes;
    using Epam.JDI.Web.Selenium.Elements.Composite;

    public class JobFilter : Form<JobSearchFilter>
    {
        [FindBy(ClassName = "job-search-input")]
        public ITextField keywords;
        //public IDropDown<JobCategories> category =
        //        new Dropdown<>(By.ClassName("multi-select-filter"), By.ClassName("blue-checkbox-label"));
        [FindBy(ClassName = "career-location-box")]
        public IDropDown<Locations> city;

        [FindBy(ClassName = "job-search-button")]
        public IButton selectButton;

    }
}
