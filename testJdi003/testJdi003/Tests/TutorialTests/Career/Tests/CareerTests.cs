namespace testJdi003.Tests.TutorialTests.Career.Tests
{
    using System.Diagnostics;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PageObjects;
    using PageObjects.Entities;
    using PageObjects.Enums;

    [TestClass]
    public class CareerTests : TestsBase
    {
        [TestInitialize()]
        public void before()
        {
            MethodBase method = new StackTrace().GetFrame(0).GetMethod();
            PreconditionsState.isInState(Preconditions.HOME_PAGE, method);
        }


        [TestMethod]
        public void sendCVTest(Attendee attendee)
        {
            EpamSite.headerMenu.Select(HeaderMenu.CAREERS);

            EpamSite.careerPage.CheckOpened();
            EpamSite.careerPage.jobFilter.Search(attendee.filter);

            EpamSite.jobListingPage.CheckOpened();
            new Check("Table is not empty").isFalse(EpamSite.jobListingPage.jobsList.IsEmpty);
            EpamSite.jobListingPage.getJobRowByName("Senior QA Automation Engineer");

            EpamSite.jobDescriptionPage.addCVForm.Submit(attendee);
            new Check("Captcha").contains(() => EpamSite.jobDescriptionPage.captcha.GetAttribute("class"),
                "form-field-error");
        }
    }
}