package PageObjects;

import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;

public class RepitativeMethodsPage {
    static By SelectCustomerLink = By.xpath("//*[text()='Select Customer']");
    static By Customer = By.id("txtSiteId");
    static By SearchButton = By.xpath("//input[@onclick='return CustomerSearch();']");
    static By CheckBox = By.name("chkCustomer");
    By DoneButton = By.id("btnSelDone");
    static By SelectUserLink = By.xpath("//a[@id='lnkShowCustomers']");
    static By USER = By.id("txtUserCode");
    static By UserSearchButton = By.xpath("//input[@id='btnSeachSubChannel']");
    static By USERCHECKBOX = By.xpath("//input[@class='clsUserCodes']");

    public static void SelectCustomer(String customercode) {
        BrowserActions.Click(SelectCustomerLink);
        BrowserActions.Type(Customer, customercode);
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(SearchButton);
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.Sleep5();
        BrowserActions.Click(CheckBox);
        BrowserActions.ClickTab();
        BrowserActions.ClickEnter();
        // BrowserActions.Click(DoneButton);
        WaitUtil.WaitForLoaderToComplete();

    }

    public static void SelectUser(String user) {
        BrowserActions.Click(SelectUserLink);
        WaitUtil.shortSleep();
        BrowserActions.Type(USER, user);
        WaitUtil.WaitForLoaderToComplete();

        BrowserActions.Click(UserSearchButton);
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.Sleep5();
        BrowserActions.Click(USERCHECKBOX);
        BrowserActions.ClickTab();
        BrowserActions.ClickEnter();

        // BrowserActions.Click(DoneButton);
        // BrowserActions.ClickEnter();
        // BrowserActions.Click(DoneButton);
        WaitUtil.WaitForLoaderToComplete();

    }
}
