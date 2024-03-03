using ArlaFunctionalTests.TestSetup;
using ArlaFunctionalTests.TestUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.PageObjects
{
    public class HomePage : BasePage
    {
        By LogoutLink = By.Id("lbLogout");
        By ClickHereLink = By.XPath("//a[@href='Login.aspx']");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Logout()
        {
            BrowserActions.Click(LogoutLink);

        }

        public void ClickHereToLoginAgain()
        { 
            BrowserActions.Click(ClickHereLink);
        }
    }
}
