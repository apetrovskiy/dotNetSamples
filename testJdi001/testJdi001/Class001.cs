namespace testJdi001
{
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using Epam.JDI.Core.Interfaces.Complex; 
    using Epam.JDI.Web.Attributes; 
    using Epam.JDI.Web.Selenium.Elements.Common; 
    using System.Collections.Generic; 
    using Epam.JDI.Web.Selenium.Elements.Composite; 
    using Epam.Tests.TutorialTests.Dummies.JDI;
    using Epam.JDI.Web.Selenium.Elements.Complex.table;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using static Epam.JDI.Web.Selenium.DriverFactory.WebDriverUtils;


    // @JSite(domain = "https://www.epam.com")
    [Site(domain)]
    public class EpamSite : WebSite // extends WebSite
    {

        //// @JPage(url = "/", title = "EPAM | Software Product Development Services")
        //// [page]
        //public static HomePage homePage;
        //// @JPage(url = "/careers", title = "Careers")
        //public static CareerPage careerPage;
        //...

        //// @FindBy(css = ".tile-menu>li>a")              // Menu with limited list of options described by enum Header menu
        //public static Menu<HeaderMenu> headerMenu;
        //// @FindBy(css = ".tile-menu>li>a")              // List of elements accessible only by index
        //public static List<Label> listMenu;
        //// @FindBy(css = ".tile-menu>li>a")              // List of elements with ability to access by name
        //public static Elements<Label> listMenu;
    }
}