package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.testng.Assert;

public class LoginPage extends Base {

    private By userNameTextBox = By.cssSelector("input#txtUsername");
    private By passwordTextBox = By.cssSelector("input#txtPassword");
    By loginButton = By.id("btnLogin");
    By DoneButton = By.id("btnNavigate");
    By InvalidLoginError = By.cssSelector("span#lblErrorMessage");

    public void Validlogin(String userName, String password) throws InterruptedException {
        setUserNameAndPassword(userName, password);
        WaitUtil.shortSleep();
        userTypeSelect();
        WaitUtil.Sleep5();
    }

    public void Invalidlogin(String userName, String password) {
        setUserNameAndPassword(userName, password);
        WaitUtil.shortSleep();

        String InvalidLogin = BrowserActions.GetText(InvalidLoginError).toString();
        Assert.assertTrue(InvalidLogin.contains("Invalid"), InvalidLogin);
        System.out.println(InvalidLoginError);
    }

    public void setUserNameAndPassword(String userName, String password) {
        BrowserActions.typeValue(userNameTextBox, userName);
        BrowserActions.typeValue(passwordTextBox, password);
        BrowserActions.WaitAndclick(loginButton);
    }

    public void userTypeSelect() {
        WebElement checkbox = driver.findElement(By.xpath("//div/input[contains(@id,'chk_KSA Sales Super User_')]"));
        if (!checkbox.isSelected()) {
            checkbox.click();
        }
        BrowserActions.WaitAndclick(DoneButton);
    }

    public void CashierLogin(String cashieruser, String cashierpassword) {
        BrowserActions.Type(userNameTextBox, cashieruser);
        BrowserActions.Type(passwordTextBox, cashierpassword);
        BrowserActions.Click(loginButton);
        WaitUtil.WaitForLoaderToComplete();
    }

    public void AdminLogin(String username, String password) {
        BrowserActions.Type(userNameTextBox, username);
        BrowserActions.Type(passwordTextBox, password);
        BrowserActions.Click(loginButton);
        WaitUtil.WaitForLoaderToComplete();
    }

}
