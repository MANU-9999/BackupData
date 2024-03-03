using ArlaFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArlaFunctionalTests.PageObjects
{
    public class CreateCreditNote : BasePage
    {
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By Create_CreditNote = By.LinkText("Create CreditNote");

        By ImportButton = By.CssSelector("a#cphContent_lnkImportCreditNote");
        By DropFilePopUp = By.CssSelector("div div div.dz-default.dz-message");
        By Done = By.CssSelector("div input#cphContent_btnUpload");

        By FirstLevelApproveButton = By.CssSelector("a#cphContent_lnkLevel1Approve");
        By FirstLevelPopupOkay = By.CssSelector("a#cphContent_lnkmultiple.oknew.marleft10");
        By SecondLevelApproveTab = By.CssSelector("li#cphContent_lnkLevel1Approved a");
        By SecondLevelApproveButton = By.CssSelector("a#cphContent_lnkLevel2Approve");
        By SecondLevelPopupOkay = By.CssSelector("a#cphContent_lnkmultipleLevel1");

        By SaveButton = By.CssSelector("input#cphContent_btnSave.button1.wid105px.fl");

        // Adding creditNote by filed.
        By AddNewLink = By.XPath("//a[@id='cphContent_lnkAddNew']");
        By SellectingSKU = By.XPath("//div[@id='cphContent_divskudrop']//button[@type='button']");
        By EnterItems = By.XPath("//input[@placeholder =\"Enter keywords\"]");
        By CheckAll = By.XPath("(//span[contains(text(),'Check all')])[1]");
        By SearchButton = By.XPath("(//input[@id='cphContent_btnSeachSubChannel'])[1]");
        By ReferenceNumber = By.XPath("//input[@id='cphContent_txtCustomerReference']");
        By TaxApplicableCheckBox = By.XPath("//input[@id='cphContent_chkIsTaxApplicable']");
        By CustomerDoc_Date = By.XPath("//input[@id='cphContent_txtDocDate']");
        By PostIng_Date = By.XPath("//input[@id='cphContent_txtPostingDate']");
        By ChooseFile = By.Id("cphContent_FileUpload1");
        By CreditNoteAmount_row1 = By.Id("cphContent_gvPendingInvoice_txtPaidAmount_0");
        By Reason_1 = By.XPath("//tbody/tr[1]/td[8]");
        By SellOutReason = By.XPath("select[id='cphContent_gvPendingInvoice_ddlReasonInner_0'] option[value='sell out']");
        By Description_1 = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_0']");
        By CreditNoteAmount_row2 = By.Id("cphContent_gvPendingInvoice_txtPaidAmount_1");
        By Reason_2 = By.XPath("//tbody/tr[2]/td[8]");
        By TurnOverDiscountReason_1 = By.XPath("select[id='cphContent_gvPendingInvoice_ddlReasonInner_1'] option[value='Turn Over Discount']");
        By Description_2 = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_1']");
        By SaveOption = By.CssSelector("#cphContent_btnSave");
        By CreateSKUCreditNoteApprove_1 = By.CssSelector("a#cphContent_lnkLevel1Approve");
        By FirstLevelPopupOkayInDetailsPage = By.CssSelector("a#cphContent_lnkmultiple.oknew.marleft10");
        By SecondLevelApproveTabInDetailsPage = By.CssSelector("li#cphContent_lnkLevel1Approved a");
        By CreateSKUCreditNoteApprove_2 = By.CssSelector("a#cphContent_lnkLevel2Approve");
        By CreateSKUCreditNoteApprove_2_PopupOkay = By.CssSelector("a#cphContent_lnkmultipleLevel1");

        //By SaveButton = By.CssSelector("input#cphContent_btnSave.button1.wid105px.fl");
        By Reason = By.XPath("(//button[@type='button'])[2]");
        By ReasonDropDown = By.XPath("(//input[@placeholder='Enter keywords'])[3]");
        By SelectReason = By.XPath("//span[normalize-space()='Sell out']");
        By GrandTotal = By.XPath("//label[@id='cphContent_lblNetAmount1']");
        By CreditNoteNumber = By.XPath("(//span[@id='cphContent_lblCreditNoteNumber'])[1]");
        By WINITLOGO = By.XPath("//a[normalize-space()='WINIT']");
        By ApprovalButton = By.XPath("(//input[@id='cphContent_btnApprove'])[1]");
        By NavigateToCreateCreditNote2ndlevelApproval = By.XPath("//a[@id='cphContent_lnkApprovedlevel2Pending']");
        By CreditNotePageFilter = By.XPath("(//img[@src='../images/ts.png'])[1]");
        By Trx_Code = By.XPath("(//input[@id='cphContent_txtTrxCode'])[1]");
        By ActionIcon = By.XPath("(//img[contains(@title,'Edit')])[1]");
        By FinalApproval = By.XPath("(//a[normalize-space()='Approved'])[1]");
        By CNGRANDTotal = By.Id("cphContent_lblNetAmount1");


        public CreateCreditNote(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToCreateCreditNote()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(Create_CreditNote);
        }
        public void ImportCreditNotefile(string filename)
        {
            BrowserActions.Click(ImportButton);
            BrowserActions.Click(DropFilePopUp);
            WaitUtil.ShortSleep();
            BrowserActions.ImportfileFormat(filename);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(Done);
            WaitUtil.ShortSleep();
        }
        public void FirstLevelApprove(string CustomerNumber, string RefNum)
        {
            CreditOrDebitNoteFirstLevelSelect(CustomerNumber, RefNum);
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
        public void SavePayement()
        {
            BrowserActions.ScrollUp();
            WaitUtil.ShortSleep();
            try
            {
                BrowserActions.Click(SaveButton);

            }
            catch (ElementClickInterceptedException ex)
            {
                BrowserActions.JSFindAndClick(SaveButton);
            }

            WaitUtil.Sleep5sec();
        }
        public void CreditNoteFilter(string TargetCreditNoteInvoice)
        {
            BrowserActions.Click(CreditNotePageFilter);
            BrowserActions.Type(Trx_Code, TargetCreditNoteInvoice);
            BrowserActions.Click(SearchButton);
        }

        public void AddNewCreditNote(string customercode, string Item1, string Item2, string sell, string RefNum, string customerDocDate, string postingDate)
        {
            BrowserActions.Click(AddNewLink);
            SelectCustomer(customercode);
            BrowserActions.Click(SellectingSKU);
            BrowserActions.Type(EnterItems, Item1);
            BrowserActions.Click(CheckAll);
            BrowserActions.Click(EnterItems);
            BrowserActions.Clear(EnterItems);
            BrowserActions.Type(EnterItems, Item2);
            BrowserActions.Click(CheckAll);
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

        public string SKUDetails(double amount, string sellOut, string TurnOverDiscount, string description)
        {
            BrowserActions.TypeFloatValue(CreditNoteAmount_row1, amount);
            //BrowserActions.Click(Reason_1);

            BrowserActions.Type(Description_1, description);
            BrowserActions.TypeFloatValue(CreditNoteAmount_row2, amount);
            //BrowserActions.Click(Reason_2);
            //BrowserActions.Select(TurnOverDiscountReason_1, TurnOverDiscount);
            BrowserActions.Type(Description_2, description);

            Thread.Sleep(5000);
            BrowserActions.ScrollToElement(Reason);
            // string Gtotal =  BrowserActions.GetText(GrandTotal);
            Thread.Sleep(5000);
            BrowserActions.Click(SaveOption);
            //BrowserActions.JSFindAndClick(SaveOption);
            string CreditNoteInvoice = BrowserActions.GetText(CreditNoteNumber);
            return CreditNoteInvoice;
        }

        public double GetGrandTotalCN()
        {
            string GrandTotal = BrowserActions.GetText(CNGRANDTotal);
            double parsedGrandTotal = double.Parse(GrandTotal);
            return parsedGrandTotal;
        }

        public void FirstLevelApprove()
        {
            BrowserActions.ScrollToElement(WINITLOGO);
            BrowserActions.Click(ApprovalButton);
        }
        public string SecondLevelApprove(string TargetCreditNoteInvoice)
        {
            BrowserActions.Click(NavigateToCreateCreditNote2ndlevelApproval);
            CreateCreditNote Creditnote = new CreateCreditNote(driver);
            Creditnote.CreditNoteFilter(TargetCreditNoteInvoice);

            BrowserActions.Click(ActionIcon);
            string ApprovedCreditNoteInvoice = BrowserActions.GetText(CreditNoteNumber);
            BrowserActions.Click(ApprovalButton);
            BrowserActions.AlertPopAccept();
            return ApprovedCreditNoteInvoice;
        }


        public string FinalApprovedTab(string TargetCreditNoteInvoice)
        {
            BrowserActions.Click(FinalApproval);
            CreateCreditNote Creditnote = new CreateCreditNote(driver);
            Creditnote.CreditNoteFilter(TargetCreditNoteInvoice);
            BrowserActions.Click(ActionIcon);
            BrowserActions.Click(ActionIcon);
            string ApprovedCreditNoteInvoice = BrowserActions.GetText(CreditNoteNumber);
            return ApprovedCreditNoteInvoice;

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
       public string GetCreditNoteInvoiceNumber(string CustomerCode, string RefNum)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
            WaitUtil.ShortSleep();
            string InvoiceNumber = row.FindElement(By.XPath(".//td/span[contains(@id,'cphContent_gvCreditNote_Pending_lblTrxCode_')]")).GetAttribute("title");
            return InvoiceNumber;

        }
    }
}


