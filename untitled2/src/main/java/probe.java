package org.openqa.selenium.example;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxProfile;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.WebDriverWait;

import org.openqa.selenium.Capabilities;
import org.openqa.selenium.HasCapabilities;
import org.openqa.selenium.WebDriverBackedSelenium;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.io.File;

public class probe  {
    public static void main(String[] args) {
        // Create a new instance of the Firefox driver
        // Notice that the remainder of the code relies on the interface, 
        // not the implementation.
        WebDriver driver = new FirefoxDriver();

        // And now use this to visit Google
        driver.get("http://www.google.com");
        // Alternatively the same thing can be done like this
        // driver.navigate().to("http://www.google.com");

        // Find the text input element by its name
        WebElement element = driver.findElement(By.name("q"));

        // Enter something to search for
        element.sendKeys("Cheese!");

        // Now submit the form. WebDriver will find the form for us from the element
        element.submit();

        // Check the title of the page
        System.out.println("Page title is: " + driver.getTitle());

        // Google's search is rendered dynamically with JavaScript.
        // Wait for the page to load, timeout after 10 seconds
        (new WebDriverWait(driver, 10)).until(new ExpectedCondition<Boolean>() {
            public Boolean apply(WebDriver d) {
                return d.getTitle().toLowerCase().startsWith("cheese!");
            }
        });

        // Should see: "cheese! - Google Search"
        System.out.println("Page title is: " + driver.getTitle());

        // a new browser from a profile
        //FirefoxProfile profileFF = new FirefoxProfile();
        //profileFF.addAdditionalPreference("general.useragent.override", "some UA string");
        //WebDriver driverFF = new FirefoxDriver(profileFF);
                //((profileFF);
        File file = new File("C:\\Users\\APetrovsky\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\vl-at-sp");
        //Directory
        System.out.println(file.toPath());
        FirefoxProfile profileFF = new FirefoxProfile(file);
                //();
        //profileFF.
        DesiredCapabilities capabillities = new DesiredCapabilities();
        //Capabilities capabillities = new DesiredCapabilities();
        capabillities.setCapability(FirefoxDriver.PROFILE, profileFF);
        //WebDriver driverFF = new RemoteWebDriver(new java.net.URL("http://vl-at-sp:8888/"), capabillities);
        WebDriver driverFF = new FirefoxDriver(profileFF);


        // SharePoint
        driverFF.get("http://vl-at-sp:7777/sites/coll50/");

        // menu Site actions
        WebElement elementMenu = driverFF.findElement(By.id("zz10_SiteActionsMenu_t"));
        elementMenu.click();



        //Close the browser
        driver.quit();

        //driverFF.quit();
    }
}