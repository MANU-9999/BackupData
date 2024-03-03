using ArlaFunctionalTests.TestSetup;
using ArlaFunctionalTests.TestUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArlaFunctionalTests.PageObjects
{

    public class PaymentPage : BasePage
    {


        By TransactionsMenu = By.Id("ancSfaTransactions");
        By CreatePaymentLink = By.LinkText("Create Payment");

        By Paymentmode = By.XPath("//*[@id='cphContent_ddlPaymentMode']");
        By Documenttype = By.XPath("//select[@id='cphContent_ddlInvoiceType']");
        By Currency = By.Id("cphContent_ddlCurrency");
        By SearchButton = By.Id("cphContent_btnSeachSubChannel");
        By AutoallocateCheck = By.XPath("//input[@id='cphContent_chkIsAutoAllocate']");
        By Amount = By.XPath("//input[@id='cphContent_txtCashAmount']");
        By SaveButton = By.CssSelector("#cphContent_btnSave");
        By BalanceAmount = By.CssSelector("#cphContent_gvPendingInvoice_lblBalanceAmount_0");
        //By SelectRecord = By.Id("cphContent_gvPendingInvoice_chkselect_0");
        By SelectSecondRecord = By.Id("cphContent_gvPendingInvoice_chkselect_1");
        By PaidAmount = By.Id("cphContent_gvPendingInvoice_txtPaidAmount_0");
        By AllocateButton = By.Id("cphContent_btnSaveAllocate");
        //By LabelDueAmount = By.Id("lblDueAmount");
        //By Amounts = By.XPath("//*[contains(@id,'cphContent_gvPendingInvoice_txtPaidAmount')]");
        By BankName = By.Id("cphContent_ddlbank");
        By BranchName = By.Id("cphContent_txtBranchName");
        By ChequeNo = By.Id("cphContent_txtOnlineReferenceNo");
        //By ChequeAmount = By.Id("");
        By ChequeDate = By.Id("cphContent_txtChequeDate");
        By TransferDate = By.Id("cphContent_txtChequeDate");
        By ChequeDateDays = By.XPath("//*[@id='cphContent_ChequeDate_daysBody']/tr/td");
        By ChequeDateMonthYear = By.Id("cphContent_ChequeDate_title");
        By ChooseFile = By.Id("cphContent_FileUpload1");

        By PreviousMonth = By.Id("cphContent_txtChequeDate_prevArrow");
        By SelectDay = By.Id("cphContent_ChequeDate_day_3_3");
        By InvoiceNum = By.XPath("//tr[2]/td[3]/span");

        //By InvoiceNumField = By.Id("cphContent_gvPendingInvoice_lblInvNumber_0");
        By ISDocumentType = By.Id("cphContent_ddlDocumentType");
        By InnerClickdate = By.Id("");
        By ISDueStartDate = By.Id("cphContent_txtStartDateSearch");
        By ISDueEndDate = By.Id("cphContent_txtEndDateSearch");
        By ISInvoiceStartDate = By.Id("cphContent_txtInvoiceStartDate");
        By ISInvoiceEndDate = By.Id("cphContent_txtInvoiceEndDate");
        By ISInvoice = By.Id("cphContent_txtInvoiceNumber");
        By ISCustomerCode = By.Id("cphContent_txtCustomersearch");
        By ISDocType = By.Id("cphContent_ddlDocumentType");
        By InvoiceSearchbutton = By.Id("cphContent_btnsearchinnergrid");
        By SelectCheckBox = By.XPath("//input[@id='cphContent_gvPendingInvoice_chkselect_0']");
        //By EditAmount = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtPaidAmount_0']");        
        //By NumOfRecInManagePayments = By.XPath("//i[contains(text(),'You are viewing')]");
        //By ActionIcon = By.XPath("(//img[@title='View Payment Details'])[1]");

        By ImportButton = By.Id("lnkImportCreditNote");
        By Done = By.CssSelector("div input#cphContent_btnUpload");
        By Save = By.CssSelector("#cphContent_btnSave.button1.wid105px.fl");
        By DropFilePopUp = By.CssSelector("div div div.dz-default.dz-message");
        By MyDropZone = By.Id("mydropzone");
        //By DropFilePopUp = By.XPath("//*[@id='mydropzone']/div");
        By CashAmount = By.CssSelector("input#cphContent_txtCashAmount");
        By CommentMSg = By.XPath("//textarea[@id='cphContent_txtComment']");
        By EditAmount = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtPaidAmount_0']");
        //Current date
        By WINITLOGO = By.XPath("//a[normalize-space()='WINIT']");


        By TotalPaidamount = By.CssSelector("div label#lblPaidAmount");
        By PaymentMode = By.CssSelector("span#cphContent_lblPaymentMode");
        By OnlineAmount = By.Id("cphContent_txtOnlineAmount");

        By BAlAmt = By.XPath("//span[@class='NoClass_Frequency BalanceAmount']");
        By DueAmount = By.Id("cphContent_gvPendingInvoice_lblBalanceAmount_0");
       

        public PaymentPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToPaymentPage()
        {           
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(CreatePaymentLink);
            WaitUtil.WaitForLoaderToComplete();
            
            
        }
        public void SearchCustomer(string customercode, string paymentmode, string documenttype, string currency)
        {
           // WaitUtil.WaitForLoaderToComplete();
            WaitUtil.Sleep5sec();
            SelectCustomer(customercode);
            // BrowserActions.Click(Selectcustomerlink);
            // BrowserActions.Type(Customer, customercode);
            // WaitUtil.WaitForLoaderToComplete();
            // BrowserActions.Click(SearchCust);
            // WaitUtil.WaitForLoaderToComplete();
            // BrowserActions.Click(RadioButton);
            // BrowserActions.Click(DoneButton);
            //WaitUtil.WaitForLoaderToComplete();            
            BrowserActions.Select(Paymentmode, paymentmode);
            // driver.FindElement(Password).SendKeys(pass);
            BrowserActions.Select(Documenttype, documenttype);
            BrowserActions.Select(Currency, currency);
            //driver.FindElement(LoginButton).Click();
            BrowserActions.Click(SearchButton);
            WaitUtil.WaitForLoaderToComplete();
            //To scroll to element
            //BrowserActions.ScrollToElement(SelectRecord);
            // Actions act = new Actions(driver);
            // act.ScrollToElement(driver.FindElement(SelectRecord)).Build().Perform();
            //float Balamt = BrowserActions.GetAmountExcludingCurrency(BalanceAmount);
            //return Balamt;
        }

        public string AutoAllocate(float amount)
        {
            //Actions act = new Actions(driver);
            //act.SendKeys(Keys.Home).Build().Perform();
            //BrowserActions.ScrollUp();
            //Thread.Sleep(3000);
            BrowserActions.Click(AutoallocateCheck);
            BrowserActions.TypeFloatValue(Amount, amount);
            BrowserActions.ScrollDown();
            String Invoice = BrowserActions.GetText(InvoiceNum);
            BrowserActions.ScrollUp();
            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return Invoice;
            
        }



        public string ManualAllocate(float amount)
        {
            BrowserActions.ScrollToElement(SelectCheckBox);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Clear(PaidAmount);
            BrowserActions.TypeFloatValue(PaidAmount, amount);
            //click out to remove cursor from text box
            BrowserActions.Click(BalanceAmount);
            string Invoice = BrowserActions.GetText(InvoiceNum);
            //scroll up to click on save button
            BrowserActions.ScrollUp();
            // Actions act = new Actions(driver);
            // act.SendKeys(Keys.Home).Build().Perform();
            Thread.Sleep(2000);
            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return Invoice;
        }

        public string ClickAllocate()
        {
            BrowserActions.ScrollToElement(SelectCheckBox);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(SelectSecondRecord);
            string Invoice = BrowserActions.GetText(InvoiceNum);
            //scroll up to click on save button
            BrowserActions.ScrollUp();
            // Actions act = new Actions(driver);
            // act.SendKeys(Keys.Home).Build().Perform();
            Thread.Sleep(2000);
            //IList<IWebElement> Amts = driver.FindElements(Amounts);
            BrowserActions.Click(AllocateButton);
            WaitUtil.WaitForLoaderToComplete();
            // return lblDueAmt;
            return Invoice;


        }

        public String ManualCheque(string bankname, string branchname, string chequeno, float amount, string chequedate)
        {
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, chequeno);
            //BrowserActions.Type(ChequeAmount,chequeamount);

            BrowserActions.Click(ChequeDate);
            BrowserActions.Click(SelectDay);
            BrowserActions.SelectDate(ChequeDate, chequedate);

            BrowserActions.Type(ChooseFile, "C:\\Users\\ramkr\\OneDrive\\Pictures\\245683330_2046375822178755_820701224323634825_n.jpg");
            //BrowserActions.Select(ChequeDate,date);
            BrowserActions.ScrollToElement(SelectCheckBox);
            BrowserActions.Click(SelectCheckBox);

            BrowserActions.Clear(PaidAmount);
            BrowserActions.TypeFloatValue(PaidAmount, amount);
            //click out to remove cursor from text box
            BrowserActions.Click(BalanceAmount);
            //scroll up to click on save button
            BrowserActions.ScrollUp();
            // Actions act = new Actions(driver);
            // act.SendKeys(Keys.Home).Build().Perform();
            WaitUtil.ShortSleep();
            //Fileupload

            String Invoice = BrowserActions.GetText(InvoiceNum);

            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return Invoice;

        }

        public String InnerSearchDetails(string invoicenumber, String customercode, String doctype, String duestartdate, String dueenddate, String invoicestartdate, String invoiceenddate, double amount)
        {

            BrowserActions.Type(ISInvoice, invoicenumber);
            BrowserActions.Type(ISCustomerCode, customercode);
            // BrowserActions.Select(Documenttype, documenttype);
            BrowserActions.Select(ISDocumentType, doctype);
            BrowserActions.Click(ISDueStartDate);
            BrowserActions.SelectDate(ISDueStartDate, duestartdate);
            BrowserActions.Click(ISDueEndDate);
            BrowserActions.SelectDate(ISDueEndDate, dueenddate);
            BrowserActions.Click(ISInvoiceStartDate);
            BrowserActions.SelectDate(ISInvoiceStartDate, invoicestartdate);
            BrowserActions.Click(ISInvoiceEndDate);
            BrowserActions.SelectDate(ISInvoiceEndDate, invoiceenddate);
            BrowserActions.Click(InvoiceSearchbutton);
            WaitUtil.WaitForLoaderToComplete();
            //  BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(PaidAmount);
            BrowserActions.Clear(PaidAmount);
            BrowserActions.TypeFloatValue(PaidAmount, amount);
            // BrowserActions.Click(FinalizePayment);
            // string txt = BrowserActions.GetText(NumOfRecInManagePayments);
            // BrowserActions.Click(ActionIcon);

            String Invoice = BrowserActions.GetText(InvoiceNum);
            BrowserActions.ScrollUp();
            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return Invoice;
        }



        public string OnAccEnterCash(double amount)
        {
            BrowserActions.Click(Amount);
            BrowserActions.Clear(Amount);
            BrowserActions.TypeFloatValue(Amount, amount);            
            BrowserActions.Click(SaveButton);
            string Invoice = BrowserActions.GetText(InvoiceNum);
            return Invoice;
        }

        public string POSPayment(string bankname, string branchname, string refnumber, float amount, string transferdate, string documenttype)
        {

            BrowserActions.Click(TransferDate);
            BrowserActions.SelectDate(TransferDate, transferdate);
            BrowserActions.ScrollToElement(ISDocumentType);
            BrowserActions.Select(ISDocumentType, documenttype);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(PaidAmount);
            BrowserActions.Clear(PaidAmount);
            BrowserActions.TypeFloatValue(PaidAmount, amount);
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, refnumber);
            String Invoice = BrowserActions.GetText(InvoiceNum);
            BrowserActions.Click(SaveButton);

            return Invoice;

        }

        public String OnlinePaymentAndGetInvoice(string bankname, string branchname, string refnumber, double amount, string transferdate, string documenttype)
        {

            BrowserActions.Click(TransferDate);
            BrowserActions.SelectDate(TransferDate, transferdate);
            BrowserActions.ScrollToElement(ISDocumentType);
            BrowserActions.Select(ISDocumentType, documenttype);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(PaidAmount);
            BrowserActions.Clear(PaidAmount);
            BrowserActions.TypeFloatValue(PaidAmount, amount);
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, refnumber);
            String Invoice = BrowserActions.GetText(InvoiceNum);
            BrowserActions.Click(SaveButton);
            return Invoice;
        }

        public float GetAmountText()
        {
            float Amount = BrowserActions.GetTextByJavaScriptExecutor(CashAmount);
            BrowserActions.Click(Save);
            return Amount;


        }
        public void Importfile(string filename)
        {
            BrowserActions.Click(ImportButton);
            WaitUtil.ShortSleep();
            BrowserActions.Click(MyDropZone);
            BrowserActions.ImportfileFormat(filename);
            WaitUtil.Sleep5sec();
            //Thread.Sleep(10000);
            BrowserActions.Click(Done);
            WaitUtil.ShortSleep();

        }


        public String OnlinePaymentAndGetInvoiceUsingIS(string bankName, string branchName, string refNum, double amount, string transferDate, string comment, string invoicenumber)
        {
      
            BrowserActions.Type(BranchName, branchName);         
            BrowserActions.Type(ChequeNo, refNum);
            BrowserActions.Click(TransferDate);
            BrowserActions.Click(SelectDay);            
            BrowserActions.SelectDate(TransferDate, transferDate);
            BrowserActions.Type(ISInvoice, invoicenumber);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.Select(BankName, bankName);            
            //Thread.Sleep(3000);
            BrowserActions.ScrollToElement(SelectCheckBox);
            string InvoiceNumber = BrowserActions.GetText(InvoiceNum);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(EditAmount);
            BrowserActions.Clear(EditAmount);
            BrowserActions.TypeFloatValue(EditAmount, amount);
            BrowserActions.ScrollToElement(BankName);
            WaitUtil.ShortSleep();
            BrowserActions.Click(CommentMSg);
            BrowserActions.Type(CommentMSg, comment);
            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return InvoiceNumber;

        }

        public void EnterChequeDetails(string bankname, string branchname, string chequeno, string transferDate)
        {
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, chequeno);
            BrowserActions.SelectDate(ChequeDate, transferDate);
            BrowserActions.Type(ChooseFile, "C:\\Users\\ramkr\\OneDrive\\Pictures\\cakeunicorn.jpg");   //Any image path from project because we are using import option               
            WaitUtil.ShortSleep();
        }
        public void UploadChequeImage()
        {
            BrowserActions.Type(ChooseFile, "C:\\Users\\ramkr\\OneDrive\\Pictures\\cakeunicorn.jpg");   //Any image path from project because we are using import option               
        }

        public (string, double) PaymentModeandAmountInitial()
        {
            BrowserActions.ScrollToElement(TotalPaidamount);
            BrowserActions.Click(TotalPaidamount);
            string val = BrowserActions.GetText(TotalPaidamount);
            double TotalPaidamountInitial = double.Parse(val);
            string PaymentModeInital = BrowserActions.GetText(PaymentMode);
            BrowserActions.Click(Save);
            //return new Dictionary<string, object> { { "TotalpaidAmount", TotalPaidamountInitial }, { "PaymentModeInitial", PaymentModeInital } };
            return (PaymentModeInital, TotalPaidamountInitial);

        }

        public string GetTheInvoice(string invoicenumber, double amount, string bankName)
        {
            BrowserActions.Type(ISInvoice, invoicenumber);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.ScrollToElement(SelectCheckBox);
            string InvoiceNumber = BrowserActions.GetText(InvoiceNum);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(EditAmount);
            BrowserActions.Clear(EditAmount);
            BrowserActions.TypeFloatValue(EditAmount, amount);
            BrowserActions.ScrollToElement(BankName);
            BrowserActions.Select(BankName, bankName);
            WaitUtil.ShortSleep();
            BrowserActions.Type(ChooseFile, @"C:\Users\ramkr\OneDrive\Pictures\245683330_2046375822178755_820701224323634825_n.jpg");
            WaitUtil.ShortSleep();

            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return InvoiceNumber;

        }


        public void VerifyingTheInvoicesAndCheckIt(string TargetCreditNoteInvoice, string InvoiceNumber)
        {
            string CreditNote = TargetCreditNoteInvoice;
            string InvoiceNum = InvoiceNumber;
            IWebElement invoiceRow = BrowserActions.FindingRowIWebElement(InvoiceNum);
            IWebElement creditnoteRow = BrowserActions.FindingRowIWebElement(CreditNote);

            if (creditnoteRow != null && invoiceRow != null)
            {
                invoiceRow.FindElement(By.XPath(".//input[@type='checkbox']")).Click();
                IWebElement webelement = invoiceRow.FindElement(By.XPath(".//input[@type='text']"));
                webelement.Clear();
                webelement.SendKeys("20");
                creditnoteRow.FindElement(By.XPath(".//input[@type='checkbox']")).Click();

            }
            else
            {
                // One or both invoices are not found
                Console.WriteLine("One or both invoices are not found. Verify the error.");
            }

            BrowserActions.ScrollToElement(SaveButton);
        }
        public void BankOnAccount(string bankname, string branchname, string refnumber, double amount, string transferdate)
        {
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, refnumber);
            BrowserActions.Click(OnlineAmount);
            BrowserActions.Clear(OnlineAmount);
            BrowserActions.TypeFloatValue(OnlineAmount, amount);
            BrowserActions.Click(TransferDate);
            BrowserActions.SelectDate(TransferDate, transferdate);
            BrowserActions.Click(Save);

        }

        public (string, double, double) GetInvoiceandSelect(string invoicenumber, double amount)
        {
            BrowserActions.Type(ISInvoice, invoicenumber);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.ScrollToElement(SelectCheckBox);
            string InvoiceNumber = BrowserActions.GetText(InvoiceNum);
            string DueAmt = BrowserActions.GetText(DueAmount);
            DueAmt = DueAmt.Replace(",", "").Replace("SAR", "");
            double TotalDueAmount = double.Parse(DueAmt);

            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(EditAmount);
            BrowserActions.Clear(EditAmount);
            BrowserActions.TypeFloatValue(EditAmount, amount);
            BrowserActions.Click(BAlAmt);
            string BalAmt = BrowserActions.GetText(BAlAmt);
            BalAmt = BalAmt.Replace(",", "").Replace("SAR", "");
            double balanceamount = double.Parse(BalAmt);
            BrowserActions.Click(SaveButton);
            return (InvoiceNumber, TotalDueAmount, balanceamount);
        }

        public (string, double, double) OnlinePaymentAndGetInvoiceAmtDetails(string bankName, string branchName, string refNum,
        double amount, string transferDate, string comment, string invoicenumber)
        {

            BrowserActions.Type(BranchName, branchName);
            BrowserActions.Type(ChequeNo, refNum);
            BrowserActions.Click(TransferDate);
            BrowserActions.Click(SelectDay);
            BrowserActions.SelectDate(TransferDate, transferDate);
            BrowserActions.Type(ISInvoice, invoicenumber);
            BrowserActions.Click(InvoiceSearchbutton);
            BrowserActions.Select(BankName, bankName);
            //Thread.Sleep(3000);
            BrowserActions.ScrollToElement(SelectCheckBox);

            string InvoiceNumber = BrowserActions.GetText(InvoiceNum);
            string DueAmt = BrowserActions.GetText(DueAmount);
            DueAmt = DueAmt.Replace(",", "").Replace("SAR", "");
            double TotalDueAmount = double.Parse(DueAmt);
            BrowserActions.Click(SelectCheckBox);
            BrowserActions.Click(EditAmount);
            BrowserActions.Clear(EditAmount);
            BrowserActions.TypeFloatValue(EditAmount, amount);
            BrowserActions.Click(BAlAmt);
            string BalAmt = BrowserActions.GetText(BAlAmt);
            BalAmt = BalAmt.Replace(",", "").Replace("SAR", "");
            double balanceamount = double.Parse(BalAmt);
            BrowserActions.ScrollToElement(BankName);
            WaitUtil.ShortSleep();
            BrowserActions.Click(CommentMSg);
            BrowserActions.Type(CommentMSg, comment);
            BrowserActions.Click(SaveButton);
            WaitUtil.WaitForLoaderToComplete();
            return (InvoiceNumber, TotalDueAmount, balanceamount);

        }

        public void ChequeOnAccount(string bankname, string branchname, string refnumber, double amount, string transferdate)
        {
            BrowserActions.Select(BankName, bankname);
            BrowserActions.Type(BranchName, branchname);
            BrowserActions.Type(ChequeNo, refnumber);
            BrowserActions.Click(OnlineAmount);
            BrowserActions.Clear(OnlineAmount);
            BrowserActions.TypeFloatValue(OnlineAmount, amount);
            BrowserActions.Click(TransferDate);
            BrowserActions.SelectDate(TransferDate, transferdate);
            WaitUtil.ShortSleep();
            BrowserActions.Type(ChooseFile, "C:\\Users\\raghu\\OneDrive\\Desktop\\Automation codes\\Test data\\ice.jpg");
            WaitUtil.ShortSleep();

            BrowserActions.Click(Save);

        }


        public  IWebElement ModifyAmount(string InvoiceNumber, string ModifyAmount)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + InvoiceNumber + "' ]]"));
            IWebElement amount = row.FindElement(By.XPath("//*[contains(@id, 'cphContent_gvPendingInvoice_txtPaidAmount')]"));
            BrowserActions.IWebElementJSFindAndClick(amount);
            amount.Clear();
            amount.SendKeys(ModifyAmount);
            return amount;
        }








    }
}
