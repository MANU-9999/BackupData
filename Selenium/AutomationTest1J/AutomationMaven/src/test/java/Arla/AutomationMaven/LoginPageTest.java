package Arla.AutomationMaven;

import PageObjects.HomePage;
import PageObjects.LoginPage;
import TestSetUp.Base;
import org.testng.annotations.AfterTest;
import org.testng.annotations.Test;

public class LoginPageTest extends Base {
    LoginPage loginPage;
    HomePage homePage;

    @Test
    public void validLoginTest() throws InterruptedException {
        // Make sure the driver is initialized in your Base class or setup method
        homePage = new HomePage();
        homePage.logout();
        homePage.clickHereToLoginAgain();

        loginPage = new LoginPage();
        loginPage.Validlogin("ksaadmin", "1234");
    }

    @Test(dependsOnMethods = "validLoginTest")
    public void invalidLoginTest() throws InterruptedException {
        // Make sure the driver is initialized in your Base class or setup method
        homePage = new HomePage();
        homePage.logout();
        homePage.clickHereToLoginAgain();

        loginPage = new LoginPage();
        loginPage.Invalidlogin("ksaadmin", "12345");
    }

    @AfterTest
    public void tearDown() {
        if (driver != null) {
            driver.quit();
        }
    }
}
