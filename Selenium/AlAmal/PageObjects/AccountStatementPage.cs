using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class AccountStatementPage : BasePage
    {

        By FromDate = By.Id("cphContent_txtfDate");
        By Table = By.CssSelector("table[class='grid cls_wid945p']");
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By AccountStatementLink = By.LinkText("Customer Account Statement");
        By SearchButton = By.Id("cphContent_btnSeachSubChannel");
        By Filter = By.CssSelector("img[src='../images/ts.png']");

        public AccountStatementPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToAccStatement()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(AccountStatementLink);

        }


        public void SearchAccStatement(string customercode, string fromdate)
        {
            BrowserActions.Click(Filter);
            BrowserActions.SelectDate(FromDate, fromdate);
            //BrowserActions.ScrollToElement(SelectCustomerLink);
            SelectCustomer(customercode);

            BrowserActions.Click(SearchButton);
            // String time = BrowserActions.GetDateTime(Date);
            // return time;

        }

        public int VerifyRowCount()
        {
            int i = BrowserActions.GetRowCount(Table);
            return i;
        }
    }
}
