package TestSetUp;

import PageObjects.LoginPage;
import driverManagerFactory.DriverManager;
import driverManagerFactory.DriverManagerFactory;
import driverManagerFactory.DriverType;
import org.openqa.selenium.WebDriver;
import org.testng.annotations.AfterClass;
import org.testng.annotations.BeforeClass;

public class Base {

    public static WebDriver driver;
    DriverManager driverManager;
    LoginPage loginPage;

    @BeforeClass
    public void setup() throws InterruptedException {
        System.out.println("Setting up the test environment...");
        driverManager = DriverManagerFactory.getDriveManager(DriverType.CHROME);
        driver = driverManager.getWebDriver();
        driver.get("https://dev-arlavansales.winitsoftware.com/pages/Login.aspx");
        driver.manage().window().maximize();

        loginPage = new LoginPage();
        loginPage.Validlogin("ksaadmin", "1234");
    }

    @AfterClass
    public void tearDown() {
        if (driver != null) {
            //	driver.quit();
        }
    }

}
