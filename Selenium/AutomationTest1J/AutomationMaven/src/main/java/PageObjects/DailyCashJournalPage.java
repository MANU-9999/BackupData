package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

public class DailyCashJournalPage extends Base {
    By TransactionsMenu = By.id("ancSfaTransactions");
    By DCJournal = By.cssSelector("a[href='../pages/DailyCashJournal.aspx']");
    By FilterButton = By.xpath("//img[@src='../images/ts.png']");
    By SalesOrg = By.xpath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
    By SalesOrgCheckBox = By.id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
    By SelectUser = By.id("lnkShowCustomers");
    By UserCodeTextBox = By.id("txtUserCode");
    By CheckBox = By.xpath("//input[@class='clsUserCodes']");
    By DoneButton = By.id("btnSelDone");
    By UserSearchButton = By.id("btnSeachSubChannel");

    By FilterSubmitButton = By.xpath("//input[@id='cphContent_btnSeach']");
    By ActionButton = By.xpath("(//img[@alt='View Details'])[1]");

    By TotalCashAmount = By.id("cphContent_lblCashAmount");

    By TotalOnlineAmount = By.id("cphContent_lblOnlineAmount");
    By TotalPOSAmount = By.id("cphContent_lblPOSOnlineAmount");
    By TotalChequeAmount = By.id("cphContent_lblChequeAmount");
    By FromDate = By.id("cphContent_txtDate");

    public void NavigateToDailyCashJournal() {
        BrowserActions.Click(TransactionsMenu);
        BrowserActions.Click(DCJournal);
        WaitUtil.WaitForLoaderToComplete();
    }

    public void FilterWithUser(String usercode) {
        BrowserActions.Click(FilterButton);
        BrowserActions.Click(SalesOrg);
        BrowserActions.Click(SalesOrgCheckBox);
        //SelectUser method below can be used if the enter key issue in the pop up is solved
        //And remaining lines can be commented.
        //SelectUser(userCode);
        BrowserActions.Click(SelectUser);
        BrowserActions.Click(UserCodeTextBox);
        BrowserActions.Type(UserCodeTextBox, usercode);
        BrowserActions.Click(UserSearchButton);
        WaitUtil.shortSleep();
        BrowserActions.Click(CheckBox);
        BrowserActions.Zoomout();


        //When Done button is visible
        BrowserActions.Click(DoneButton);
        BrowserActions.Click(FilterSubmitButton);
        //WaitUtil.ShortSleep();
    }

    public double CaptureTotalCashAmount() {
        //BrowserActions.GetText(TotalCashAmount);
        double CashAmount = BrowserActions.GetDoubleValue(TotalCashAmount);
        return CashAmount;

    }

    public double CaptureTotalOnlineAmount() {
        //BrowserActions.GetText(TotalCashAmount);
        double CashAmount = BrowserActions.GetDoubleValue(TotalOnlineAmount);
        return CashAmount;

    }

    public double CaptureTotalPOSAmount() {
        double POSAmount = BrowserActions.GetDoubleValue(TotalPOSAmount);
        return POSAmount;

    }

    public void DailyCashJoournalFilter(String UserCode, String fromdate) {
        WaitUtil.waitForElementToBeClickable(FilterButton);
        BrowserActions.Click(FilterButton);
        BrowserActions.Click(SalesOrg);
        BrowserActions.Click(SalesOrgCheckBox);
        BrowserActions.SelectDate(FromDate, fromdate);
        RepitativeMethodsPage.SelectUser(UserCode);
        //BrowserActions.Click(FilterSubmitButton);
    }

    public static String DCJConfirmation(String UserCode, String setteledAmountAmount) {
        WebElement row = driver.findElement(By.xpath("//tr[td/span[contains(@title,'" + UserCode + "')] and td/span[contains(@title,'" + setteledAmountAmount + "')]]"));
        String amount = row.findElement(By.xpath(".//td/span[contains(@id,'cphContent_gvPayment_lblCollection_')]")).getAttribute("title");
        return amount;
    }

    public double CaptureTotalChequeAmount() {
        double POSAmount = BrowserActions.GetDoubleValue(TotalChequeAmount);
        return POSAmount;

    }
}
