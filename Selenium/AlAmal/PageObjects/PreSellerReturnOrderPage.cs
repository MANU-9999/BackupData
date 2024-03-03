using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class PreSellerReturnOrderPage : BasePage
    {
        By Transactions = By.Id("ancSfaTransactions");
        By PresellerReturnOrderLink = By.LinkText("PreSeller Return Orders");
        By CreateReturnOrderButton = By.Id("cphContent_CreateOrderDiv");
        By Customer = By.CssSelector("#cphContent_updatepanel1 > div > button");
        By Filter = By.CssSelector("body > div:nth-child(15) > div > div > input[type=search]");
        By FilteredCustomer = By.XPath("//*[@id='ng-app']/body/div[9]/ul/li[17]/label/span");
        By PickUpDate = By.Id("cphContent_txtDeliveryDate");
        By CustomerRefDate = By.Id("cphContent_txtCutoffDate");
        By CustomerRefNo = By.Id("cphContent_txtPONumberxyz");
        By ProceedButton = By.Id("cphContent_btnAddEdit");
        By AddItemsButton = By.Id("cphContent_Divaddbtn");
        By ItemSearchBox = By.Id("txtitemsearch");
        By ItemCheckBox = By.XPath("//div/div[2]/div[3]/div[1]/div/input");
        By AddButton = By.Id("btnAddItemModel");
        By Quantity1 = By.XPath("//tbody/tr[1]/td[8]/input");
        By ReasonType1 = By.CssSelector(".gridrow:nth-child(1) .ddlReasons");
        By ReturnReason1 = By.CssSelector(".gridrow:nth-child(1) .ddlSubReasons");
        By Quantity2 = By.XPath("//tbody/tr[2]/td[8]/input");
        By ReasonType2 = By.CssSelector(".gridrow:nth-child(2) .ddlReasons");
        By ReturnReason2 = By.CssSelector(".gridrow:nth-child(2) .ddlSubReasons");
        By Quantity3 = By.XPath("//tbody/tr[3]/td[8]/input");
        By ReasonType3 = By.CssSelector(".gridrow:nth-child(3) .ddlReasons");
        By ReturnReason3 = By.CssSelector(".gridrow:nth-child(3) .ddlSubReasons");
        By Remove = By.XPath("//*[@id='gvTrxheaderItemManual']/tbody/tr/td[20]/a");
        By Save = By.Id("cphContent_btnFinalize");
        By PendingFinanceApproval = By.CssSelector("#Fra156 > a.selReport_NoClass.selected_color");
        By OrderNo = By.CssSelector("a[title='View Order Details']");
        By ApproveButton = By.Id("cphContent_ancApprove");
        By YesButton = By.Id("cphContent_LinkButton3");
        By FinanceApproved = By.CssSelector("#Fra156 > a:nth-child(7)");
        By FinanceApprovedTable = By.CssSelector("#tblDelivered");

        public PreSellerReturnOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToPresellerReturnOrder()
        {
            BrowserActions.Click(Transactions);
            BrowserActions.Click(PresellerReturnOrderLink);
            WaitUtil.Sleep5sec();
            WaitUtil.WaitForLoaderToComplete();

        }

        public void PresellerReturnOrder(string customercode, string pickupdate, string customerrefdate)
        {
            BrowserActions.Click(CreateReturnOrderButton);
            BrowserActions.Click(Customer);
            BrowserActions.Click(Filter);
            BrowserActions.Type(Filter, customercode);
            WaitUtil.WaitForLoaderToComplete();
            //driver.FindElement(By.CssSelector("#cphContent_updatepanel1 > div:nth-child(1) > button:nth-child(2) > span:nth-child(2)")).Click();
            //driver.FindElement(By.CssSelector(".ui-state-hover > span:nth-child(2)")).Click();
            // driver.FindElement(By.CssSelector("body > div:nth-child(15) > div > div > input[type=search]")).Click();
            //  driver.FindElement(By.XPath("//*[@id='ng-app']/body/div[9]/div/div/input")).SendKeys("96600047");
            //driver.FindElement(By.XPath("/html/body/div[9]/ul/li[4]/label/span")).Click();
            //Modified xpath as above xpath is failing
            // Thread.Sleep(3000);

            BrowserActions.Click(FilteredCustomer);
            BrowserActions.Click(PickUpDate);
            BrowserActions.SelectDate(PickUpDate, pickupdate);
            BrowserActions.Click(CustomerRefDate);
            BrowserActions.SelectDate(CustomerRefDate, customerrefdate);
            Random random = new Random();
            int PONumber = random.Next(0, 1000);
            String convertedPONumber = PONumber.ToString();
            BrowserActions.Type(CustomerRefNo, convertedPONumber);
            BrowserActions.Click(ProceedButton);

        }

        public void AddItem(string itemcode)
        {
            BrowserActions.Click(AddItemsButton);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Type(ItemSearchBox, itemcode);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.ShortSleep();
            BrowserActions.Click(ItemCheckBox);
            BrowserActions.Click(AddButton);
        }




        public void EnterItem1Data(string quantity1, string reasontype1, string returnreason1)
        {
            BrowserActions.Type(Quantity1, quantity1);
            BrowserActions.Select(ReasonType1, reasontype1);
            BrowserActions.Select(ReturnReason1, returnreason1);
        }

        public void EnterItem2Data(string quantity2, string reasontype2, string returnreason2)
        {
            BrowserActions.Type(Quantity2, quantity2);
            BrowserActions.Select(ReasonType2, reasontype2);
            BrowserActions.Select(ReturnReason2, returnreason2);
        }

        public void EnterItem3Data(string quantity3, string reasontype3, string returnreason3)
        {
            BrowserActions.Type(Quantity3, quantity3);
            BrowserActions.Select(ReasonType3, reasontype3);
            BrowserActions.Select(ReturnReason3, returnreason3);
        }
        public void DeleteItem()
        {
            BrowserActions.Click(Remove);
        }

        public void ConfirmOrder()
        {
            BrowserActions.Click(Save);
            WaitUtil.Sleep10sec();
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.ClickEnter();
        }

        public int VerifyFARowCount()
        {
            BrowserActions.Click(FinanceApproved);
            int i = BrowserActions.GetRowCount(FinanceApprovedTable);
            return i;

        }
        public void ApproveOrder()
        {
            BrowserActions.Click(PendingFinanceApproval);
            WaitUtil.Sleep10sec();
            //BrowserActions.Click(PendingFinanceApproval);
            //WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Click(OrderNo);
            BrowserActions.Click(ApproveButton);
            BrowserActions.Click(YesButton);

        }

        public void PresellerReturnOrderWithPromotion(string customercode, string pickupdate, string customerrefdate)
        {
            BrowserActions.Click(CreateReturnOrderButton);
            BrowserActions.Click(Customer);
            BrowserActions.Click(Filter);
            BrowserActions.Type(Filter, customercode);
            WaitUtil.WaitForLoaderToComplete();
            //driver.FindElement(By.CssSelector("#cphContent_updatepanel1 > div:nth-child(1) > button:nth-child(2) > span:nth-child(2)")).Click();
            //driver.FindElement(By.CssSelector(".ui-state-hover > span:nth-child(2)")).Click();
            // driver.FindElement(By.CssSelector("body > div:nth-child(15) > div > div > input[type=search]")).Click();
            //  driver.FindElement(By.XPath("//*[@id='ng-app']/body/div[9]/div/div/input")).SendKeys("96600047");
            //driver.FindElement(By.XPath("/html/body/div[9]/ul/li[4]/label/span")).Click();
            //Modified xpath as above xpath is failing
            // Thread.Sleep(3000);

            BrowserActions.Click(FilteredCustomer);
            BrowserActions.Click(PickUpDate);
            BrowserActions.SelectDate(PickUpDate, pickupdate);
            BrowserActions.Click(CustomerRefDate);
            BrowserActions.SelectDate(CustomerRefDate, customerrefdate);
            Random random = new Random();
            int PONumber = random.Next(0, 1000);
            String convertedPONumber = PONumber.ToString();
            BrowserActions.Type(CustomerRefNo, convertedPONumber);
            BrowserActions.Click(ProceedButton);

        }
    }
}
