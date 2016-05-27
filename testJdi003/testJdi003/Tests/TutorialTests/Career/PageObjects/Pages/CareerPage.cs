namespace testJdi003.Tests.TutorialTests.Career.PageObjects.Pages
{
    using Epam.JDI.Web.Attributes;
    using Epam.JDI.Web.Selenium.Elements.Composite;
    using Sections;

    public class CareerPage : WebPage
    {
        [FindBy(ClassName = "job-search")]
        public JobFilter jobFilter;

    }
}