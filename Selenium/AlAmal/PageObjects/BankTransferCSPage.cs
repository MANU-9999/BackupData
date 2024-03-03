using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class BankTransferCSPage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By BankSettlementLink = By.XPath("//a[normalize-space()='Bank Transfer Collection Settlement']");
        By ListOfSalesMan = By.XPath("(//tr[@class='gridrow cls_gridrownew1'])");
        //Filter
        By ClickOnFilter = By.XPath("//img[@src='../images/ts.png']");
        By SalesManDropDown = By.XPath("//span[normalize-space()='Select Salesman']");
        By EnterUSERCODE = By.XPath("(//input[@placeholder='Enter keywords'])[1]");
        By FilterSearchButton = By.Id("cphContent_btnSeachSubChannel");
        By CheckAll = By.XPath("(//span[contains(text(),'Check all')])[1]");
        //Select The Route
        By RouteLink = By.XPath("//a[@id='cphContent_gvPDCDetails_lnkView_0']");
        //Selecting all the List Of Receipt In BankSettlement
        By BankListOfReceipts = By.XPath("//a[@class='cls_ordernwe Receipt_Number']");
        By BankReceiptCheckBox = By.XPath(".//input[@type='checkbox']");
        By BounceButton = By.XPath("//a[@id='cphContent_lnkReject']");
        By StatusCheckBox = By.Id("cphContent_gvCollected_chkCheque_0");
        By FilterButton = By.XPath("//img[@src='../images/ts.png']");
        By ReceiptNumber = By.Id("cphContent_txtReceiptNumber");
        By ReceiptSearchButton = By.Id("cphContent_btnSeachClient");
        By ReceiptNUM = By.Id("cphContent_gvCollected_lnkReceiptNumber_0");

        public BankTransferCSPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToBankSettlementPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(BankSettlementLink);
        }

        public void FilterSalesman(String userCode)
        {
            BrowserActions.Click(ClickOnFilter);
            WaitUtil.ShortSleep();
            BrowserActions.Click(SalesManDropDown);
            BrowserActions.Click(EnterUSERCODE);
            BrowserActions.Type(EnterUSERCODE, userCode);
            BrowserActions.Click(CheckAll);
            //BrowserActions.Select(EnterUSERCODE,userCode);
            BrowserActions.Click(FilterSearchButton);
        }
        public void ClickOnRoute()
        {
            BrowserActions.Click(RouteLink);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.ShortSleep();
        }

        public List<IWebElement> ListOfBAnkReceiptNumbers()
        {


            List<IWebElement> BankReceiptNumberList = BrowserActions.FindElements(BankListOfReceipts);
            List<string> BankreceiptTextArray = BankReceiptNumberList.Select(element => element.Text).ToList();
            Console.WriteLine(BankreceiptTextArray);


            return BankReceiptNumberList;


        }
        public IWebElement GetBankCheckboxForReceipt(IWebElement BankReceiptNumberList)
        {
            try
            {

                return BankReceiptNumberList.FindElement(BankReceiptCheckBox);
            }
            catch (NoSuchElementException)
            {
                // Handle the case where the checkbox was not found
                return null;
            }
        }

        public void BounceTheBAnkReceipt()
        {
            BrowserActions.Click(StatusCheckBox);
            BrowserActions.Click(BounceButton);
            BrowserActions.AlertPopAccept();
        }


        public string VerifyBoucedReceipt(string receiptnumber)
        {
            BrowserActions.Click(RouteLink);
            BrowserActions.Click(FilterButton);
            WaitUtil.Sleep5sec();
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButton);
            string num = BrowserActions.GetText(ReceiptNUM);
            return num;
        }

        public void FilterWithReceipt(string receiptnumber)
        {

            BrowserActions.Click(FilterButton);
            WaitUtil.Sleep5sec();
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButton);

        }


    }
}
