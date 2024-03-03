using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class POSCollectionSettlementPage : BasePage
    {

        By TransactionsMenu = By.Id("ancSfaTransactions");
        By POSCollectionSettlementLink = By.Id("liPOSCollectionSettlement");
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





        public POSCollectionSettlementPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToPOSCollectionSettlement()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(POSCollectionSettlementLink);
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

        public void ClickBounceTabAndRouteLink()
        {
            BrowserActions.Click(BouncedTab);
            BrowserActions.Click(RouteLink);
            WaitUtil.ShortSleep();

        }

        public void FilterWithReceipt(string receiptnumber)
        {
            BrowserActions.Click(ClickOnFilter);
            WaitUtil.Sleep5sec();
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButton);

        }

        public int VerifyRowCount()
        {
            int i = BrowserActions.GetRowCount(Table);
            return i;
        }


        public void POSBounce()
        {
            BrowserActions.Click(RouteLink);
            BrowserActions.Click(StatusCheckBox);
            BrowserActions.Click(BounceButton);
            BrowserActions.AlertPopAccept();
            WaitUtil.ShortSleep();

        }
    }
}
