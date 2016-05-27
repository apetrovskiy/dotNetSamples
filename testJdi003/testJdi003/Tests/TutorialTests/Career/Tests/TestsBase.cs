namespace testJdi003.Tests.TutorialTests.Career.Tests
{
    using Epam.JDI.Core.Settings;
    using Epam.JDI.Web.Selenium.Elements.Composite;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PageObjects;

    [TestClass]
    public class TestsBase
    {

        [ClassInitialize()]
        public static void setUp()
        {
            WebSite.Init(typeof(EpamSite));
            EpamSite.homePage.Open();
            JDISettings.Logger.Info("Run Tests");
        }

    }
}