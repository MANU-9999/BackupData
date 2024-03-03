package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import org.openqa.selenium.By;

public class CustomerOutstandingPage extends Base {
    By TransactionsMenu = By.id("ancSfaTransactions");
    By CustomerOutstanding = By.cssSelector("#liCustomerOutstanding > a");
    By Filter = By.cssSelector("img[src='../images/ts.png']");
    By SearchOutstanding = By.cssSelector("#cphContent_btnSeachSubChannel");
    By TotalOutstandingAmount = By.id("cphContent_lblOutstandingAmount");
    By FromDate = By.id("cphContent_txtStartDate");
    By PreviousMonth = By.id("cphContent_ceStartDate_prevArrow");
    By SelectDay = By.id("cphContent_ceStartDate_day_0_6");

    public void NavigateToCustomerOutstandingPage() {
        BrowserActions.Click(TransactionsMenu);
        BrowserActions.Click(CustomerOutstanding);
    }

    public void FilterToSearchCustomer(String customercode, String fromdate) {
        BrowserActions.Click(Filter);
        RepitativeMethodsPage.SelectCustomer(customercode);
        BrowserActions.Click(FromDate);
        BrowserActions.SelectDate(FromDate, fromdate);
        //BrowserActions.Click(FromDate);
        //BrowserActions.Click(PreviousMonth);
        //Thread.Sleep(2000);
        //BrowserActions.Click(PreviousMonth);
        //BrowserActions.Click(SelectDay);
        BrowserActions.Type(FromDate, fromdate);
        BrowserActions.Click(SearchOutstanding);

    }


    public double VerifyOutstandingBalance() {
        double TotalOutAmount = BrowserActions.GetDoubleValue(TotalOutstandingAmount);
        return TotalOutAmount;
    }
}
