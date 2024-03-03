using AlAmalFunctionalTests.TestUtils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class PreSellerOrderPage : BasePage
    {
        By Transactions = By.Id("ancSfaTransactions");
        By PresellerOrderLink = By.LinkText("PreSeller Orders");
        By CreateOrderButton = By.Id("cphContent_CreateOrderDiv");
        By Customer = By.CssSelector("#cphContent_updatepanel1 > div > button");
        By Filter = By.CssSelector("body > div:nth-child(15) > div > div > input[type=search]");
        //By FilteredCustomer = By.CssSelector("label[for,'ui-multiselect-cphContent_ddlCustomer-option-'] span");
        By FilteredCustomer = By.XPath("//*[@id='ng-app']/body/div[9]/ul/li[16]/label/span");
        By FilteredCustomerWithPromotion = By.XPath("//*[@id='ng-app']/body/div[9]/ul/li[1399]/label/span");
        By DeliveryDate = By.Id("cphContent_txtDeliveryDate");
        By CustomerRefDate = By.Id("cphContent_txtCutoffDate");
        By PONumber = By.Id("cphContent_txtPONumber");
        By ProceedButton = By.Id("cphContent_btnAddEdit");
        By AddItemsButton = By.Id("cphContent_Divaddbtn");
        By ParentItemCode = By.Id("txtinput");
        By QtyCase = By.CssSelector(".NoClass_savedfoctxt.piece_noclass.clsQuantityCS");
        By QtyPCS = By.CssSelector(".NoClass_savedfoctxt.piece_noclass.clsQuantityPC");


        By ItemCheckBox = By.Id("chkID");
        By AddButton = By.Id("A1");
        By PreviewButton = By.CssSelector("a[onclick='SaveValue();']");
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
        By FinalizeOrder = By.Id("cphContent_btnFinalize");
        By PendingFinanceApproval = By.CssSelector("#Fra156 > a.selReport_NoClass.selected_color");
        By OrderNo = By.XPath("(//a[@title='View Order Details'])[1]");
        By ApproveButton = By.Id("cphContent_ancApprove");
        By YesButton = By.Id("cphContent_LinkButton3");
        By FinanceApproved = By.CssSelector("#Fra156 > a:nth-child(7)");
        By FinanceApprovedTable = By.CssSelector("#tblDelivered");
        By PromotionProceedButton = By.CssSelector("a[onclick='SaveValueOnProceed();']");

        public PreSellerOrderPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToPresellerOrder()
        {
            BrowserActions.Click(Transactions);
            BrowserActions.Click(PresellerOrderLink);
            WaitUtil.Sleep5sec();
            WaitUtil.WaitForLoaderToComplete();

        }

        public void PresellerOrder(string customercode, string deliverydate)
        {
            BrowserActions.Click(CreateOrderButton);
            BrowserActions.Click(Customer);
            BrowserActions.Click(Filter);
            BrowserActions.Type(Filter, customercode);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Click(FilteredCustomer);
            BrowserActions.Click(DeliveryDate);
            BrowserActions.SelectDate(DeliveryDate, deliverydate);


            Random random = new Random();
            int PONum = random.Next(0, 1000);
            String convertedPONumber = PONum.ToString();
            BrowserActions.Type(PONumber, convertedPONumber);
            BrowserActions.Click(ProceedButton);

        }

        public void PresellerOrderWithPromotion(string customercode, string deliverydate)
        {
            BrowserActions.Click(CreateOrderButton);
            BrowserActions.Click(Customer);
            BrowserActions.Click(Filter);
            BrowserActions.Type(Filter, customercode);
            WaitUtil.WaitForLoaderToComplete();

            BrowserActions.Click(FilteredCustomerWithPromotion);
            BrowserActions.Click(DeliveryDate);
            BrowserActions.SelectDate(DeliveryDate, deliverydate);


            Random random = new Random();
            int PONum = random.Next(0, 1000);
            String convertedPONumber = PONum.ToString();
            BrowserActions.Type(PONumber, convertedPONumber);
            BrowserActions.Click(ProceedButton);

        }

        public void AddItem(string itemcode, string qtycase, string qtypcs)
        {
            BrowserActions.Click(AddItemsButton);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Clear(ParentItemCode);
            BrowserActions.Type(ParentItemCode, itemcode);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.ShortSleep();
            BrowserActions.Click(ItemCheckBox);
            BrowserActions.Type(QtyCase, qtycase);
            BrowserActions.Type(QtyPCS, qtypcs);
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

        public void PlaceOrder()
        {
            BrowserActions.ScrollToElement(PreviewButton);
            BrowserActions.Click(PreviewButton);
            BrowserActions.Click(FinalizeOrder);
            WaitUtil.Sleep10sec();
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.ClickEnter();
        }

        public void PlaceOrderWithPromotion()
        {
            BrowserActions.ScrollToElement(PreviewButton);
            BrowserActions.Click(PreviewButton);
            BrowserActions.Click(PromotionProceedButton);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Click(FinalizeOrder);
            WaitUtil.Sleep10sec();
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.ClickEnter();
            //BrowserActions.Click(OrderNo);
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


    }
}
