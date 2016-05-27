namespace testJdi003.Tests.TutorialTests.Career.PageObjects.Pages
{
    using Epam.JDI.Core.Interfaces.Base;
    using Epam.JDI.Web.Attributes;
    using Epam.JDI.Web.Selenium.Elements.Composite;
    using Sections;

    public class JobDescriptionPage : WebPage
    {
        [FindBy(Css = ".form-constructor")]
        public AddCVForm addCVForm;

        [FindBy(Id = "captcha-input")]
        public IElement captcha;

    }
}