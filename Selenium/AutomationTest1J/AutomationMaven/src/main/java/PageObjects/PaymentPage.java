package PageObjects;

import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import java.util.Arrays;
import java.util.List;


public class PaymentPage {

    By TransactionsMenu = By.id("ancSfaTransactions");
    By CreatePaymentLink = By.linkText("Create Payment");

    By Paymentmode = By.xpath("//*[@id='cphContent_ddlPaymentMode']");
    By Documenttype = By.xpath("//select[@id='cphContent_ddlInvoiceType']");
    By Currency = By.id("cphContent_ddlCurrency");
    By SearchButton = By.id("cphContent_btnSeachSubChannel");
    By AutoallocateCheck = By.xpath("//input[@id='cphContent_chkIsAutoAllocate']");
    By Amount = By.xpath("//input[@id='cphContent_txtCashAmount']");
    By SaveButton = By.cssSelector("#cphContent_btnSave");
    By BalanceAmount = By.cssSelector("#cphContent_gvPendingInvoice_lblBalanceAmount_0");
    //By SelectRecord = By.Id("cphContent_gvPendingInvoice_chkselect_0");
    By SelectSecondRecord = By.id("cphContent_gvPendingInvoice_chkselect_1");
    By PaidAmount = By.id("cphContent_gvPendingInvoice_txtPaidAmount_0");
    By AllocateButton = By.id("cphContent_gvPendingInvoice_txtPaidAmount_0");
    //By LabelDueAmount = By.Id("lblDueAmount");
    //By Amounts = By.XPath("//*[contains(@id,'cphContent_gvPendingInvoice_txtPaidAmount')]");
    By BankName = By.id("cphContent_ddlbank");
    By BranchName = By.id("cphContent_txtBranchName");
    By ChequeNo = By.id("cphContent_txtOnlineReferenceNo");
    //By ChequeAmount = By.Id("");
    By ChequeDate = By.id("cphContent_txtChequeDate");
    By TransferDate = By.id("cphContent_txtChequeDate");
    By ChequeDateDays = By.xpath("//*[@id='cphContent_ChequeDate_daysBody']/tr/td");
    By ChequeDateMonthYear = By.id("cphContent_ChequeDate_title");
    By ChooseFile = By.id("cphContent_FileUpload1");

    By PreviousMonth = By.id("cphContent_txtChequeDate_prevArrow");
    By SelectDay = By.id("cphContent_ChequeDate_day_3_3");
    By InvoiceNum = By.xpath("//tr[2]/td[3]/span");

    //By InvoiceNumField = By.Id("cphContent_gvPendingInvoice_lblInvNumber_0");
    By ISDocumentType = By.id("cphContent_ddlDocumentType");
    By InnerClickdate = By.id("");
    By ISDueStartDate = By.id("cphContent_txtStartDateSearch");
    By ISDueEndDate = By.id("cphContent_txtEndDateSearch");
    By ISInvoiceStartDate = By.id("cphContent_txtInvoiceStartDate");
    By ISInvoiceEndDate = By.id("cphContent_txtInvoiceEndDate");
    By ISInvoice = By.id("cphContent_txtInvoiceNumber");
    By ISCustomerCode = By.id("cphContent_txtCustomersearch");
    By ISDocType = By.id("cphContent_ddlDocumentType");
    By InvoiceSearchbutton = By.id("cphContent_btnsearchinnergrid");
    By SelectCheckBox = By.xpath("//input[@id='cphContent_gvPendingInvoice_chkselect_0']");
    //By EditAmount = By.XPath("//input[@id='cphContent_gvPendingInvoice_txtPaidAmount_0']");
    //By NumOfRecInManagePayments = By.XPath("//i[contains(text(),'You are viewing')]");
    //By ActionIcon = By.XPath("(//img[@title='View Payment Details'])[1]");

    By ImportButton = By.id("lnkImportCreditNote");
    By Done = By.cssSelector("div input#cphContent_btnUpload");
    By Save = By.cssSelector("#cphContent_btnSave.button1.wid105px.fl");
    By DropFilePopUp = By.cssSelector("div div div.dz-default.dz-message");
    By MyDropZone = By.id("mydropzone");
    //By DropFilePopUp = By.XPath("//*[@id='mydropzone']/div");
    By CashAmount = By.cssSelector("input#cphContent_txtCashAmount");
    By CommentMSg = By.xpath("//textarea[@id='cphContent_txtComment']");
    By EditAmount = By.xpath("//input[@id='cphContent_gvPendingInvoice_txtPaidAmount_0']");
    //Current date
    By WINITLOGO = By.xpath("//a[normalize-space()='WINIT']");


    By TotalPaidamount = By.cssSelector("div label#lblPaidAmount");
    By PaymentMode = By.cssSelector("span#cphContent_lblPaymentMode");
    By OnlineAmount = By.id("cphContent_txtOnlineAmount");

    By BAlAmt = By.xpath("//span[@class='NoClass_Frequency BalanceAmount']");
    By DueAmount = By.id("cphContent_gvPendingInvoice_lblBalanceAmount_0");


    public void NavigateToPaymentPage() {
        BrowserActions.Click(TransactionsMenu);
        BrowserActions.Click(CreatePaymentLink);
        WaitUtil.WaitForLoaderToComplete();

    }

    public void SearchCustomer(String customercode, String paymentmode, String documenttype, String currency) {
        // WaitUtil.WaitForLoaderToComplete();
        WaitUtil.Sleep5();
        RepitativeMethodsPage.SelectCustomer(customercode);
        // BrowserActions.Click(Selectcustomerlink);
        // BrowserActions.Type(Customer, customercode);
        // WaitUtil.WaitForLoaderToComplete();
        // BrowserActions.Click(SearchCust);
        // WaitUtil.WaitForLoaderToComplete();
        // BrowserActions.Click(RadioButton);
        // BrowserActions.Click(DoneButton);
        // WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Select(Paymentmode, paymentmode);
        // driver.FindElement(Password).SendKeys(pass);
        BrowserActions.Select(Documenttype, documenttype);
        BrowserActions.Select(Currency, currency);
        // driver.FindElement(LoginButton).Click();
        BrowserActions.Click(SearchButton);
        WaitUtil.WaitForLoaderToComplete();
        // To scroll to element
        // BrowserActions.ScrollToElement(SelectRecord);
        // Actions act = new Actions(driver);
        // act.ScrollToElement(driver.FindElement(SelectRecord)).Build().Perform();
        // float Balamt = BrowserActions.GetAmountExcludingCurrency(BalanceAmount);
        // return Balamt;
    }

    public String AutoAllocate(float amount) {
        // Actions act = new Actions(driver);
        // act.SendKeys(Keys.Home).Build().Perform();
        // BrowserActions.ScrollUp();
        // Thread.Sleep(3000);
        BrowserActions.Click(AutoallocateCheck);
        BrowserActions.TypeFloatValue(Amount, amount);
        BrowserActions.ScrollDown();
        String Invoice = BrowserActions.GetText(InvoiceNum);
        BrowserActions.ScrollUp();
        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return Invoice;

    }

    public String ManualAllocate(float amount) {
        BrowserActions.ScrollToElement(SelectCheckBox);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Clear(PaidAmount);
        BrowserActions.TypeFloatValue(PaidAmount, amount);
        // click out to remove cursor from text box
        BrowserActions.Click(BalanceAmount);
        String Invoice = BrowserActions.GetText(InvoiceNum);
        // scroll up to click on save button
        BrowserActions.ScrollUp();
        // Actions act = new Actions(driver);
        // act.SendKeys(Keys.Home).Build().Perform();
        WaitUtil.shortSleep();
        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return Invoice;
    }

    public String ClickAllocate() {
        BrowserActions.ScrollToElement(SelectCheckBox);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(SelectSecondRecord);
        String Invoice = BrowserActions.GetText(InvoiceNum);
        // scroll up to click on save button
        BrowserActions.ScrollUp();
        // Actions act = new Actions(driver);
        // act.SendKeys(Keys.Home).Build().Perform();
        WaitUtil.shortSleep();
        // IList<IWebElement> Amts = driver.FindElements(Amounts);
        BrowserActions.Click(AllocateButton);
        WaitUtil.WaitForLoaderToComplete();
        // return lblDueAmt;
        return Invoice;

    }

    public String ManualCheque(String bankname, String branchname, String chequeno, float amount,
                               String chequedate) {
        BrowserActions.Select(BankName, bankname);
        BrowserActions.Type(BranchName, branchname);
        BrowserActions.Type(ChequeNo, chequeno);
        // BrowserActions.Type(ChequeAmount,chequeamount);

        BrowserActions.Click(ChequeDate);
        BrowserActions.Click(SelectDay);
        BrowserActions.SelectDate(ChequeDate, chequedate);

        BrowserActions.Type(ChooseFile,
                "C:\\Users\\ramkr\\OneDrive\\Pictures\\245683330_2046375822178755_820701224323634825_n.jpg");
        // BrowserActions.Select(ChequeDate,date);
        BrowserActions.ScrollToElement(SelectCheckBox);
        BrowserActions.Click(SelectCheckBox);

        BrowserActions.Clear(PaidAmount);
        BrowserActions.TypeFloatValue(PaidAmount, amount);
        // click out to remove cursor from text box
        BrowserActions.Click(BalanceAmount);
        // scroll up to click on save button
        BrowserActions.ScrollUp();
        // Actions act = new Actions(driver);
        // act.SendKeys(Keys.Home).Build().Perform();
        WaitUtil.shortSleep();
        // Fileupload

        String Invoice = BrowserActions.GetText(InvoiceNum);

        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return Invoice;

    }

    public String InnerSearchDetails(String invoicenumber, String customercode, String doctype, String duestartdate,
                                     String dueenddate, String invoicestartdate, String invoiceenddate, double amount) {

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
        // BrowserActions.Click(InvoiceSearchbutton);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(PaidAmount);
        BrowserActions.Clear(PaidAmount);
        BrowserActions.TypeFloatValue(PaidAmount, amount);
        // BrowserActions.Click(FinalizePayment);
        // String txt = BrowserActions.GetText(NumOfRecInManagePayments);
        // BrowserActions.Click(ActionIcon);

        String Invoice = BrowserActions.GetText(InvoiceNum);
        BrowserActions.ScrollUp();
        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return Invoice;
    }

    public String OnAccEnterCash(double amount) {
        BrowserActions.Click(Amount);
        BrowserActions.Clear(Amount);
        BrowserActions.TypeFloatValue(Amount, amount);
        BrowserActions.Click(SaveButton);
        String Invoice = BrowserActions.GetText(InvoiceNum);
        return Invoice;
    }

    public String POSPayment(String bankname, String branchname, String refnumber, float amount,
                             String transferdate, String documenttype) {

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

    public String OnlinePaymentAndGetInvoice(String bankname, String branchname, String refnumber, double amount,
                                             String transferdate, String documenttype) {

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

    public float GetAmountText() {
        float Amount = BrowserActions.GetTextByJavaScriptExecutor(CashAmount);
        BrowserActions.Click(Save);
        return Amount;

    }

    public void Importfile(String filename) {
        BrowserActions.Click(ImportButton);
        WaitUtil.shortSleep();
        //BrowserActions.Click(MyDropZone);
        BrowserActions.ImportfileFormat(filename);
        WaitUtil.Sleep5();
        // Thread.Sleep(10000);
        BrowserActions.Click(Done);
        WaitUtil.shortSleep();

    }

    public String OnlinePaymentAndGetInvoiceUsingIS(String bankName, String branchName, String refNum,
                                                    double amount, String transferDate, String comment, String invoicenumber) {

        BrowserActions.Type(BranchName, branchName);
        BrowserActions.Type(ChequeNo, refNum);
        BrowserActions.Click(TransferDate);
        BrowserActions.Click(SelectDay);
        BrowserActions.SelectDate(TransferDate, transferDate);
        BrowserActions.Type(ISInvoice, invoicenumber);
        BrowserActions.Click(InvoiceSearchbutton);
        BrowserActions.Select(BankName, bankName);
        // Thread.Sleep(3000);
        BrowserActions.ScrollToElement(SelectCheckBox);
        String InvoiceNumber = BrowserActions.GetText(InvoiceNum);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(EditAmount);
        BrowserActions.Clear(EditAmount);
        BrowserActions.TypeFloatValue(EditAmount, amount);
        BrowserActions.ScrollToElement(BankName);
        WaitUtil.shortSleep();
        BrowserActions.Click(CommentMSg);
        BrowserActions.Type(CommentMSg, comment);
        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return InvoiceNumber;

    }

    public void EnterChequeDetails(String bankname, String branchname, String chequeno, String transferDate) {
        BrowserActions.Select(BankName, bankname);
        BrowserActions.Type(BranchName, branchname);
        BrowserActions.Type(ChequeNo, chequeno);
        BrowserActions.SelectDate(ChequeDate, transferDate);
        BrowserActions.Type(ChooseFile, "C:\\Users\\winit\\Pictures\\Screenshots\\Screenshot (1).png");
        WaitUtil.shortSleep();
    }

    public void UploadChequeImage() {
        BrowserActions.Type(ChooseFile, "C:\\Users\\winit\\Pictures\\Screenshots\\Screenshot (1).png");
    }

    public List<Object> PaymentModeandAmountInitial() {
        BrowserActions.ScrollToElement(TotalPaidamount);
        BrowserActions.Click(TotalPaidamount);
        String val = BrowserActions.GetText(TotalPaidamount);
        double TotalPaidamountInitial = Double.parseDouble(val);
        String PaymentModeInital = BrowserActions.GetText(PaymentMode);
        BrowserActions.Click(Save);
        //return new Dictionary<String, object> { { "TotalpaidAmount", TotalPaidamountInitial }, { "PaymentModeInitial", PaymentModeInital } };

        return Arrays.asList(PaymentModeInital, TotalPaidamountInitial);
    }

    public String GetTheInvoice(String invoicenumber, double amount, String bankName) {
        BrowserActions.Type(ISInvoice, invoicenumber);
        BrowserActions.Click(InvoiceSearchbutton);
        BrowserActions.ScrollToElement(SelectCheckBox);
        String InvoiceNumber = BrowserActions.GetText(InvoiceNum);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(EditAmount);
        BrowserActions.Clear(EditAmount);
        BrowserActions.TypeFloatValue(EditAmount, amount);
        BrowserActions.ScrollToElement(BankName);
        BrowserActions.Select(BankName, bankName);
        WaitUtil.shortSleep();
        BrowserActions.Type(ChooseFile, "C:\\Users\\winit\\Pictures\\Screenshots\\Screenshot (1).png");
        WaitUtil.shortSleep();

        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();
        return InvoiceNumber;
    }

    public void VerifyingTheInvoicesAndCheckIt(String TargetCreditNoteInvoice, String InvoiceNumber) {
        String CreditNote = TargetCreditNoteInvoice;
        String InvoiceNum = InvoiceNumber;
        WebElement invoiceRow = BrowserActions.FindingRowIWebElement(InvoiceNum);
        WebElement creditnoteRow = BrowserActions.FindingRowIWebElement(CreditNote);

        if (creditnoteRow != null && invoiceRow != null) {
            invoiceRow.findElement(By.xpath(".//input[@type='checkbox']")).click();
            WebElement webelement = invoiceRow.findElement(By.xpath(".//input[@type='text']"));
            webelement.clear();
            webelement.sendKeys("20");
            creditnoteRow.findElement(By.xpath(".//input[@type='checkbox']")).click();

        } else {
            // One or both invoices are not found
            System.out.println("One or both invoices are not found. Verify the error.");
        }

        BrowserActions.ScrollToElement(SaveButton);
    }

    public void BankOnAccount(String bankname, String branchname, String refnumber, double amount,
                              String transferdate) {
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

    public List<Object> GetInvoiceandSelect(String invoicenumber, double amount) {
        BrowserActions.Type(ISInvoice, invoicenumber);
        BrowserActions.Click(InvoiceSearchbutton);
        BrowserActions.ScrollToElement(SelectCheckBox);
        String InvoiceNumber = BrowserActions.GetText(InvoiceNum);
        String DueAmt = BrowserActions.GetText(DueAmount);
        DueAmt = DueAmt.replace(",", "").replace("SAR", "");
        double TotalDueAmount = Double.parseDouble(DueAmt);

        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(EditAmount);
        BrowserActions.Clear(EditAmount);
        BrowserActions.TypeFloatValue(EditAmount, amount);
        BrowserActions.Click(BAlAmt);
        String BalAmt = BrowserActions.GetText(BAlAmt);
        BalAmt = BalAmt.replace(",", "").replace("SAR", "");
        double balanceamount = Double.parseDouble(BalAmt);
        BrowserActions.Click(SaveButton);

        return Arrays.asList(InvoiceNumber, TotalDueAmount, balanceamount);
    }

    public List<Object> OnlinePaymentAndGetInvoiceAmtDetails(String bankName, String branchName, String refNum,
                                                             double amount, String transferDate, String comment, String invoicenumber)//invoice number code commented
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

        // Double d=Double.parseDouble(invoicenumber);
        // String InvoiceNumber = BrowserActions.GetText(d);
        String DueAmt = BrowserActions.GetText(DueAmount);
        DueAmt = DueAmt.replace(",", "").replace("SAR", "");
        double TotalDueAmount = Double.parseDouble(DueAmt);
        BrowserActions.Click(SelectCheckBox);
        BrowserActions.Click(EditAmount);
        BrowserActions.Clear(EditAmount);
        BrowserActions.TypeFloatValue(EditAmount, amount);
        BrowserActions.Click(BAlAmt);
        String BalAmt = BrowserActions.GetText(BAlAmt);
        BalAmt = BalAmt.replace(",", "").replace("SAR", "");
        double balanceamount = Double.parseDouble(BalAmt);
        BrowserActions.ScrollToElement(BankName);
        WaitUtil.shortSleep();
        BrowserActions.Click(CommentMSg);
        BrowserActions.Type(CommentMSg, comment);
        BrowserActions.Click(SaveButton);
        WaitUtil.WaitForLoaderToComplete();

        return Arrays.asList(TotalDueAmount, balanceamount);
    }

    public void ChequeOnAccount(String bankname, String branchname, String refnumber, double amount,
                                String transferdate) {
        BrowserActions.Select(BankName, bankname);
        BrowserActions.Type(BranchName, branchname);
        BrowserActions.Type(ChequeNo, refnumber);
        BrowserActions.Click(OnlineAmount);
        BrowserActions.Clear(OnlineAmount);
        BrowserActions.TypeFloatValue(OnlineAmount, amount);
        BrowserActions.Click(TransferDate);
        BrowserActions.SelectDate(TransferDate, transferdate);
        WaitUtil.shortSleep();
        BrowserActions.Type(ChooseFile, "C:\\Users\\winit\\Pictures\\Screenshots\\Screenshot (1).png");
        WaitUtil.shortSleep();

        BrowserActions.Click(Save);

    }

}
