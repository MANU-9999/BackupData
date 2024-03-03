package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;

public class CollectionSettlementPage extends Base {
    By TransactionsMenu = By.id("ancSfaTransactions");
    By CustomerSettlement = By.cssSelector("a[href='../pages/CollectionSetelement.aspx']");
    By ActionButton = By.xpath("(//img[@alt='View Details'])[1]");
    //Filter
    By FilterButton = By.xpath("//img[@src='../images/ts.png']");
    By SalesOrg = By.xpath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
    By SalesOrgCheckBox = By.id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
    By FilterSubmitButton = By.xpath("//input[@id='cphContent_btnSeach']");
    By LastetInvoice = By.xpath("//a[@id='cphContent_rptrSettlementmain_spanChequeReceiptOA_17']");
    By ListOfReceipts = By.xpath("//a[@class='Receipt_Number']");
    //By SettlementCheckBox = By.XPath(".//input[@type='checkbox']");
    By SettleButton = By.xpath("//a[@id='cphContent_lnkSettle']");
    By CancelReceiptPrint = By.id("cphContent_lnkClose");

    // By CheckToSettle = By.Id("cphContent_rptrSettlementmain_chkOnline_0");
    By ReceiptNumber = By.id("cphContent_txtReceiptNumber");
    By ReceiptSearchButtonCS = By.xpath("//*[@id='cphContent_btnSeachSubChannel']");
    By ChequeCollectionSetelement = By.cssSelector("#liChequeCollectionSetelement> a");
    // By CheckToSettleCheque = By.Id("cphContent_rptrSettlementmain_chkCheque_0");

    //By CheckBoxOnline = By.Id("cphContent_rptrSettlementmain_chkOnline_0");
    By CheckBox = By.xpath("//*[starts-with(@id,'cphContent_rptrSettlementmain_chk')]");
    //By CheckBoxCheque = By.Id("cphContent_rptrSettlementmain_chkCheque_0");
    By ReceiptNumber1 = By.id("cphContent_rptrSettlementmain_lnkReceiptNumber_0");
    By Cancelpayment = By.id("cphContent_lnkCancelPayment");
    By AllowCancelPayment = By.xpath("(//a[normalize-space()='Yes'])[1]");

    By chequeReceiptnumber = By.id("cphContent_rptrSettlementmain_spanChequeReceiptOA_0");


    public void NavigateToCollectionSettlementPage() {
        BrowserActions.Click(TransactionsMenu);
        BrowserActions.Click(CustomerSettlement);
    }


    public void FilterWithUser(String userCode) {
        WaitUtil.waitForElementToBeClickable(FilterButton);
        BrowserActions.Click(FilterButton);
        WaitUtil.Sleep5();
        BrowserActions.Click(SalesOrg);
        BrowserActions.Click(SalesOrgCheckBox);
        RepitativeMethodsPage.SelectUser(userCode);

        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.ScrollToElement(ActionButton);
        BrowserActions.Click(ActionButton);
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.shortSleep();
    }
    /*
     * public List<WebElement> ListOfPaymentReceipt() {
     *
     * List<WebElement> receiptElements =
     * BrowserActions.FindElements(ListOfReceipts); List<String> receiptTextArray =
     * receiptElements.Select(element => element.Text).ToList();
     * System.out.println(receiptTextArray); return receiptElements;
     *
     * }
     *
     *
     * public WebElement GetCheckboxForReceipt(WebElement receiptElement) { try {
     *
     * return receiptElement.findElements(CheckBox); } catch
     * (NoSuchElementException) { // Handle the case where the checkbox was not
     * found return null; } }
     */


    public void Settlement() {
        BrowserActions.Click(CheckBox);
        BrowserActions.Click(SettleButton);
        BrowserActions.AlertPopAccept();
        BrowserActions.Click(CancelReceiptPrint);
    }


    public void FilterWithReceipt(String receiptnumber) {
        BrowserActions.Click(FilterButton);
        WaitUtil.shortSleep();
        BrowserActions.Type(ReceiptNumber, receiptnumber);
        BrowserActions.Click(ReceiptSearchButtonCS);

    }


    public void NavigateToChequeCollectionSettelementPage() {
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

    public void CancelCashPayment() {
        BrowserActions.Click(ReceiptNumber1);
        BrowserActions.Click(Cancelpayment);
        BrowserActions.Click(AllowCancelPayment);

    }

    public void CancelBankPayment() {
        BrowserActions.Click(chequeReceiptnumber);
        BrowserActions.Click(Cancelpayment);
        BrowserActions.Click(AllowCancelPayment);

    }


}
