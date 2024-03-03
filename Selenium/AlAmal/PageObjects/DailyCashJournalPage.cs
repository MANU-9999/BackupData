using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class DailyCashJournalPage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By DCJournal = By.CssSelector("a[href='../pages/DailyCashJournal.aspx']");
        By FilterButton = By.XPath("//img[@src='../images/ts.png']");
        By SalesOrg = By.XPath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
        By SalesOrgCheckBox = By.Id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
        By SelectUser = By.Id("lnkShowCustomers");
        By UserCodeTextBox = By.Id("txtUserCode");
        By CheckBox = By.XPath("//input[@class='clsUserCodes']");
        By DoneButton = By.Id("btnSelDone");
        By UserSearchButton = By.Id("btnSeachSubChannel");

        By FilterSubmitButton = By.XPath("//input[@id='cphContent_btnSeach']");
        By ActionButton = By.XPath("(//img[@alt='View Details'])[1]");

        By TotalCashAmount = By.Id("cphContent_lblCashAmount");

        By TotalOnlineAmount = By.Id("cphContent_lblOnlineAmount");
        By TotalPOSAmount = By.Id("cphContent_lblPOSOnlineAmount");
        By TotalChequeAmount = By.Id("cphContent_lblChequeAmount");
        By FromDate = By.Id("cphContent_txtDate");


        public DailyCashJournalPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToDailyCashJournal()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(DCJournal);
            WaitUtil.WaitForLoaderToComplete();
        }

        public void FilterWithUser(String usercode)
        {
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
            WaitUtil.ShortSleep();
            BrowserActions.Click(CheckBox);
            BrowserActions.Zoomout();


            //When Done button is visible 
            BrowserActions.Click(DoneButton);
            BrowserActions.Click(FilterSubmitButton);
            //WaitUtil.ShortSleep();
        }

        public double CaptureTotalCashAmount()
        {
            //BrowserActions.GetText(TotalCashAmount);
            double CashAmount = BrowserActions.GetDoubleValue(TotalCashAmount);
            return CashAmount;

        }

        public double CaptureTotalOnlineAmount()
        {
            //BrowserActions.GetText(TotalCashAmount);
            double CashAmount = BrowserActions.GetDoubleValue(TotalOnlineAmount);
            return CashAmount;

        }

        public double CaptureTotalPOSAmount()
        {
            double POSAmount = BrowserActions.GetDoubleValue(TotalPOSAmount);
            return POSAmount;

        }

        public void DailyCashJoournalFilter(string UserCode, string fromdate)
        {
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            WaitUtil.WaitForElementTOBeClickable(FilterButton);
            BrowserActions.Click(FilterButton);
            BrowserActions.Click(SalesOrg);
            BrowserActions.Click(SalesOrgCheckBox);
            BrowserActions.SelectDate(FromDate, fromdate);
            collectionSettlementPage.SelectUser(UserCode);
            //BrowserActions.Click(FilterSubmitButton);
        }

        public string DCJConfirmation(string UserCode, string setteledAmountAmount)
        {
            //IWebElement row = driver.FindElement(By.XPath("//tr[td/span[contains(@title,'"+ UserCode + "')] and td/span[contains(@id,'cphContent_gvPayment_lblCollection_')]]"));
            IWebElement row = driver.FindElement
           (By.XPath("//tr[td/span[contains(@title,'" + UserCode + "')] and td/span[contains(@title,'" + setteledAmountAmount + "')]]"));
            string amount = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvPayment_lblCollection_')]")).GetAttribute("title");
            return amount;

        }

        public double CaptureTotalChequeAmount()
        {
            double POSAmount = BrowserActions.GetDoubleValue(TotalChequeAmount);
            return POSAmount;

        }




    }
}
