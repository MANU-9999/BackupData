using ArlaFunctionalTests.TestUtils;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.PageObjects
{
    public class ImportVanstockPage : BasePage
    {
        By AdminstrationMenu = By.Id("ancSfaAdministration");
        By Import_Vanstock = By.LinkText("Import Vanstock");

        By ImportButton = By.CssSelector("a#lnkImportCustomer");
        By DropFilePopUp = By.CssSelector("div div div.dz-default.dz-message");
        By Done = By.CssSelector("div input#cphContent_btnUpload");

        public ImportVanstockPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToImportVanstock()
        {
            BrowserActions.Click(AdminstrationMenu);
            BrowserActions.Click(Import_Vanstock);
            WaitUtil.WaitForLoaderToComplete();
        }

        public void ImportVanstockfile(string filename)
        {
            BrowserActions.Click(ImportButton);
            BrowserActions.Click(DropFilePopUp);
            WaitUtil.ShortSleep();
            BrowserActions.ImportfileFormat(filename);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(Done);
            WaitUtil.ShortSleep();
        }


    }
}

