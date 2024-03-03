package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;

public class HomePage extends Base {

    By logoutLink = By.id("lbLogout");
    By clickHereLink = By.xpath("//a[@href='Login.aspx']");
    By divLoader = By.id("divLoader");

    public void logout() {
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.shortSleep();
        BrowserActions.WaitAndclick(logoutLink);
        WaitUtil.Sleep5();
    }

    public void clickHereToLoginAgain() {
        BrowserActions.WaitAndclick(clickHereLink);
    }
}
