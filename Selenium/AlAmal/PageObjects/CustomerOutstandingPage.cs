using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class CustomerOutstandingPage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By CustomerOutstanding = By.CssSelector("#liCustomerOutstanding > a");
        By Filter = By.CssSelector("img[src='../images/ts.png']");
        By SearchOutstanding = By.CssSelector("#cphContent_btnSeachSubChannel");
        By TotalOutstandingAmount = By.Id("cphContent_lblOutstandingAmount");
        By FromDate = By.Id("cphContent_txtStartDate");
        By PreviousMonth = By.Id("cphContent_ceStartDate_prevArrow");
        By SelectDay = By.Id("cphContent_ceStartDate_day_0_6");

        public CustomerOutstandingPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToCustomerOutstandingPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(CustomerOutstanding);
        }

        public void FilterToSearchCustomer(String customercode, String fromdate)
        {
            BrowserActions.Click(Filter);
            SelectCustomer(customercode);
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


        public double VerifyOutstandingBalance()
        {
            double TotalOutAmount = BrowserActions.GetDoubleValue(TotalOutstandingAmount);
            return TotalOutAmount;
        }

        public List<double> OutStandingLinesGetText(string Invoicenumber)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + Invoicenumber + "' ]]"));
            WaitUtil.ShortSleep();
            double PendingCheque = double.Parse(row.FindElement(By.XPath(".//td[11]/span[contains(@id,'cphContent_gvLocation_lblAttribute1_')]")).GetAttribute("title"));
            double OutStandingAmount = double.Parse(row.FindElement(By.XPath(".//td[12]/span[contains(@id,'cphContent_gvLocation_lblOutStandingAmount_')]")).GetAttribute("title"));
            return new List<double> { PendingCheque, OutStandingAmount };

        }
    }
}
