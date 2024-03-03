using ArlaFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.PageObjects
{

    public class BasePage
    {
        By SelectCustomerLink = By.XPath("//*[text()='Select Customer']");
        //By SelectCustomerLink = By.CssSelector("div.new_slidea>a#lnkShowCustomers");
        By Customer = By.Id("txtSiteId");
        By SearchButton = By.XPath("//input[@onclick='return CustomerSearch();']");
        By CheckBox = By.Name("chkCustomer");
        //By CheckBox = By.XPath("//*[@id='tblCustomerUC']/tbody/tr[1]");
        By DoneButton = By.Id("btnSelDone");

        By SelectUserLink = By.XPath("//a[@id='lnkShowCustomers']");
        By USER = By.Id("txtUserCode");
       
        By UserSearchButton = By.XPath("//input[@id='btnSeachSubChannel']");
       
        By USERCHECKBOX = By.XPath("//input[@class='clsUserCodes']");
        //By CheckBox = By.XPath("//*[@id='tblCustomerUC']/tbody/tr[1]");

        public IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectCustomer(string customercode) 
        {
            BrowserActions.Click(SelectCustomerLink);
            BrowserActions.Type(Customer, customercode);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Click(SearchButton);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.Sleep5sec();
            BrowserActions.Click(CheckBox);
            BrowserActions.ClickTab();
            BrowserActions.ClickEnter();
            //BrowserActions.Click(DoneButton);
            WaitUtil.WaitForLoaderToComplete();

        }

        public void SelectUser(string user)
        {
            BrowserActions.Click(SelectUserLink);
            BrowserActions.Type(USER, user);
            WaitUtil.WaitForLoaderToComplete();

            BrowserActions.Click(UserSearchButton);
            WaitUtil.WaitForLoaderToComplete();
            Thread.Sleep(3000);
            BrowserActions.Click(USERCHECKBOX);
            BrowserActions.ClickTab();
            BrowserActions.ClickEnter();

            //BrowserActions.Click(DoneButton);
            // BrowserActions.ClickEnter();
            //BrowserActions.Click(DoneButton);
            WaitUtil.WaitForLoaderToComplete();

        }



       
    }
}
