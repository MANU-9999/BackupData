using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class CreateDebitNotePage : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By Create_DebitNote = By.LinkText("Create DebitNote");
        By Daily_Cash_Journal = By.LinkText("Daily Cash Journal");
        By Sales_Transaction = By.LinkText("Sales Transaction");

        By ImportButton = By.CssSelector("a#cphContent_lnkImportDebitNote");
        By DropFilePopUp = By.CssSelector("div div div.dz-default.dz-message");
        By Done = By.CssSelector("div input#cphContent_btnUpload");

        By FirstLevelApproveButton = By.CssSelector("a#cphContent_lnkApproveLevel");
        By FirstLevelPopupOkay = By.CssSelector("a#cphContent_lnkmultiple.oknew.marleft10");
        By SecondLevelApproveTab = By.CssSelector("li#cphContent_lnkLevel1Approved a");
        By SecondLevelApproveButton = By.CssSelector("a#cphContent_lnkApproveLevel1");
        By SecondLevelPopupOkay = By.CssSelector("a#cphContent_lnkmultipleLevel1");


        By RejecteButton = By.CssSelector("a#cphContent_lnkRejectLevel");
        By RejectePopupOkay = By.CssSelector("a#cphContent_lnkmultiple");
        By RejectedTab = By.CssSelector("a#cphContent_lnkRejected");


        By CancelButton = By.CssSelector("a#cphContent_LinkButton4");
        By CancelPopupOkay = By.CssSelector("a#cphContent_lnkPnlDelete");
        By ApprovedTab = By.CssSelector("a#cphContent_lnkApproved");
        By CanceledTab = By.CssSelector("a#cphContent_lnkCanceled");

        By FilterButton = By.XPath("//img[@src='../images/ts.png']");
        By SalesOrg = By.XPath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
        By SalesOrgCheckBox = By.Id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
        By FromDate = By.Id("cphContent_txtDate");
        By FilterSubmitButton = By.XPath("//input[@id='cphContent_btnSeach']");

        By SaveButton = By.CssSelector("input#cphContent_btnSave.button1.wid105px.fl");

        // Adding DebitNote by filed.
        By AddNewLink = By.XPath("//a[@id='cphContent_lnkAddNew']");
        By SellectingSKU = By.XPath("//div[@id='cphContent_divskudrop']//button[@type='button']");
        By EnterItems = By.XPath("//input[@placeholder =\"Enter keywords\"]");
        By CheckBox = By.XPath("//label[@class='ui-corner-all ui-state-hover']/input");

        //By SelectSKU = By.XPath("(//span[contains(text(),'Select SKU')])[2]");
        //By EnterItems = By.XPath("(//input[@placeholder =\"Enter keywords\"])[2]");

        By SearchButton = By.XPath("(//input[@id='cphContent_btnSeachSubChannel'])[1]");
        By ReferenceNumber = By.XPath("//input[@id='cphContent_txtCustomerReference']");
        By TaxApplicableCheckBox = By.XPath("//input[@id='cphContent_chkIsTaxApplicable']");
        By CustomerDoc_Date = By.XPath("//input[@id='cphContent_txtDocDate']");
        By PostIng_Date = By.XPath("//input[@id='cphContent_txtPostingDate']");
        By ChooseFile = By.Id("cphContent_FileUpload1");
        By Description_1 = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_0']");

        By Description_2 = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_1']");
        By SaveOption = By.CssSelector("#cphContent_btnSave");

        By Reason = By.XPath("(//button[@type='button'])[2]");
        By ReasonDropDown = By.XPath("(//input[@placeholder='Enter keywords'])[3]");
        By SelectReason = By.XPath("//span[normalize-space()='Sell out']");

        By CreditNoteAmount_row1 = By.Id("cphContent_gvPendingInvoice_txtPaidAmount_0");
        By CreditNoteAmount_row2 = By.Id("cphContent_gvPendingInvoice_txtPaidAmount_1");
        By CreditNoteNumber = By.XPath("(//span[@id='cphContent_lblCreditNoteNumber'])[1]");
        By AddButton = By.CssSelector("input#cphContent_btnAddSKU");
        By CNGRANDTotal = By.Id("cphContent_lblNetAmount1");

        By Approved = By.CssSelector("input#cphContent_btnApprove");

        public CreateDebitNotePage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToCreateDebitNote()
        {
            BrowserActions.Click(TransactionsMenu);
            try
            {
                BrowserActions.Click(Create_DebitNote);
            }
            catch (ElementClickInterceptedException e)
            {
                BrowserActions.Click(Create_DebitNote);

            }
            WaitUtil.WaitForLoaderToComplete();
        }
        public void NavigateToSalesTransaction()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(Sales_Transaction);
            WaitUtil.WaitForLoaderToComplete();

        }

        public void ImportDebitNotefile(string filename)
        {
            BrowserActions.Click(ImportButton);
            BrowserActions.Click(DropFilePopUp);
            WaitUtil.ShortSleep();
            BrowserActions.ImportfileFormat(filename);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(Done);
            WaitUtil.ShortSleep();
        }
        public void Reject(string CustomerCode, string RefNum)
        {
            CreditOrDebitNoteFirstLevelSelect(CustomerCode, RefNum);
            BrowserActions.Click(RejecteButton);
            BrowserActions.Click(RejectePopupOkay);
            BrowserActions.Click(RejectedTab);
        }
        public void Cancel(string CustomerCode, string RefNum)
        {
            BrowserActions.Click(ApprovedTab);
            WaitUtil.ShortSleep();
            CreditOrDebitNoteApprovedLevelSelect(CustomerCode, RefNum);
            BrowserActions.Click(CancelButton);
            BrowserActions.Click(CancelPopupOkay);
            WaitUtil.ShortSleep();
            BrowserActions.Click(CanceledTab);
        }

        public void FirstLevelApprove(string CustomerCode, string RefNum)
        {
            CreditOrDebitNoteFirstLevelSelect(CustomerCode, RefNum);
            BrowserActions.Click(FirstLevelApproveButton);
            BrowserActions.Click(FirstLevelPopupOkay);
        }
        public void SecondLevelApprove(string CustomerCode, string RefNum)
        {
            BrowserActions.Click(SecondLevelApproveTab);
            CreditOrDebitNoteSecondLevelSelect(CustomerCode, RefNum);
            BrowserActions.Click(SecondLevelApproveButton);
            BrowserActions.Click(SecondLevelPopupOkay);
            WaitUtil.Sleep5sec();
        }
        public string GetDebitNoteConfirmationByNumber(string CustomerCode, string RefNum)
        {

            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            WaitUtil.ShortSleep();
            string InvoiceNumber = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvCreditNote_Rejected_lblTrxCode_')]")).GetAttribute("title");
            return InvoiceNumber;
        }
        public string DebitNoteConfirmationCancelTab(string CustomerCode, string RefNum)
        {

            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            WaitUtil.ShortSleep();
            string InvoiceNumber = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvCreditNote_Canceled_lblTrxCode_')]")).GetAttribute("title");
            return InvoiceNumber;
        }
        public void SavePayement()
        {
            BrowserActions.ScrollUp();
            WaitUtil.ShortSleep();
            BrowserActions.JSFindAndClick(SaveButton);
            WaitUtil.Sleep5sec();
        }


        public void CreditOrDebitNoteFirstLevelSelect(string CustomerCode, string RefNum)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            IWebElement CheckBox = row.FindElement(By.XPath(".//span/input[contains(@id,'cphContent_gvCreditNote_Pending_chkDel_')]"));
            CheckBox.Click();
        }
        public void CreditOrDebitNoteSecondLevelSelect(string CustomerCode, string RefNum)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            IWebElement CheckBox = row.FindElement(By.XPath(".//span/input[contains(@id,'cphContent_gvCreditNote_ApprovedLevel1_chkDel_')]"));
            CheckBox.Click();
        }
        public void CreditOrDebitNoteApprovedLevelSelect(string CustomerCode, string RefNum)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            IWebElement CheckBox = row.FindElement(By.XPath(".//span/input[contains(@id,'cphContent_gvCreditNote_ApprovedLevel2_chkDel_')]"));
            CheckBox.Click();
        }
        public string GetDebitNoteInvoiceNumber(string CustomerCode, string RefNum)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            WaitUtil.ShortSleep();
            string InvoiceNumber = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvCreditNote_Pending_lblTrxCode_')]")).GetAttribute("title");
            return InvoiceNumber;

        }
        public bool CreditOrDebitNoteShowingInCreatePaymentPage(string InvoiceNumber)
        {
            try
            {
                BrowserActions.ScrollDown();
                WaitUtil.ShortSleep();
                IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + InvoiceNumber + "' ]]"));
                string val = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvPendingInvoice_lblInvNumber_')]")).GetAttribute("title");
                IWebElement CheckBox = row.FindElement(By.XPath(".//*[contains(@id, 'cphContent_gvPendingInvoice_chkselect_')]"));
                try
                {
                    CheckBox.Click();
                }
                catch (ElementClickInterceptedException ex)
                {
                    BrowserActions.IWebElementJSFindAndClick(CheckBox);
                }
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }

        }



        public void AddNewDebitNote(string customercode, string sell, string RefNum, string customerDocDate, string postingDate, List<string> items)
        {
            BrowserActions.Click(AddNewLink);
            WaitUtil.ShortSleep();
            SelectCustomer(customercode);

            AddItems(items);
            BrowserActions.Click(SearchButton);

            BrowserActions.Click(Reason);
            BrowserActions.Type(ReasonDropDown, sell);
            BrowserActions.Click(SelectReason);
            BrowserActions.Type(ReferenceNumber, RefNum);
            BrowserActions.SelectDate(CustomerDoc_Date, customerDocDate);
            BrowserActions.SelectDate(PostIng_Date, postingDate);
            BrowserActions.Click(TaxApplicableCheckBox);
            BrowserActions.Type(ChooseFile, "C:\\Users\\WINIT\\Pictures\\Screenshots\\Screenshot (1).png");   //Any image path from project because we are using import option               
            WaitUtil.ShortSleep();

        }
        public void FillSKUDetails(double amount, string sellOut, string TurnOverDiscount, string description)
        {
            BrowserActions.ScrollToElement(CreditNoteAmount_row1);
            BrowserActions.TypeFloatValue(CreditNoteAmount_row1, amount);
            BrowserActions.Type(Description_1, description);
            BrowserActions.TypeFloatValue(CreditNoteAmount_row2, amount);
            BrowserActions.Type(Description_2, description);
        }
        public void AddItems(List<string> items)
        {
            BrowserActions.Click(SellectingSKU);
            foreach (string item in items)
            {
                BrowserActions.Click(EnterItems);
                BrowserActions.Clear(EnterItems);
                BrowserActions.Type(EnterItems, item);
                IWebElement CheckBox = driver.FindElement(By.XPath("//div[6]/ul/li/label/input[contains(@value,'" + item + "')]"));
                BrowserActions.IWebElementJSFindAndClick(CheckBox);
            }
        }

        public string SaveandGetInvoiceNumber()
        {
            BrowserActions.Click(SaveOption);
            BrowserActions.ScrollToElement(Reason);
            string CreditNoteInvoice = BrowserActions.GetText(CreditNoteNumber);
            return CreditNoteInvoice;
        }
        public void Approve()
        {
            BrowserActions.ScrollToElement(Approved);
            BrowserActions.Click(Approved);
            WaitUtil.ShortSleep();
        }
        public double GetGrandTotalCN()
        {
            string GrandTotal = BrowserActions.GetText(CNGRANDTotal);
            double parsedGrandTotal = double.Parse(GrandTotal);
            return parsedGrandTotal;
        }
    }
}
