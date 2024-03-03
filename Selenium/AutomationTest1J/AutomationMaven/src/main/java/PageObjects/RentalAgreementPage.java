package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;

public class RentalAgreementPage extends Base {
    By Master = By.id("liHeaderMaster");
    By Rental_Agreement = By.linkText("Rental Agreement");

    By ImportButton = By.cssSelector("a#lnkImportCustomer");
    By DropFilePopUp = By.cssSelector("div div div.dz-default.dz-message");
    By Done = By.cssSelector("div input#cphContent_btnUpload");

    By ActionButton = By.cssSelector("div a#lnkView");
    By RemarksField = By.cssSelector("input#cphContent_txtRemarks");
    By FirstLevelTab = By.cssSelector("li#cphContent_lnkFirstLevelApprovedRental");
    By ApproveButton = By.cssSelector("a#cphContent_btnConfirm");
    By ApproveButton2 = By.cssSelector("a#cphContent_btnApproveFromReject");

    By PopupOkay = By.cssSelector("a#cphContent_lnkConfirm");

    By SecondLevelTab = By.cssSelector("li#cphContent_lnkSecondLevelApprovedRental");
    By FinalLevelTab = By.cssSelector("li#cphContent_lnkFinalApprovedRental");
    By SaveButton = By.cssSelector("input#cphContent_btnSave.button1.wid105px.fl");

    By Filter = By.cssSelector("img[src='../images/ts.png']");
    By SearchRental = By.cssSelector("input#cphContent_btnSeachSubChannel");
    By FromDate = By.cssSelector("div input#cphContent_txtfDate");


    By AddNewButton = By.cssSelector("a#lnkAddNew");
    By CategoryField = By.xpath("//button/span[contains(text(),'Select Category')]");
    By CategorySearchBar = By.xpath("(//div/input[@placeholder='Enter keywords'])[1]");
    //By CategoryName = By.CssSelector("label.ui-corner-all.ui-state-active.ui-state-hover span");
    By Quantity = By.cssSelector("input#cphContent_txtQuantity");
    By QuanRentalCost = By.cssSelector("input#cphContent_txtRentalCode");
    By ItemField = By.xpath("//button/span[contains(text(),'Select Item')]");
    By ItemSearchBar = By.xpath("(//div/input[@placeholder='Enter keywords'])[2]");

    By ReasonField = By.cssSelector("select#cphContent_ddlReason");
    By FrequencyField = By.cssSelector("select#cphContent_ddlFrequency");
    By SaveRental = By.cssSelector("input#cphContent_btnSave");

    By ViewSummary = By.cssSelector("span b a#cphContent_lnkError");
    By SuccesMsg = By.cssSelector("span#cphContent_lblMsg");
    By CancelPopup = By.cssSelector("img#imgClose1");


    public void NavigateToRentalAgreementPage() {
    	WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(Master);
        BrowserActions.Click(Rental_Agreement);
    	WaitUtil.shortSleep();

    }

    public void ImportRentalAgreement(String FileName) {
        BrowserActions.Click(ImportButton);
 BrowserActions.Click(DropFilePopUp);
        WaitUtil.shortSleep();
        BrowserActions.ImportfileFormat(FileName);
        WaitUtil.Sleep5();
        BrowserActions.Click(Done);
        WaitUtil.shortSleep();
    }

    public String GetSuccessMsg() {
        BrowserActions.JSFindAndClick(ViewSummary);
        String ImportSuccesMsg = BrowserActions.GetText(SuccesMsg);
        WaitUtil.shortSleep();
        BrowserActions.Click(CancelPopup);
        return ImportSuccesMsg;
    }

    public void RentalAgreementAddNew(String customercode, String category, String quantity, String rentalcost, String itemname, String reason, String Frequency) {
        BrowserActions.Click(AddNewButton);
        WaitUtil.shortSleep();
        RepitativeMethodsPage.SelectCustomer(customercode);

        BrowserActions.Type(Quantity, quantity);
        BrowserActions.Type(QuanRentalCost, rentalcost);

        BrowserActions.JSFindAndClick(CategoryField);
        BrowserActions.Type(CategorySearchBar, category);
        WebElement CategoryName = driver.findElement(By.xpath("//label/span[contains(text(),'" + category + "')]"));
        BrowserActions.WebElementJSFindAndClick(CategoryName);

        BrowserActions.JSFindAndClick(ItemField);
        BrowserActions.Type(ItemSearchBar, itemname);
        WebElement Item = driver.findElement(By.xpath("//li/label/span[contains(text(),'" + itemname + "')]"));
        BrowserActions.WebElementJSFindAndClick(Item);


        BrowserActions.JSFindAndClick(ReasonField);
        BrowserActions.Select(ReasonField, reason);
        BrowserActions.Select(FrequencyField, Frequency);
        BrowserActions.JSFindAndClick(SaveRental);
        WaitUtil.shortSleep();
    }

    public void FilterToSearchCustomer(String customercode, String fromdate) {
        BrowserActions.Click(Filter);
        BrowserActions.Click(FromDate);
        BrowserActions.SelectDate(FromDate, fromdate);
        BrowserActions.Type(FromDate, fromdate);
        RepitativeMethodsPage.SelectCustomer(customercode);
        WaitUtil.shortSleep();
        BrowserActions.Click(SearchRental);

    }


    public void PendingToFirstLevelApprove(String CustomerCode, String Month, String RemarksText) {
        WaitUtil.Sleep5();
        WebElement row = driver.findElement(By.xpath("//tbody/tr[td/span[@title='" + CustomerCode + "']][1]"));
        WebElement ViewPlus = row.findElement(By.xpath("//img[contains(@id,'cphContent_gvItemBranchPrice_imgItems_')]"));//.//a[contains(@id,'cphContent_gvItemBranchPrice_ancItems_1')]
        BrowserActions.WebElementJSFindAndClick(ViewPlus);
        WaitUtil.shortSleep();
        try {
            WebElement CustomerBlock = driver.findElement(By.xpath("//tr[td/span[contains(text(), '" + CustomerCode + "')]]"));
            WebElement MontheWiseRow = driver.findElement(By.xpath("//tbody/tr[td/div/div[contains(text(),'" + Month + "')]]"));
            WebElement ViewIcon = MontheWiseRow.findElement(By.cssSelector("a#lnkView img"));
            WaitUtil.shortSleep();
            BrowserActions.WebElementJSFindAndClick(ViewIcon);
            WaitUtil.shortSleep();
        } catch (NoSuchElementException ex) {
            System.out.println("The month isnot available :");
        }
        BrowserActions.ScrollToElement(ApproveButton);
        BrowserActions.Click(ApproveButton);
        WaitUtil.shortSleep();
        BrowserActions.ScrollToElement(PopupOkay);
        BrowserActions.Type(RemarksField, RemarksText);
        BrowserActions.JSFindAndClick(PopupOkay);
        WaitUtil.shortSleep();
    }


    public void FirstLevelToSecondLevelApprove(String CustomerCode, String RemarksText) {
        BrowserActions.Click(FirstLevelTab);
        WaitUtil.shortSleep();
        //WebElement Tbody = driver.FindElement(By.XPath("(//tbody[tr[//td/span[contains(text(), '')]]])[2]"));
        // WebElement row = Tbody.FindElement(By.XPath("(//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')]])[2]"));
        WebElement row = driver.findElement
                (By.xpath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
        WebElement ViewIcon = row.findElement(By.cssSelector("div a#lnkView"));
        BrowserActions.WebElementJSFindAndClick(ViewIcon);
        BrowserActions.ScrollToElement(ApproveButton);
        BrowserActions.Click(ApproveButton);
        WaitUtil.shortSleep();
        BrowserActions.ScrollToElement(PopupOkay);
        BrowserActions.Type(RemarksField, RemarksText);
        BrowserActions.JSFindAndClick(PopupOkay);
        WaitUtil.shortSleep();
    }

    public void SecondLevelToFinalApprove(String CustomerCode, String RemarksText) {
        BrowserActions.Click(SecondLevelTab);
        WaitUtil.shortSleep();
        //WebElement Tbody = driver.FindElement(By.XPath("(//tbody[tr[//td/span[contains(text(), '')]]])[2]"));
        WebElement row = driver.findElement
                (By.xpath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
        WebElement ViewIcon = row.findElement(By.cssSelector("div a#lnkView"));
        BrowserActions.WebElementJSFindAndClick(ViewIcon);
        BrowserActions.ScrollToElement(ApproveButton);
        BrowserActions.Click(ApproveButton);
        WaitUtil.shortSleep();
        BrowserActions.ScrollToElement(PopupOkay);
        BrowserActions.Type(RemarksField, RemarksText);
        BrowserActions.JSFindAndClick(PopupOkay);
        WaitUtil.shortSleep();

    }

    public long FinalApprovedTab(String CustomerCode, String RemarksText) {
        BrowserActions.Click(FinalLevelTab);
        WaitUtil.shortSleep();
        WebElement row = driver.findElement
                (By.xpath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
        WebElement CreditNoteNoText = row.findElement(By.xpath("//td[15]/span[@class='lblStoreCheckIsMSL']"));
        // WebElement ViewIcon = row.FindElement(By.CssSelector("div a#lnkView"));
        // long CreditNoteNo = BrowserActions.GetWebElementTextByJS(CreditNoteNoText);
        String s = CreditNoteNoText.getText();

        long CreditNoteNo = Long.parseLong(s);
        return CreditNoteNo;
    }

}



