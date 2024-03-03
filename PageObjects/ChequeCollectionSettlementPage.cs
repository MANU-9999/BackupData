using ArlaFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.PageObjects
{
    public class ChequeCollectionSettlementPage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By ChequeSettlementLink = By.Id("liChequeCollectionSetelement");
        By ClickOnFilter = By.XPath("//img[@src='../images/ts.png']");
        By SalesManDropDown = By.XPath("//span[normalize-space()='Select Salesman']");
        By EnterUSERCODE = By.XPath("(//input[@placeholder='Enter keywords'])[1]");
        By FilterSearchButton = By.Id("cphContent_btnSeachSubChannel");
        By CheckAll = By.XPath("(//span[contains(text(),'Check all')])[1]");
        By RouteLink = By.XPath("//a[@id='cphContent_gvPDCDetails_lnkView_0']");
        By ReceiptNumber = By.Id("cphContent_txtReceiptNumber");
        By ReceiptSearchButton = By.Id("cphContent_btnSeachClient");
        By ReceiptLink = By.Id("cphContent_gvCollected_lnkReceiptNumber_0");
        By Cancelbutton = By.Id("cphContent_lnkCancelPayment");
        By Yes = By.Id("cphContent_lnkCancelPaymentConfirm");

        By BounceButton = By.XPath("//a[@id='cphContent_lnkReject']");
        By StatusCheckBox = By.Id("cphContent_gvCollected_chkCheque_0");
        By BouncedTab = By.Id("cphContent_lnkBounced");
        By Table = By.Id("cphContent_gvCollected");
        By ConfirmPopUpOKButton = By.Id("cphContent_lnkmultipleLevel1");
      
        By ApprovedButton = By.Id("cphContent_lnkSubmit");

        public ChequeCollectionSettlementPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToChequeCSPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(ChequeSettlementLink);
            WaitUtil.WaitForLoaderToComplete();

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
            Thread.Sleep(5000);
            BrowserActions.Click(RouteLink);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.ShortSleep();

        }
        public void FilterWithReceiptAndCancel(string receiptnumber)
        {
            BrowserActions.Click(ClickOnFilter);
            WaitUtil.Sleep5sec();
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButton);
            BrowserActions.Click(ReceiptLink);
            BrowserActions.Click(Cancelbutton);
            BrowserActions.Click(Yes);
        }

        public void FilterWithReceipt(string receiptnumber)
        {
            BrowserActions.Click(ClickOnFilter);           
            WaitUtil.Sleep5sec();          
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButton);
            
        }

       

        public void Bounce()
        {
            BrowserActions.Click(StatusCheckBox);
            BrowserActions.Click(BounceButton);
            BrowserActions.AlertPopAccept();
            WaitUtil.ShortSleep();
        }

        public void ClickBounceTabAndRouteLink()
        {
            BrowserActions.Click(BouncedTab);
            BrowserActions.Click(RouteLink);
            WaitUtil.ShortSleep();
                   
        }

        public int VerifyRowCount()
        {
            int i = BrowserActions.GetRowCount(Table);
            return i;
        }

        public void CancelTheChequePayment()
        {
            BrowserActions.Click(ReceiptLink);
            BrowserActions.Click(Cancelbutton);
            BrowserActions.Click(Yes);
        }

        public void Approve()
        {
            BrowserActions.Click(StatusCheckBox);
            //click Approved is not showing popup in one click. Hence added twice.
            BrowserActions.Click(ApprovedButton);
            BrowserActions.Click(ApprovedButton);
            BrowserActions.Click(ConfirmPopUpOKButton);
            WaitUtil.ShortSleep();

        }

        public void SelectRouteCCS(string UserCode)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td[2]/span[contains(text(),'" + UserCode + "')]]"));
            IWebElement UserRoute = row.FindElement(By.XPath(".//td/a[contains(@id,'cphContent_gvPDCDetails_lnkView_')]"));
            BrowserActions.IWebElementJSFindAndClick(UserRoute);
            WaitUtil.Sleep5sec();
        }

        public void SelectReceiptCCS(string PaymentReceipt)
        {
            IWebElement row1 = driver.FindElement(By.XPath("//tbody/tr[td[6]/a[contains(text(),'" + PaymentReceipt + "')]]")); //'" + ReceiptNumbertext + "'
            IWebElement selectCheques = row1.FindElement(By.XPath(".//input[contains(@id,'cphContent_gvCollected_chkCheque_')]"));
            BrowserActions.IWebElementJSFindAndClick(selectCheques);
        }

        public double ReceiptNumbertext;
        public List<string> AfterPaymentGetDetailsByRow(string number)
        {

            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + number + "' ]][1]"));
            string ReceiptNumberFinalValue = row.FindElement(By.XPath("//tr/td[1]/span[@title]")).GetAttribute("title");
            string PaymentModeFinalValue = row.FindElement(By.XPath("//tr/td[7]/span[@title]")).GetAttribute("title");
            string AmountFinalValue = row.FindElement(By.XPath("//tr/td[9]/span[@title]")).GetAttribute("title");
            ReceiptNumbertext = double.Parse(ReceiptNumberFinalValue);
            return new List<string> { ReceiptNumberFinalValue, PaymentModeFinalValue, AmountFinalValue };
            // ReceiptNumbertext = ReceiptNumberFinalValue;
        }

        public  void FindAndSelectCCS(string UserCode)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td[2]/span[contains(text(),'" + UserCode + "')]]"));
            IWebElement UserRoute = row.FindElement(By.XPath(".//td/a[contains(@id,'cphContent_gvPDCDetails_lnkView_')]"));
            UserRoute.Click();
            WaitUtil.Sleep5sec();
            IWebElement row1 = driver.FindElement(By.XPath("//tbody/tr[td[6]/a[contains(text(),'" + ReceiptNumbertext + "')]]")); //'" + ReceiptNumbertext + "'
            IWebElement selectCheques = row1.FindElement(By.XPath(".//input[contains(@id,'cphContent_gvCollected_chkCheque_')]"));
            selectCheques.Click();


        }






    }
}
