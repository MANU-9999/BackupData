package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.ElementClickInterceptedException;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

import java.util.List;

public class CreateDebitNotePage extends Base {
    By TransactionsMenu = By.cssSelector("li a#ancSfaTransactions span");
    By Create_DebitNote = By.linkText("Create DebitNote");
    By Daily_Cash_Journal = By.linkText("Daily Cash Journal");
    By Sales_Transaction = By.linkText("Sales Transaction");

    By ImportButton = By.cssSelector("a#cphContent_lnkImportDebitNote");
    By DropFilePopUp = By.cssSelector("div div div.dz-default.dz-message");
    By Done = By.cssSelector("div input#cphContent_btnUpload");

    By FirstLevelApproveButton = By.cssSelector("a#cphContent_lnkApproveLevel");
    By FirstLevelPopupOkay = By.cssSelector("a#cphContent_lnkmultiple.oknew.marleft10");
    By SecondLevelApproveTab = By.cssSelector("li#cphContent_lnkLevel1Approved a");
    By SecondLevelApproveButton = By.cssSelector("a#cphContent_lnkApproveLevel1");
    By SecondLevelPopupOkay = By.cssSelector("a#cphContent_lnkmultipleLevel1");

    By RejecteButton = By.cssSelector("a#cphContent_lnkRejectLevel");
    By RejectePopupOkay = By.cssSelector("a#cphContent_lnkmultiple");
    By RejectedTab = By.cssSelector("a#cphContent_lnkRejected");

    By CancelButton = By.cssSelector("a#cphContent_LinkButton4");
    By CancelPopupOkay = By.cssSelector("a#cphContent_lnkPnlDelete");
    By ApprovedTab = By.cssSelector("a#cphContent_lnkApproved");
    By CanceledTab = By.cssSelector("a#cphContent_lnkCanceled");

    By FilterButton = By.xpath("//img[@src='../images/ts.png']");
    By SalesOrg = By.xpath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
    By SalesOrgCheckBox = By.id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");
    By FromDate = By.id("cphContent_txtDate");
    By FilterSubmitButton = By.xpath("//input[@id='cphContent_btnSeach']");

    By SaveButton = By.cssSelector("input#cphContent_btnSave.button1.wid105px.fl");

    // Adding DebitNote by filed.
    By AddNewLink = By.xpath("//a[@id='cphContent_lnkAddNew']");
    By SellectingSKU = By.xpath("//div[@id='cphContent_divskudrop']//button[@type='button']");
    By EnterItems = By.xpath("//input[@placeholder =\"Enter keywords\"]");
    By CheckBox = By.xpath("//label[@class='ui-corner-all ui-state-hover']/input");

    // By SelectSKU = By.XPath("(//span[contains(text(),'Select SKU')])[2]");
    // By EnterItems = By.XPath("(//input[@placeholder =\"Enter keywords\"])[2]");

    By SearchButton = By.xpath("(//input[@id='cphContent_btnSeachSubChannel'])[1]");
    By ReferenceNumber = By.xpath("//input[@id='cphContent_txtCustomerReference']");
    By TaxApplicableCheckBox = By.xpath("//input[@id='cphContent_chkIsTaxApplicable']");
    By CustomerDoc_Date = By.xpath("//input[@id='cphContent_txtDocDate']");
    By PostIng_Date = By.xpath("//input[@id='cphContent_txtPostingDate']");
    By ChooseFile = By.id("cphContent_FileUpload1");
    By Description_1 = By.xpath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_0']");

    By Description_2 = By.xpath("//input[@id='cphContent_gvPendingInvoice_txtDesciption_1']");
    By SaveOption = By.cssSelector("#cphContent_btnSave");

    By Reason = By.xpath("(//button[@type='button'])[2]");
    By ReasonDropDown = By.xpath("(//input[@placeholder='Enter keywords'])[3]");
    By SelectReason = By.xpath("//span[normalize-space()='Sell out']");

    By CreditNoteAmount_row1 = By.id("cphContent_gvPendingInvoice_txtPaidAmount_0");
    By CreditNoteAmount_row2 = By.id("cphContent_gvPendingInvoice_txtPaidAmount_1");
    By CreditNoteNumber = By.xpath("(//span[@id='cphContent_lblCreditNoteNumber'])[1]");
    By AddButton = By.cssSelector("input#cphContent_btnAddSKU");
    By CNGRANDTotal = By.id("cphContent_lblNetAmount1");

    By Approved = By.cssSelector("input#cphContent_btnApprove");

    public void NavigateToCreateDebitNote() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.WaitAndclick(TransactionsMenu);
        try {
            BrowserActions.WaitAndclick(Create_DebitNote);
        } catch (Exception e) {
            BrowserActions.WaitAndclick(Create_DebitNote);
        }
        WaitUtil.WaitForLoaderToComplete();
    }

    public void NavigateToSalesTransaction() {
        BrowserActions.WaitAndclick(TransactionsMenu);
        BrowserActions.WaitAndclick(Sales_Transaction);
        WaitUtil.WaitForLoaderToComplete();
    }

    public void ImportDebitNotefile(String filename) {
        BrowserActions.WaitAndclick(ImportButton);
        BrowserActions.WaitAndclick(DropFilePopUp);
        WaitUtil.shortSleep();
        BrowserActions.ImportfileFormat(filename);
        WaitUtil.Sleep5();
        BrowserActions.WaitAndclick(Done);
        WaitUtil.shortSleep();
    }

    public void Reject(String CustomerCode, String RefNum) {
        CreditOrDebitNoteFirstLevelSelect(CustomerCode, RefNum);
        BrowserActions.WaitAndclick(RejecteButton);
        BrowserActions.WaitAndclick(RejectePopupOkay);
        BrowserActions.WaitAndclick(RejectedTab);
    }

    public void Cancel(String CustomerCode, String RefNum) {
        BrowserActions.WaitAndclick(ApprovedTab);
        WaitUtil.shortSleep();
        CreditOrDebitNoteApprovedLevelSelect(CustomerCode, RefNum);
        BrowserActions.WaitAndclick(CancelButton);
        BrowserActions.WaitAndclick(CancelPopupOkay);
        WaitUtil.shortSleep();
        BrowserActions.WaitAndclick(CanceledTab);
    }

    public void FirstLevelApprove(String CustomerCode, String RefNum) {
        CreditOrDebitNoteFirstLevelSelect(CustomerCode, RefNum);
        BrowserActions.WaitAndclick(FirstLevelApproveButton);
        BrowserActions.WaitAndclick(FirstLevelPopupOkay);
    }

    public void SecondLevelApprove(String CustomerCode, String RefNum) {
        BrowserActions.WaitAndclick(SecondLevelApproveTab);
        CreditOrDebitNoteSecondLevelSelect(CustomerCode, RefNum);
        BrowserActions.WaitAndclick(SecondLevelApproveButton);
        BrowserActions.WaitAndclick(SecondLevelPopupOkay);
        WaitUtil.Sleep5();
    }

    public String GetDebitNoteConfirmationByNumber(String CustomerCode, String RefNum) {

        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WaitUtil.shortSleep();
        String InvoiceNumber = row
                .findElement(By.xpath(".//td/span[contains(@id,'cphContent_gvCreditNote_Rejected_lblTrxCode_')]"))
                .getAttribute("title");
        return InvoiceNumber;
    }

    public String DebitNoteConfirmationCancelTab(String CustomerCode, String RefNum) {

        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WaitUtil.shortSleep();
        String InvoiceNumber = row
                .findElement(By.xpath(".//td/span[contains(@id,'cphContent_gvCreditNote_Canceled_lblTrxCode_')]"))
                .getAttribute("title");
        return InvoiceNumber;
    }

    public void SavePayement() {
        BrowserActions.ScrollUp();
        WaitUtil.shortSleep();
        BrowserActions.JSFindAndClick(SaveButton);
        WaitUtil.Sleep5();
    }

    public void CreditOrDebitNoteFirstLevelSelect(String CustomerCode, String RefNum) {
        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WebElement CheckBox = row
                .findElement(By.xpath(".//span/input[contains(@id,'cphContent_gvCreditNote_Pending_chkDel_')]"));
        CheckBox.click();
    }

    public void CreditOrDebitNoteSecondLevelSelect(String CustomerCode, String RefNum) {
        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WebElement CheckBox = row
                .findElement(By.xpath(".//span/input[contains(@id,'cphContent_gvCreditNote_ApprovedLevel1_chkDel_')]"));
        CheckBox.click();
    }

    public void CreditOrDebitNoteApprovedLevelSelect(String CustomerCode, String RefNum) {
        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WebElement CheckBox = row
                .findElement(By.xpath(".//span/input[contains(@id,'cphContent_gvCreditNote_ApprovedLevel2_chkDel_')]"));
        CheckBox.click();
    }

    public String GetDebitNoteInvoiceNumber(String CustomerCode, String RefNum) {
        WebElement row = driver.findElement(
                By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "' ] and td/span[@title='" + RefNum + "']]"));
        WaitUtil.shortSleep();
        String InvoiceNumber = row
                .findElement(By.xpath(".//td/span[contains(@id,'cphContent_gvCreditNote_Pending_lblTrxCode_')]"))
                .getAttribute("title");
        return InvoiceNumber;

    }

    public Boolean CreditOrDebitNoteShowingInCreatePaymentPage(String InvoiceNumber) {
        try {
            BrowserActions.ScrollDown();
            WaitUtil.shortSleep();
            WebElement row = driver.findElement(By.xpath("//tbody/tr[td/span[@title='" + InvoiceNumber + "' ]]"));
            String val = row.findElement(By.xpath(".//td/span[contains(@id,'cphContent_gvPendingInvoice_lblInvNumber_')]")).getAttribute("title");
            WebElement CheckBox = row.findElement(By.xpath(".//*[contains(@id, 'cphContent_gvPendingInvoice_chkselect_')]"));
            try {
                CheckBox.click();
            } catch (ElementClickInterceptedException ex) {
                BrowserActions.WebElementJSFindAndClick(CheckBox);
            }
            return true;
        } catch (NoSuchElementException ex) {
            return false;
        }

    }

    public void AddNewDebitNote(String customercode, String sell, String RefNum, String customerDocDate,
                                String postingDate, List<String> items) {
        BrowserActions.WaitAndclick(AddNewLink);
        WaitUtil.shortSleep();
        RepitativeMethodsPage.SelectCustomer(customercode);

        AddItems(items);
        BrowserActions.WaitAndclick(SearchButton);

        BrowserActions.WaitAndclick(Reason);
        BrowserActions.Type(ReasonDropDown, sell);
        BrowserActions.WaitAndclick(SelectReason);
        BrowserActions.Type(ReferenceNumber, RefNum);
        BrowserActions.SelectDate(CustomerDoc_Date, customerDocDate);
        BrowserActions.SelectDate(PostIng_Date, postingDate);
        BrowserActions.WaitAndclick(TaxApplicableCheckBox);
        BrowserActions.Type(ChooseFile, "C:\\Users\\WINIT\\Pictures\\Screenshots\\Screenshot (1).png");                                                                                                // import option
        WaitUtil.shortSleep();

    }

    public void FillSKUDetails(double amount, String sellOut, String TurnOverDiscount, String description) {
        BrowserActions.ScrollToElement(CreditNoteAmount_row1);
        BrowserActions.TypeFloatValue(CreditNoteAmount_row1, amount);
        BrowserActions.Type(Description_1, description);
        BrowserActions.TypeFloatValue(CreditNoteAmount_row2, amount);
        BrowserActions.Type(Description_2, description);
    }

    public void AddItems(List<String> items) {
        BrowserActions.WaitAndclick(SellectingSKU);
        for (String item : items) {
            BrowserActions.WaitAndclick(EnterItems);
            BrowserActions.Clear(EnterItems);
            BrowserActions.Type(EnterItems, item);
            WebElement CheckBox = driver
                    .findElement(By.xpath("//div[6]/ul/li/label/input[contains(@value,'" + item + "')]"));
            BrowserActions.WebElementJSFindAndClick(CheckBox);
        }
    }

    public String SaveandGetInvoiceNumber() {
        BrowserActions.WaitAndclick(SaveOption);
        BrowserActions.ScrollToElement(Reason);
        String CreditNoteInvoice = BrowserActions.GetText(CreditNoteNumber);
        return CreditNoteInvoice;
    }

    public void Approve() {
        BrowserActions.ScrollToElement(Approved);
        BrowserActions.WaitAndclick(Approved);
        WaitUtil.shortSleep();
    }

    public double GetGrandTotalCN() {
        String GrandTotal = BrowserActions.GetText(CNGRANDTotal);
        double parsedGrandTotal = Double.parseDouble(GrandTotal);
        return parsedGrandTotal;
    }

}
