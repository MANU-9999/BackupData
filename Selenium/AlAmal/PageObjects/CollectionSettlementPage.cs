using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class CollectionSettlementPage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By CustomerSettlement = By.CssSelector("a[href='../pages/CollectionSetelement.aspx']");
        By ActionButton = By.XPath("(//img[@alt='View Details'])[1]");
        //Filter
        By FilterButton = By.XPath("//img[@src='../images/ts.png']");
        By SalesOrg = By.XPath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
        By SalesOrgCheckBox = By.Id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
        By FilterSubmitButton = By.XPath("//input[@id='cphContent_btnSeach']");
        By LastetInvoice = By.XPath("//a[@id='cphContent_rptrSettlementmain_spanChequeReceiptOA_17']");
        By ListOfReceipts = By.XPath("//a[@class='Receipt_Number']");
        //By SettlementCheckBox = By.XPath(".//input[@type='checkbox']");
        By SettleButton = By.XPath("//a[@id='cphContent_lnkSettle']");
        By CancelReceiptPrint = By.Id("cphContent_lnkClose");

        // By CheckToSettle = By.Id("cphContent_rptrSettlementmain_chkOnline_0");
        By ReceiptNumber = By.Id("cphContent_txtReceiptNumber");
        By ReceiptSearchButtonCS = By.XPath("//*[@id='cphContent_btnSeachSubChannel']");
        By ChequeCollectionSetelement = By.CssSelector("#liChequeCollectionSetelement> a");
        // By CheckToSettleCheque = By.Id("cphContent_rptrSettlementmain_chkCheque_0");

        //By CheckBoxOnline = By.Id("cphContent_rptrSettlementmain_chkOnline_0");
        By CheckBox = By.XPath("//*[starts-with(@id,'cphContent_rptrSettlementmain_chk')]");
        //By CheckBoxCheque = By.Id("cphContent_rptrSettlementmain_chkCheque_0");
        By ReceiptNumber1 = By.Id("cphContent_rptrSettlementmain_lnkReceiptNumber_0");
        By Cancelpayment = By.Id("cphContent_lnkCancelPayment");
        By AllowCancelPayment = By.XPath("(//a[normalize-space()='Yes'])[1]");

        By chequeReceiptnumber = By.Id("cphContent_rptrSettlementmain_spanChequeReceiptOA_0");

        public CollectionSettlementPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToCollectionSettlementPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(CustomerSettlement);
        }


        public void FilterWithUser(String userCode)
        {
            WaitUtil.WaitForElementTOBeClickable(FilterButton);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(FilterButton);
            BrowserActions.Click(SalesOrg);
            BrowserActions.Click(SalesOrgCheckBox);
            SelectUser(userCode);
            //BrowserActions.Click(FilterSubmitButton);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.ScrollToElement(ActionButton);
            BrowserActions.Click(ActionButton);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.ShortSleep();
        }





        public List<IWebElement> ListOfPaymentReceipt()
        {

            List<IWebElement> receiptElements = BrowserActions.FindElements(ListOfReceipts);
            List<string> receiptTextArray = receiptElements.Select(element => element.Text).ToList();
            Console.WriteLine(receiptTextArray);


            return receiptElements;


        }


        public IWebElement GetCheckboxForReceipt(IWebElement receiptElement)
        {
            try
            {

                return receiptElement.FindElement(CheckBox);
            }
            catch (NoSuchElementException)
            {
                // Handle the case where the checkbox was not found
                return null;
            }
        }



        public void Settlement()
        {
            BrowserActions.Click(CheckBox);
            BrowserActions.Click(SettleButton);
            BrowserActions.AlertPopAccept();
            BrowserActions.Click(CancelReceiptPrint);
        }



        public void FilterWithReceipt(string receiptnumber)
        {
            BrowserActions.Click(FilterButton);
            WaitUtil.ShortSleep();
            BrowserActions.Type(ReceiptNumber, receiptnumber);
            BrowserActions.Click(ReceiptSearchButtonCS);

        }


        public void NavigateToChequeCollectionSettelementPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(ChequeCollectionSetelement);
        }
        //public void SelectUserCS(string UserCode)
        //{
        //    WaitUtil.WaitForLoaderToComplete();
        //    BrowserActions.Click(Selectcustomerlink); 
        //    WaitUtil.ShortSleep();
        //    BrowserActions.Type(UserCodepath, UserCode);
        //    WaitUtil.WaitForLoaderToComplete();
        //    BrowserActions.Click(SearchCust);
        //    WaitUtil.WaitForLoaderToComplete();
        //    WaitUtil.Sleep5sec();
        //    BrowserActions.Click(UserCheckBox);
        //    BrowserActions.Click(DoneButton);
        //}
        //public void FilterToSearchUserCS(string fromdate, string UserCode)
        //{
        //    BrowserActions.Click(Filter);
        //    BrowserActions.Click(SalesOrganization);
        //    BrowserActions.Click(SalesOrganizationCode);
        //    SelectUserCS(UserCode);
        //    BrowserActions.SelectDate(CSFromDate, fromdate);
        //}
        //public void SettelememtTheReceipt()
        //{
        //    BrowserActions.SelectReceipts();
        //    BrowserActions.Click(SettleButton);
        //    BrowserActions.AlertPopAccept();
        //    BrowserActions.Click(CancelReceiptPrint);

        //}


        //public void Filter_And_Approve_CSS(string fromdate, string UserCode)
        //{
        //    NavigateToChequeCollectionSettelementPage();
        //    BrowserActions.Click(Filter);
        //    BrowserActions.Click(SalesOrganization);
        //    BrowserActions.Click(SalesOrganizationCodeCCS);
        //    WaitUtil.ShortSleep();
        //    BrowserActions.SelectDate(FromDateCCS, fromdate);
        //    BrowserActions.Click(SearchButtonCCS);
        //    WaitUtil.ShortSleep();

        //    BrowserActions.FindAndSelectCCS(UserCode);
        //    BrowserActions.Click(ApprovedButton);
        //    BrowserActions.Click(PoupOkay);



        // }


        //public void SettlementCheque()
        //{
        //    Thread.Sleep(5000);
        //    BrowserActions.Click(CheckBox);
        //    BrowserActions.Click(SettleButton);
        //    BrowserActions.AlertPopAccept();
        //    BrowserActions.Click(CancelReceiptPrint);
        //}

        //public void Settlement2()
        //{
        //    try
        //    {
        //        BrowserActions.Click(CheckBox);
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        BrowserActions.Click(CheckBox);
        //    }
        //    BrowserActions.Click(SettleButton);
        //    BrowserActions.AlertPopAccept();
        //    BrowserActions.Click(CancelReceiptPrint);
        //}

        public void CancelCashPayment()
        {
            BrowserActions.Click(ReceiptNumber1);
            BrowserActions.Click(Cancelpayment);
            BrowserActions.Click(AllowCancelPayment);

        }

        public void CancelBankPayment()
        {
            BrowserActions.Click(chequeReceiptnumber);
            BrowserActions.Click(Cancelpayment);
            BrowserActions.Click(AllowCancelPayment);

        }


        public void SelectActionButton(string UserCode)
        {
            string xpathExpression = $"//tbody/tr[td/span[contains(@title,'{UserCode}')]]/td/a[@id='cphContent_gvPayment_lnkView_0']";
            IWebElement action = driver.FindElement(By.XPath(xpathExpression));
            action.Click();
        }








    }
}
