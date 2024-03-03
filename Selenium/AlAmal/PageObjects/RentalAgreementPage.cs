using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class RentalAgreementPage : BasePage
    {
        By Master = By.Id("liHeaderMaster");
        By Rental_Agreement = By.LinkText("Rental Agreement");

        By ImportButton = By.CssSelector("a#lnkImportCustomer");
        By DropFilePopUp = By.CssSelector("div div div.dz-default.dz-message");
        By Done = By.CssSelector("div input#cphContent_btnUpload");

        By ActionButton = By.CssSelector("div a#lnkView");
        By RemarksField = By.CssSelector("input#cphContent_txtRemarks");
        By FirstLevelTab = By.CssSelector("li#cphContent_lnkFirstLevelApprovedRental");
        By ApproveButton = By.CssSelector("a#cphContent_btnConfirm");
        By ApproveButton2 = By.CssSelector("a#cphContent_btnApproveFromReject");

        By PopupOkay = By.CssSelector("a#cphContent_lnkConfirm");

        By SecondLevelTab = By.CssSelector("li#cphContent_lnkSecondLevelApprovedRental");
        By FinalLevelTab = By.CssSelector("li#cphContent_lnkFinalApprovedRental");
        By SaveButton = By.CssSelector("input#cphContent_btnSave.button1.wid105px.fl");

        By Filter = By.CssSelector("img[src='../images/ts.png']");
        By SearchRental = By.CssSelector("input#cphContent_btnSeachSubChannel");
        By FromDate = By.CssSelector("div input#cphContent_txtfDate");


        By AddNewButton = By.CssSelector("a#lnkAddNew");
        By CategoryField = By.XPath("//button/span[contains(text(),'Select Category')]");
        By CategorySearchBar = By.XPath("(//div/input[@placeholder='Enter keywords'])[1]");
        //By CategoryName = By.CssSelector("label.ui-corner-all.ui-state-active.ui-state-hover span");
        By Quantity = By.CssSelector("input#cphContent_txtQuantity");
        By QuanRentalCost = By.CssSelector("input#cphContent_txtRentalCode");
        By ItemField = By.XPath("//button/span[contains(text(),'Select Item')]");
        By ItemSearchBar = By.XPath("(//div/input[@placeholder='Enter keywords'])[2]");

        By ReasonField = By.CssSelector("select#cphContent_ddlReason");
        By FrequencyField = By.CssSelector("select#cphContent_ddlFrequency");
        By SaveRental = By.CssSelector("input#cphContent_btnSave");

        By ViewSummary = By.CssSelector("span b a#cphContent_lnkError");
        By SuccesMsg = By.CssSelector("span#cphContent_lblMsg");
        By CancelPopup = By.CssSelector("img#imgClose1");


        public RentalAgreementPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToRentalAgreementPage()
        {
            BrowserActions.Click(Master);
            BrowserActions.Click(Rental_Agreement);
        }
        public void ImportRentalAgreement(string FileName)
        {
            BrowserActions.Click(ImportButton);
            BrowserActions.Click(DropFilePopUp);
            WaitUtil.ShortSleep();
            BrowserActions.ImportfileFormat(FileName);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(Done);
            WaitUtil.ShortSleep();
        }

        public string GetSuccessMsg()
        {
            BrowserActions.JSFindAndClick(ViewSummary);
            string ImportSuccesMsg = BrowserActions.GetText(SuccesMsg);
            WaitUtil.ShortSleep();
            BrowserActions.Click(CancelPopup);
            return ImportSuccesMsg;
        }

        public void RentalAgreementAddNew(string customercode, string category, string quantity, string rentalcost, string itemname, string reason, string Frequency)
        {
            BrowserActions.Click(AddNewButton);
            WaitUtil.ShortSleep();
            SelectCustomer(customercode);

            BrowserActions.Type(Quantity, quantity);
            BrowserActions.Type(QuanRentalCost, rentalcost);

            BrowserActions.JSFindAndClick(CategoryField);
            BrowserActions.Type(CategorySearchBar, category);
            IWebElement CategoryName = driver.FindElement(By.XPath("//label/span[contains(text(),'" + category + "')]"));
            BrowserActions.IWebElementJSFindAndClick(CategoryName);

            BrowserActions.JSFindAndClick(ItemField);
            BrowserActions.Type(ItemSearchBar, itemname);
            IWebElement Item = driver.FindElement(By.XPath("//li/label/span[contains(text(),'" + itemname + "')]"));
            BrowserActions.IWebElementJSFindAndClick(Item);


            BrowserActions.JSFindAndClick(ReasonField);
            BrowserActions.Select(ReasonField, reason);
            BrowserActions.Select(FrequencyField, Frequency);
            BrowserActions.JSFindAndClick(SaveRental);
            WaitUtil.ShortSleep();
        }

        public void FilterToSearchCustomer(String customercode, String fromdate)
        {
            BrowserActions.Click(Filter);
            BrowserActions.Click(FromDate);
            BrowserActions.SelectDate(FromDate, fromdate);
            BrowserActions.Type(FromDate, fromdate);
            SelectCustomer(customercode);
            WaitUtil.ShortSleep();
            BrowserActions.Click(SearchRental);

        }


        public void PendingToFirstLevelApprove(string CustomerCode, string Month, string RemarksText)
        {
            WaitUtil.Sleep5sec();
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + CustomerCode + "']][1]"));
            IWebElement ViewPlus = row.FindElement(By.XPath("//img[contains(@id,'cphContent_gvItemBranchPrice_imgItems_')]"));//.//a[contains(@id,'cphContent_gvItemBranchPrice_ancItems_1')]           
            BrowserActions.IWebElementJSFindAndClick(ViewPlus);
            WaitUtil.ShortSleep();
            try
            {
                IWebElement CustomerBlock = driver.FindElement(By.XPath("//tr[td/span[contains(text(), '" + CustomerCode + "')]]"));
                IWebElement MontheWiseRow = driver.FindElement(By.XPath("//tbody/tr[td/div/div[contains(text(),'" + Month + "')]]"));
                IWebElement ViewIcon = MontheWiseRow.FindElement(By.CssSelector("a#lnkView img"));
                WaitUtil.ShortSleep();
                BrowserActions.IWebElementJSFindAndClick(ViewIcon);
                WaitUtil.ShortSleep();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("The month isnot available :");
            }
            BrowserActions.ScrollToElement(ApproveButton);
            BrowserActions.Click(ApproveButton);
            WaitUtil.ShortSleep();
            BrowserActions.ScrollToElement(PopupOkay);
            BrowserActions.Type(RemarksField, RemarksText);
            BrowserActions.JSFindAndClick(PopupOkay);
            WaitUtil.ShortSleep();
        }


        public void FirstLevelToSecondLevelApprove(string CustomerCode, string RemarksText)
        {
            BrowserActions.Click(FirstLevelTab);
            WaitUtil.ShortSleep();
            //IWebElement Tbody = driver.FindElement(By.XPath("(//tbody[tr[//td/span[contains(text(), '')]]])[2]"));
            // IWebElement row = Tbody.FindElement(By.XPath("(//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')]])[2]"));
            IWebElement row = driver.FindElement
                (By.XPath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
            IWebElement ViewIcon = row.FindElement(By.CssSelector("div a#lnkView"));
            BrowserActions.IWebElementJSFindAndClick(ViewIcon);
            BrowserActions.ScrollToElement(ApproveButton);
            BrowserActions.Click(ApproveButton);
            WaitUtil.ShortSleep();
            BrowserActions.ScrollToElement(PopupOkay);
            BrowserActions.Type(RemarksField, RemarksText);
            BrowserActions.JSFindAndClick(PopupOkay);
            WaitUtil.ShortSleep();
        }
        public void SecondLevelToFinalApprove(string CustomerCode, string RemarksText)
        {
            BrowserActions.Click(SecondLevelTab);
            WaitUtil.ShortSleep();
            //IWebElement Tbody = driver.FindElement(By.XPath("(//tbody[tr[//td/span[contains(text(), '')]]])[2]"));
            IWebElement row = driver.FindElement
                (By.XPath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
            IWebElement ViewIcon = row.FindElement(By.CssSelector("div a#lnkView"));
            BrowserActions.IWebElementJSFindAndClick(ViewIcon);
            BrowserActions.ScrollToElement(ApproveButton);
            BrowserActions.Click(ApproveButton);
            WaitUtil.ShortSleep();
            BrowserActions.ScrollToElement(PopupOkay);
            BrowserActions.Type(RemarksField, RemarksText);
            BrowserActions.JSFindAndClick(PopupOkay);
            WaitUtil.ShortSleep();

        }
        public long FinalApprovedTab(string CustomerCode, string RemarksText)
        {
            BrowserActions.Click(FinalLevelTab);
            WaitUtil.ShortSleep();
            IWebElement row = driver.FindElement
             (By.XPath("//tbody/tr[td/span[contains(text(),'" + CustomerCode + "')] and  td/span[contains(text(),'" + RemarksText + "')]]"));
            IWebElement CreditNoteNoText = row.FindElement(By.XPath("//td[15]/span[@class='lblStoreCheckIsMSL']"));
            // IWebElement ViewIcon = row.FindElement(By.CssSelector("div a#lnkView"));
            // long CreditNoteNo = BrowserActions.GetIWebElementTextByJS(CreditNoteNoText);
            string s = CreditNoteNoText.Text;

            long CreditNoteNo = long.Parse(s);
            return CreditNoteNo;
        }

    }
}
