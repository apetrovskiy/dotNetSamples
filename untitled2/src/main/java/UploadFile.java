import java.awt.AWTException;
import java.awt.Robot;
import java.awt.event.KeyEvent;
import java.util.concurrent.TimeUnit;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import org.openqa.selenium.firefox.FirefoxDriver;

public class UploadFile {

    /**
     * @param args
     * @throws InterruptedException
     */
    public static void main(String[] args) throws InterruptedException {

        //System.setProperty("webdriver.chrome.driver", ".\\lib\\chromedriver.exe");
        //WebDriver driver = new ChromeDriver();
        WebDriver driver = new FirefoxDriver();

        //WebDriver driver = new FirefoxDriver();
        driver.manage().timeouts().implicitlyWait(30, TimeUnit.SECONDS);

        driver.get("http://hotfile.com/");
        driver.findElement(By.name("uploads[]")).click();

        //Alternative, but if this path is absent? We have only button
        //driver.findElement(By.name("uploads[]")).sendKeys("C:\\1.jpg");

        Thread.sleep(3000);
        // Print File path C:\1.jpg

        try {
            Robot robot = new Robot();
            //robot.delay(3000);
            robot.keyPress(KeyEvent.VK_C);
            robot.keyPress(KeyEvent.VK_SHIFT);
            robot.keyPress(KeyEvent.VK_SEMICOLON);
            robot.keyRelease(KeyEvent.VK_SEMICOLON);
            robot.keyRelease(KeyEvent.VK_SHIFT);
            robot.keyPress(KeyEvent.VK_BACK_SLASH);
            robot.keyPress(KeyEvent.VK_1);
            robot.keyPress(KeyEvent.VK_PERIOD);
            robot.keyPress(KeyEvent.VK_J);
            robot.keyPress(KeyEvent.VK_P);
            robot.keyPress(KeyEvent.VK_G);
            robot.delay(2000);
            robot.keyPress(KeyEvent.VK_ENTER);
        }
        catch (AWTException e) {
            e.printStackTrace();
            System.out.println(e.toString());
        }
    }
}
