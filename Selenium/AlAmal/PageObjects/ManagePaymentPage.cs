using AlAmalFunctionalTests.TestUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class ManagePaymentPage : BasePage
    {

        By SelectCustomerLink = By.XPath("//*[text()='Select Customer']");
        //By SelectCustomerLink = By.CssSelector("div.new_slidea>a#lnkShowCustomers");
        By Customer = By.Id("txtSiteId");
        By Search = By.XPath("//input[@onclick='return CustomerSearch();']");
        By CheckBox = By.Name("chkCustomer");
        By FilterButton = By.CssSelector("img[src='../images/ts.png']");
        By SearchButton = By.Id("cphContent_btnSeachSubChannel");
        By InvoiceNumber = By.Id("cphContent_gvPayment_lblInvoice_Number_0");
        By Table = By.TagName("table");
        By Rows = By.TagName("tr");
        By TableData = By.TagName("td");
        By InvoiceList = By.XPath("(//tbody)[1]/tr");
        By ListOFReceipts = By.XPath("//tbody/tr");
        By Receipt = By.XPath("//span[@id='cphContent_gvPayment_lblReceipt_Number_0']");
        By ResetButton = By.Id("cphContent_btnReset");
        By TransactionsMenu = By.Id("ancSfaTransactions");
        By ManagePaymentsLink = By.XPath("//a[normalize-space()='Payments']");
        //chequepayment to be present for that customer with that amount 
        By VoidText = By.XPath("//a[@id='cphContent_gvPayment_lblReceipt_NumberVoid_0']");
        By ActionButton = By.CssSelector("#cphContent_gvPayment_lnkView_0 > img");
        By CancelPaymentButton = By.Id("cphContent_lnkCancelPayment");
        By CancelReason = By.Id("cphContent_txtCancelDocNumber");
        By CancelPaymentYesButton = By.Id("cphContent_lnkCancelPaymentConfirm");
        By FromDate = By.Id("cphContent_txtfDate");
        By ReceiptNumberInFilter = By.Id("cphContent_txtReceiptNumber");
        By ReceiptNoInViewPaymentDetails = By.Id("cphContent_lblReceiptNumber");
        By ClickOnFilter = By.XPath("//img[@src='../images/ts.png']");
        By SalesManDropDown = By.XPath("//span[normalize-space()='Select Salesman']");
        By EnterUSERCODE = By.XPath("(//input[@placeholder='Enter keywords'])[1]");
        By FilterSearchButton = By.Id("cphContent_btnSeachSubChannel");
        By CheckAll = By.XPath("(//span[contains(text(),'Check all')])[1]");
        By SalesOrg = By.XPath("//button[@type='button']//span[contains(text(),'Select Sales Organization')]");
        By SalesOrgCheckBox = By.Id("ui-multiselect-cphContent_CM_UC_ddlSalesOrg-option-0");


        public ManagePaymentPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetPaymentDetails(string customercode)

        {
            WaitUtil.ShortSleep();
            BrowserActions.Click(FilterButton);
            BrowserActions.Click(SelectCustomerLink);
            WaitUtil.ShortSleep();
            BrowserActions.Type(Customer, customercode);
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.Click(Search);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.Sleep10sec();
            BrowserActions.Click(CheckBox);
            BrowserActions.ClickTab();
            BrowserActions.ClickEnter();
            //BrowserActions.Click(DoneButton);
            WaitUtil.WaitForLoaderToComplete();
            WaitUtil.Sleep5sec();
            BrowserActions.Click(SearchButton);
            WaitUtil.WaitForLoaderToComplete();
            string Invoice = BrowserActions.GetText(InvoiceNumber);
            return Invoice;
        }

        public void VerifyInvoiceNo(string InvoiceOriginal)
        {
            // Find the table element
            IWebElement table = BrowserActions.GetTable(Table);
            // IWebElement table = driver.FindElement(By.TagName("table"));

            // Find all rows in the table
            IList<IWebElement> rows = table.FindElements(Rows);
            bool expectedValueFound = false;

            // Loop through the rows and verify the content of the second column
            foreach (IWebElement row in rows)
            {
                // Find all columns (td) in the row
                IList<IWebElement> columns = row.FindElements(TableData);

                if (columns.Count >= 2) // Ensure there are at least two columns
                {
                    string actualValue = columns[1].Text; // Get the text of the second column
                    string expectedValue = InvoiceOriginal; // Replace with your expected value

                    if (actualValue == expectedValue)
                    {
                        expectedValueFound = true;
                        Console.WriteLine("Verification passed for: " + InvoiceOriginal);
                        //Assert.Pass(expectedValue+ "is present");

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Verification failed for: " + InvoiceOriginal);
                    }
                }

            }

            if (!expectedValueFound)
            {
                Assert.Fail("expected value not found");
            }

        }

        public string GetPaymentReceipt()
        {

            string PaymentReceipt = BrowserActions.GetText(Receipt);
            return PaymentReceipt;
        }

        public void FilterWithReceipt(string PaymentReceipt)
        {
            BrowserActions.Click(FilterButton);
            //BrowserActions.Click(ResetButton);
            WaitUtil.Sleep5sec();
            BrowserActions.Type(ReceiptNumberInFilter, PaymentReceipt);
            BrowserActions.Click(SearchButton);
        }

        public void VerifyRowContainsVoidText()
        {
            //string rowLocator = BrowserActions.GetText(ROW);
            string rowText = BrowserActions.GetText(VoidText);

            // Use NUnit assertion to check if the row contains void text
            Assert.IsFalse(string.IsNullOrWhiteSpace(rowText), "The row does not contain void text.");
        }

        public void NavigateToManagePaymentPage()
        {
            BrowserActions.Click(TransactionsMenu);
            BrowserActions.Click(ManagePaymentsLink);
            WaitUtil.WaitForLoaderToComplete();
            Thread.Sleep(5000);

        }

        public void CancelPayment()
        {
            BrowserActions.Click(ActionButton);
            BrowserActions.Click(CancelPaymentButton);
            BrowserActions.Click(CancelPaymentYesButton);


        }

        public void FilterWithReceiptAndFromDate(string PaymentReceipt, string fromdate)
        {
            BrowserActions.Click(FilterButton);
            // BrowserActions.Click(ResetButton);
            WaitUtil.Sleep5sec();
            BrowserActions.Click(FromDate);
            BrowserActions.SelectDate(FromDate, fromdate);
            BrowserActions.Type(ReceiptNumberInFilter, PaymentReceipt);
            BrowserActions.Click(SearchButton);
        }

        public string GetReceiptNoFromViewPaymentDetails()
        {

            string PaymentReceipt = BrowserActions.GetText(ReceiptNoInViewPaymentDetails);
            return PaymentReceipt;
        }

        public void FilterSalesOrgSalesman(String userCode)
        {
            BrowserActions.Click(ClickOnFilter);

            WaitUtil.Sleep5sec();
            BrowserActions.Click(SalesOrg);
            BrowserActions.Click(SalesOrgCheckBox);
            SelectUser(userCode);
            WaitUtil.WaitForLoaderToComplete();
            // BrowserActions.Click(SalesManDropDown);
            //BrowserActions.Click(SelectUserLink);
            //BrowserActions.Click(EnterUSERCODE);
            //BrowserActions.Type(EnterUSERCODE, userCode);
            // BrowserActions.Click(CheckAll);
            //BrowserActions.Select(EnterUSERCODE,userCode);
            //BrowserActions.Click(FilterSearchButton);
        }




        public void FilterReset()
        {
            BrowserActions.Click(FilterButton);
            BrowserActions.Click(ResetButton);
            WaitUtil.Sleep5sec();

        }

        public string GetReceiptNumberofTransaction(string InvoiceNumber)
        {
            string InvoiceNum = InvoiceNumber;
            IWebElement invoiceRow = BrowserActions.FindingRowIWebElement(InvoiceNum);

            if (invoiceRow != null)
            {
                IWebElement receiptNumberSpan = invoiceRow.FindElement(By.XPath(".//td/span[contains(@id, '_lblReceipt_Number_')]"));
                string receiptNumber = receiptNumberSpan.Text;

                // Now, assert that the invoiceRow contains the receiptNumber.
                Assert.IsTrue(invoiceRow.Text.Contains(receiptNumber));

                return receiptNumber;
            }

            return "Row not found";
        }

        public double ReceiptNumbertext;
        public List<string> AfterPaymentGetDetailsByRow(string number)
        {

            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + number + "' ]][1]"));
            string ReceiptNumberFinalValue = row.FindElement(By.XPath("//tr/td[1]/span[@title]")).GetAttribute("title");
            string PaymentModeFinalValue = row.FindElement(By.XPath("//tr/td[7]/span[@title]")).GetAttribute("title");
            string AmountFinalValue = row.FindElement(By.XPath("//tr/td[9]/span[@title]")).GetAttribute("title");
            ReceiptNumbertext = double.Parse(ReceiptNumberFinalValue);
            return new List<string> { ReceiptNumberFinalValue, PaymentModeFinalValue, AmountFinalValue };
            // ReceiptNumbertext = ReceiptNumberFinalValue;
        }























    }
}
