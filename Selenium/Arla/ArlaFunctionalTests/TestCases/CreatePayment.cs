using ArlaFunctionalTests.PageObjects;
using ArlaFunctionalTests.TestData;
using ArlaFunctionalTests.TestSetup;
using ArlaFunctionalTests.TestUtils;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.TestCases
{
    public class CreatePayment : Base


    {
        //Developed by Ramakrishna G
        [Test,Order(1)]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentAutoAllocate))]
        public void CashPaymentAutoAllocate(string customercode, string paymentmode, string documenttype, string currency, float amount, string fromdate)
        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            //float balamount = paymentPage.SelectCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.AutoAllocate(amount);
            //float amt = amount;
            //verify invoice number is same in Manage payments
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);           
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);
            double Expectedbalanceamount = Outbalanceinitial - amount;
            //Expectedbalanceamount = (float)Math.Round(Expectedbalanceamount, 1);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Outbalance = (float)Math.Round(Outbalance, 1);
            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);

        }

        //Developed by Ramakrishna G. Updated to print Assertion results by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentManualAllocate))]
        public void CashPaymentManualAllocate(string customercode, string paymentmode, string documenttype, string currency, float amount, string fromdate)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            //float balamount = paymentPage.SelectCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.ManualAllocate(amount);
            //float amt = amount;
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal),"Invoice Assertion Fail");            
            Console.WriteLine("Invoice Actual:" + InvoiceActual  +  " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual +  " is equal to Invoice Original: " + InvoiceOriginal);
            double Expectedbalanceamount = Outbalanceinitial - amount;
            //Expectedbalanceamount = (float)Math.Round(Expectedbalanceamount, 1);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
           // Outbalance = (float)Math.Round(Outbalance, 1);
            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount),"Actual Outstanding balance is not equal to expected balance");
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance  +  " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);

        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentManualAllocateMultipleCustomer))]
        public void CashPaymentManualAllocateMultipleCustomer(string customercode, string paymentmode, string documenttype, string currency, float amount, string fromdate)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            //float balamount = paymentPage.SelectCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.ManualAllocate(amount);
            //float amt = amount;
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);            
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            double Expectedbalanceamount = Outbalanceinitial - amount;
            //Expectedbalanceamount = (float)Math.Round(Expectedbalanceamount, 1);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Outbalance = (float)Math.Round(Outbalance, 1);
            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentAllocateButton))]
        public void CashPaymentAllocateButton(string customercode, string paymentmode, string documenttype, string currency, float amount, string fromdate)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            //float balamount = paymentPage.SelectCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.ClickAllocate();
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);           
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Outbalance = (float)Math.Round(Outbalance, 1);
            Assert.That(Outbalance, Is.EqualTo(Outbalanceinitial));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);

        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.ChequePaymentVerifyAccStatement))]
        public void ChequePaymentVerifyAccStatement(string customercode, string paymentmode, string documenttype, string currency, float amount, string fromdate, string bankname, string branchname, string chequeno, string chequedate)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            AccountStatementPage accountStatementPage = new AccountStatementPage(driver);
            accountStatementPage.NavigateToAccStatement();
            accountStatementPage.SearchAccStatement(customercode, fromdate);

            int initialrowcount = accountStatementPage.VerifyRowCount();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            //float balamount = paymentPage.SelectCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.ManualCheque(bankname, branchname, chequeno, amount, chequedate);

            //verify invoice number is same in Manage payments
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            accountStatementPage.NavigateToAccStatement();
            accountStatementPage.SearchAccStatement(customercode, fromdate);
            int actualrows = accountStatementPage.VerifyRowCount();

            //Verify if row count increased by 1
            Assert.That(actualrows, Is.GreaterThan(initialrowcount));

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Outbalance = (float)Math.Round(Outbalance, 1);
            Assert.That(Outbalance, Is.EqualTo(Outbalanceinitial));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);

        }


        //Developed by Gowri Prabhu C

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentInnerSearchMultipleCustomer))]

        public void CashPaymentInnerSearchMultipleCustomer(string customercode, string paymentmode, string documentype, string currency, string invoicenumber, string doctype, string duestartdate, string dueenddate, string invoicestartdate, string invoiceenddate, double amount, string fromdate)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentype, currency);
            string InvoiceOriginal = paymentPage.InnerSearchDetails(invoicenumber, customercode, doctype, duestartdate, dueenddate, invoicestartdate, invoiceenddate, amount);
            //verify invoice number is same in Manage payments

            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(invoicenumber), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            double Expectedbalanceamount = Outbalanceinitial - amount;
            //Expectedbalanceamount = (double)Math.Round(Expectedbalanceamount, 1);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Outbalance = (double)Math.Round(Outbalance, 1);

            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);

        }

        //Developed by Raghul A. Added Daily Cash Journal by Raghul A.

        
        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.OnAccountCashPaymentAndSettleDCJ))]
        public void OnAccountCashPaymentAndSettleDCJ(string customercode, string fromdate, string paymentmode,
        string documenttype, string currency, double amount, string username, string password, string usercode)

        {

           // CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
           // double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
           // double Expectedbalance = Outbalanceinitial - amount;

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.OnAccEnterCash(amount);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string ReceiptNo = managePaymentPage.GetReceiptNoFromViewPaymentDetails();

           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
           // double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(username, password);

            DailyCashJournalPage dailyCashJournal = new DailyCashJournalPage(driver);
            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double InitialCashAmount = dailyCashJournal.CaptureTotalCashAmount();
            double ExpectedCashAmount = InitialCashAmount + amount;

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(usercode);
            collectionSettlementPage.FilterWithReceipt(ReceiptNo);
            collectionSettlementPage.Settlement();

            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double FinalCashAmount = dailyCashJournal.CaptureTotalCashAmount();
            Assert.That(FinalCashAmount, Is.EqualTo(ExpectedCashAmount));
            // Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalance));
           //Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalance);
           // test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalance);
        }




        //Developed by Raghul A

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.POSPayment))]
        public void POSPayment(string customercode, string fromdate, string paymentmode, string documenttype, string currency, string bankname, string branchname, string refnumber, float amount, string transferdate)

        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.POSPayment(bankname, branchname, refnumber, amount, transferdate, documenttype);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);

            managePaymentPage.VerifyInvoiceNo(InvoiceOriginal);


            //Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal));

            double Expectedbalanceamount = Outbalanceinitial - amount;
            //Expectedbalanceamount = (float)Math.Round(Expectedbalanceamount, 1);

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
        }

        //Developed by Raghul Kannan

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.BankOnlinePayment))]
        public void BankOnlinePayment(string customercode, string fromdate, string paymentmode, string documenttype, string currency, string bankname, string branchname, string refnumber, double amount, string transferdate)

        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.OnlinePaymentAndGetInvoice(bankname, branchname, refnumber, amount, transferdate, documenttype);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal),"Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            double Expectedbalanceamount = Outbalanceinitial - amount;
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
        }

        //Developed by Manoj C
        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentImportPendingInvoice))]
        public void CashPaymentImportPendingInvoice(string customercode, string paymentmode, string documenttype, string currency, string fromdate, string invoicenumber, string filename)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();

            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.Importfile(filename);
            float Amount = paymentPage.GetAmountText();
            double Expectedbalanceamount = Outbalanceinitial - Amount;
            string s = BrowserActions.FindingRow(invoicenumber);
            Assert.That(s != null, "Invoice number not generated");

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalance + " is equal to Expected outstanding balance:" + Expectedbalanceamount);
        }

        //Developed by Gowri Prabhu C
        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.BankOnlinePaymentSettleAndBounce))]

        public void BankOnlinePaymentSettleAndBounce(string customercode, string paymentmode, string documentType, string currency,
        string bankName, string branchName, string refNum, string transferDate, string invoicenumber, string comment, double amount, string fromdate,
        string cashieruser, string cashierpassword, string userCode, string username, string password)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double BeforeCancellingOutbalance = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentType, currency);
            string InvoiceOriginal = paymentPage.OnlinePaymentAndGetInvoiceUsingIS(bankName, branchName, refNum, amount, transferDate,
            comment, invoicenumber);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);

            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();

            double Expectedbalanceamount = BeforeCancellingOutbalance - amount;
            Assert.That(Outbalance, Is.EqualTo(Expectedbalanceamount));
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            // string url = "https://dev-arlavansales.winitsoftware.com/pages/Login.aspx";
            LoginPage loginPage = new LoginPage(driver);
            // loginPage.Navigate(url);
            loginPage.CashierLogin(cashieruser, cashierpassword);

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();

            //List<IWebElement> ReceiptList = customerSettlementPage.ListOfPaymentReceipt();

            //// Check if a receipt with the specified text exists
            //bool receiptFound = ReceiptList.Any(element => element.Text.Equals(PaymentReceipt));

            // Find the receipt element that matches the PaymentReceipt text
            //IWebElement matchingReceipt = ReceiptList.LastOrDefault(element => element.Text.Equals(PaymentReceipt));

            //if (matchingReceipt != null)
            //{
            // customerSettlementPage.AccountSettlement();
            // // Select and click on the matching receipt element SettlementCheckBox
            // matchingReceipt.Click();

            // Console.WriteLine("Receipt selected.");
            //}
            //else

            //{
            // Console.WriteLine("Matching receipt found, but couldn't be clicked.");
            //}
            // Find the receipt element that matches the PaymentReceipt text
            //List<IWebElement> ReceiptList = customerSettlementPage.ListOfPaymentReceipt();
            // IWebElement ele = driver.FindElement(By.XPath($"//tr[.//a[contains(text(), '{PaymentReceipt}')]]"));
            // if (ele != null)
            // {
            //     // Find the checkbox associated with the matching receipt and click it
            //     IWebElement matchingReceiptCheckbox = customerSettlementPage.GetCheckboxForReceipt(ele);
            //     if (matchingReceiptCheckbox != null)
            //     {
            //         matchingReceiptCheckbox.Click();
            //         Console.WriteLine("Receipt selected.");
            //     }

            //}

            // customerSettlementPage.Settlement();

            //IWebElement ReceiptsOfBAnkSettlement = driver.FindElement(By.XPath($"//tr[.//a[contains(text(),'{PaymentReceipt}')]]"));
            //if (ReceiptsOfBAnkSettlement != null)
            //{
            // // Find the checkbox associated with the matching receipt and click it
            // IWebElement matchingBankReceiptCheckbox =customerSettlementPage.GetCheckboxForReceipt(ReceiptsOfBAnkSettlement);
            // if (matchingBankReceiptCheckbox != null)
            // {
            // matchingBankReceiptCheckbox.Click();
            // Console.WriteLine("Receipt selected.");
            // }

            //}

            //customerSettlementPage.Settlement();

            BankTransferCSPage bankTransferCSPage = new BankTransferCSPage(driver);
            bankTransferCSPage.NavigateToBankSettlementPage();
            bankTransferCSPage.FilterSalesman(userCode);
            bankTransferCSPage.ClickOnRoute();
            bankTransferCSPage.FilterWithReceipt(PaymentReceipt);


            //List<IWebElement> BankSettlementReceiptList = bankSettlement.ListOfBAnkReceiptNumbers();
            //IWebElement ele2 = driver.FindElement(By.XPath($"//tr[.//a[contains(text(), '{PaymentReceipt}')]]"));
            //if (ele2 != null)
            //{
            //    // Find the checkbox associated with the matching receipt and click it
            //    IWebElement matchingReceiptCheckbox = bankSettlement.GetBankCheckboxForReceipt(ele2);
            //    if (matchingReceiptCheckbox != null)
            //    {
            //        matchingReceiptCheckbox.Click();
            //        Console.WriteLine("Receipt selected.");
            //    }

            //}

            bankTransferCSPage.BounceTheBAnkReceipt();
            //bankTransferCSPage.VerifyBoucedReceipt();

            string bouncedNum = bankTransferCSPage.VerifyBoucedReceipt(PaymentReceipt);
            Assert.That(PaymentReceipt, Is.EqualTo(bouncedNum));
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            //loginPage.Navigate(url);
            loginPage.KSASalesSuperUserLogin(username, password);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double AfterCancellingOutbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(AfterCancellingOutbalanceinitial, Is.EqualTo(BeforeCancellingOutbalance));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeCancellingOutbalance);
            test.Info("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeCancellingOutbalance);
        }

        // Developed by Manoj C
     

      [Test]
      [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.ChequePaymentImportSettlement))]
      public void ChequePaymentImportSettlement(string customercode, string paymentmode, string documenttype, string currency,
      string fromdate, string bankname, string branchname, string chequeno, string chequedate, string InvoiceNumber,
      string username, string password, string userCode, string FileName)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            List<double> PendingChequeAndOSAmountInitial = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.EnterChequeDetails(bankname, branchname, chequeno, chequedate);
            paymentPage.Importfile(FileName);       //Using import option need to give amount manually
            paymentPage.UploadChequeImage();
            //BrowserActions.ModifyAmount(InvoiceNumber, ModifyAmount);  //comment if it is not required


            var dict = paymentPage.PaymentModeandAmountInitial();

            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            List<string> strings1 = managePaymentPage.AfterPaymentGetDetailsByRow(InvoiceNumber);
            Assert.That(double.Parse(strings1[2]), Is.EqualTo(dict.Item2));             //TotalPaidamountInitial = dict.Item2;
            Assert.That(string.Equals(dict.Item1, strings1[1], StringComparison.OrdinalIgnoreCase));// PaymentModeInital   = dict.Item1

           // ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalancefinal = customerOutstandingPage.VerifyOutstandingBalance();
            //double PendingChequeFinal = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
            List<double> PendingChequeAndOSAmountFinal = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
            Assert.That(Outbalancefinal, Is.EqualTo(outbalanceinitial));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalancefinal + " is equal to Expected outstanding balance:" + outbalanceinitial);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalancefinal + " is equal to Expected outstanding balance:" + outbalanceinitial);
            //  Assert.That(PendingChequeAndOSAmountInitial[0] + dict.Item2, Is.EqualTo(PendingChequeAndOSAmountFinal[0])); //Pending cheque amount  //PendingChequeFinal - dict.Item2


            HomePage homepage = new HomePage(driver);
            homepage.Logout();
            homepage.ClickHereToLoginAgain();

            LoginPage LoginPage = new LoginPage(driver);
            LoginPage.CashierLogin(username, password);

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();

            ChequeCollectionSettlementPage chequeCSPage = new ChequeCollectionSettlementPage(driver);

            chequeCSPage.NavigateToChequeCSPage();
            chequeCSPage.FilterSalesman(userCode);
            chequeCSPage.SelectRouteCCS(userCode);
            chequeCSPage.FilterWithReceipt(PaymentReceipt);
            chequeCSPage.SelectReceiptCCS(PaymentReceipt);
            chequeCSPage.Approve();

            //chequeCSPage.Filter_And_Approve_CSS(customercode, UserCode, fromdate, PaymentReceipt);


            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            List<double> OSAmountAfterChequeApproval = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
            double OSAmountInitial = PendingChequeAndOSAmountInitial[1] - dict.Item2;
            //Assert.That(PendingChequeAndOSAmountInitial[0], Is.EqualTo(OSAmountAfterChequeApproval[1]));
            if (PendingChequeAndOSAmountInitial != null)
            {
                Assert.That(OSAmountAfterChequeApproval[1], Is.EqualTo(OSAmountInitial));
            }
            else
            {
                Console.WriteLine("NullReferenceException line 251");

            }
        }

        // Developed by Gowri Prabhu C
        //cancel payment steps to be added

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.ChequePaymentAndCancelPayment))]

        public void ChequePaymentAndCancelPayment(string customercode, string paymentmode, string documentType, 
        string currency,string bankName, string branchName, string refNum, string transferDate, string invoicenumber, 
        string comment, double amount, string fromdate, string cashieruser, string cashierpassword, string userCode, 
        string username, string password)
        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double BeforeCancellingOutbalance = customerOutstandingPage.VerifyOutstandingBalance();

            List<double> PendingChequeAndOSAmountInitial = customerOutstandingPage.OutStandingLinesGetText(invoicenumber);


            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentType, currency);
            paymentPage.EnterChequeDetails(bankName, branchName, refNum, transferDate);
            // paymentPage.Importfile();
            //paymentPage.uploadChequeImage();

            string InvoiceOriginal = paymentPage.GetTheInvoice(invoicenumber, amount, bankName);



            var dict = paymentPage.PaymentModeandAmountInitial();
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            List<string> strings1 = managePaymentPage.AfterPaymentGetDetailsByRow(InvoiceOriginal);
            Assert.That(double.Parse(strings1[2]), Is.EqualTo(dict.Item2));              //TotalPaidamountInitial = dict.Item2;
            Assert.That(string.Equals(dict.Item1, strings1[1], StringComparison.OrdinalIgnoreCase));// PaymentModeInital   = dict.Item1

            //paymentPage.SavePaymnt();
            //ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);

            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            //Assert.That(Outbalance, Is.EqualTo(BeforeCancellingOutbalance));

            List<double> PendingChequeAndOSAmountFinal = customerOutstandingPage.OutStandingLinesGetText(InvoiceOriginal);
            Assert.That(BeforeCancellingOutbalance, Is.EqualTo(Outbalance));
            Console.WriteLine("Test Pass: Before Cancelling: outstanding balance:" + BeforeCancellingOutbalance + " is equal to After cancellation outstanding balance:" + Outbalance);
            test.Info("Test Pass: Before Cancelling outstanding balance:" + BeforeCancellingOutbalance + " is equal to After cancellation outstanding balance:" + Outbalance);
            //OuStanding Amount
            // Assert.That(PendingChequeAndOSAmountInitial[0] + dict.Item2, Is.EqualTo(PendingChequeAndOSAmountFinal[0])); //Pending cheque amount  //PendingChequeFinal - dict.Item2

            HomePage homePage = new HomePage(driver);
            homePage.Logout();

            string url = "https://dev-arlavansales.winitsoftware.com/pages/Login.aspx";
            LoginPage loginPage = new LoginPage(driver);

            loginPage.Navigate(url);
            loginPage.CashierLogin(cashieruser, cashierpassword);

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();

            ChequeCollectionSettlementPage ChequeCSPage = new ChequeCollectionSettlementPage(driver);
            ChequeCSPage.NavigateToChequeCSPage();
            ChequeCSPage.FilterSalesman(userCode);
            ChequeCSPage.ClickOnRoute();
            ChequeCSPage.FilterWithReceipt(PaymentReceipt);
            ChequeCSPage.CancelTheChequePayment();
            homePage.Logout();
            loginPage.Navigate(url);
            loginPage.KSASalesSuperUserLogin(username, password);
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.FilterWithReceipt(PaymentReceipt);
            managePaymentPage.VerifyRowContainsVoidText();
            Console.WriteLine("Cancelled successfully: Row contains void text");
            test.Info("Cancelled successfully: Row contains void text");
        }
        
        //Developed by  Ramakrishna G 


        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.OnAccBankOnlinePaymentCancel))]
        public void OnAccBankOnlinePaymentCancel(string customercode, string fromdate, string paymentmode,
        string documenttype, string currency, string bankname, string branchname, string refnumber, double amount,
        string transferdate, string username, string password, string usercode)

        {

           // CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
           // double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);



           
            paymentPage.BankOnAccount(bankname, branchname, refnumber, amount, transferdate);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string ReceiptNo = managePaymentPage.GetReceiptNoFromViewPaymentDetails();

            // customerOutstandingPage.NavigateToCustomerOutstandingPage();
            // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            // double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            // Assert.That(FinalOutStandingBalance, Is.EqualTo(Outbalanceinitial));

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(username, password);                                             
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.FilterWithReceipt(ReceiptNo);
            managePaymentPage.CancelPayment();
          
            managePaymentPage.FilterWithReceipt(ReceiptNo);
            managePaymentPage.VerifyRowContainsVoidText();

            // customerOutstandingPage.NavigateToCustomerOutstandingPage();
            // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            // double FinalBalance = customerOutstandingPage.VerifyOutstandingBalance();

            // Assert.That(FinalBalance, Is.EqualTo(Outbalanceinitial));
            //Console.WriteLine("Test Pass: Actual outstanding balance:" + FinalBalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            //test.Info("Test Pass: Actual outstanding balance:" + FinalBalance + " is equal to Expected outstanding balance:" + Outbalanceinitial);

        }

        //Developed by Manoj C

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentImportCreditNote))]
        public void CashPaymentImportCreditNote(string CustomerCode, string RefNum, string paymentmode, string documenttype, string currency, string fromdate, string ModifyAmount, string filename)
        {

            //NOTE:Mandatory fileds to update -- 1.invoiceslist     2.Ref.No in data

            CreateCreditNote createCreditNote = new CreateCreditNote(driver);
            createCreditNote.NavigateToCreateCreditNote();
            createCreditNote.ImportCreditNotefile(filename);
            string InvoiceNumber = createCreditNote.GetCreditNoteInvoiceNumber(CustomerCode, RefNum);
            Assert.That(InvoiceNumber != null, "CreditNote Inserted with Invoice Number :" + InvoiceNumber + "");
            createCreditNote.FirstLevelApprove(CustomerCode, RefNum);
            createCreditNote.SecondLevelApprove(CustomerCode, RefNum);


            CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage(driver);
            customeroutstandingpage.NavigateToCustomerOutstandingPage();
            customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
            // List<double> Row = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
            double OutbalanceInitial = customeroutstandingpage.VerifyOutstandingBalance();
            Assert.That(customeroutstandingpage.OutStandingLinesGetText(InvoiceNumber) != null, "CreditNote Inserted Outstanding Page");



            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
            System.Collections.Generic.List<string> invoiceslist = new System.Collections.Generic.List<string>() { "240311004138" };
            foreach (string invoice in invoiceslist)
            {
                try
                {
                    createCreditNote.CreditOrDebitNoteShowingInCreatePaymentPage(invoice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while processing invoice {invoice}: {ex.Message}");
                }
            }
            Assert.That(createCreditNote.CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber) == true, "CreditNote Inserted outstanding page");
            paymentPage.ModifyAmount(invoiceslist[0], ModifyAmount);
            var TotalPaidAmount = paymentPage.PaymentModeandAmountInitial();

            // createCreditNote.SavePayement();
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);

            Assert.That(managePaymentPage.AfterPaymentGetDetailsByRow(InvoiceNumber) != null, "CreditNote Inserted Payment page page");


            customeroutstandingpage.NavigateToCustomerOutstandingPage();
            customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
            double Outbalancefinal = Math.Round(customeroutstandingpage.VerifyOutstandingBalance());
            double OutbalanceAfterDeduction = Math.Round(OutbalanceInitial - TotalPaidAmount.Item2);
            Assert.That(Math.Round(Outbalancefinal), Is.EqualTo(OutbalanceAfterDeduction));
            Console.WriteLine("Assert Pass: Outbalance final " + Outbalancefinal +"is equal to Outbalance after deduction " + OutbalanceAfterDeduction);
            test.Info("Assert Pass: Outbalance final " + Outbalancefinal + "is equal to Outbalance after deduction " + OutbalanceAfterDeduction);

            try
            {
                customeroutstandingpage.OutStandingLinesGetText(InvoiceNumber);
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("CN noted Removed succesfully: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred: " + ex.Message);
            }


        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.ChequePaymentSettleAndBounce))]
        public void ChequePaymentSettleAndBounce(string customercode, string paymentmode, string documentType, string currency,
        string bankName, string branchName, string refNum, string transferDate, string invoicenumber, string comment, double amount,
        string fromdate, string cashieruser, string cashierpassword, string userCode, string username, string password)
        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double BeforeCancellingOutbalance = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentType, currency);
            paymentPage.EnterChequeDetails(bankName, branchName, refNum, transferDate);
            // paymentPage.Importfile();
            //paymentPage.uploadChequeImage();
            string InvoiceOriginal = paymentPage.GetTheInvoice(invoicenumber, amount, bankName);

            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalance, Is.EqualTo(BeforeCancellingOutbalance));
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, cashierpassword);
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();
            ChequeCollectionSettlementPage ChequeCSPage = new ChequeCollectionSettlementPage(driver);
            ChequeCSPage.NavigateToChequeCSPage();
            ChequeCSPage.FilterSalesman(userCode);
            ChequeCSPage.ClickOnRoute();
            ChequeCSPage.FilterWithReceipt(PaymentReceipt);

            ChequeCSPage.Bounce();
            ChequeCSPage.FilterSalesman(userCode);
            ChequeCSPage.ClickBounceTabAndRouteLink();
            ChequeCSPage.FilterWithReceipt(PaymentReceipt);
            int rowcount = ChequeCSPage.VerifyRowCount();

            Assert.That(rowcount, Is.EqualTo(2));

            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            //loginPage.Navigate(url);
            loginPage.KSASalesSuperUserLogin(username, password);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double AfterCancellingOutbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(AfterCancellingOutbalanceinitial, Is.EqualTo(BeforeCancellingOutbalance));
            Console.WriteLine("Test Pass: After Cancelling outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeCancellingOutbalance);
            test.Info("Test Pass: After cancelling  outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeCancellingOutbalance);

        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.ChequePaymentSettleAndReversal))]
        public void ChequePaymentSettleAndReversal(string customercode, string paymentmode, string documentType, string currency,
        string bankName, string branchName, string refNum, string transferDate, string invoicenumber, string comment, double amount,
        string fromdate, string cashieruser, string cashierpassword, string userCode, string username, string password)
        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double BeforeReversalOutbalance = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentType, currency);
            paymentPage.EnterChequeDetails(bankName, branchName, refNum, transferDate);
            // paymentPage.Importfile();
            //paymentPage.uploadChequeImage();
            string InvoiceOriginal = paymentPage.GetTheInvoice(invoicenumber, amount, bankName);

            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalance = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalance, Is.EqualTo(BeforeReversalOutbalance));
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, cashierpassword);
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();
            ChequeCollectionSettlementPage ChequeCSPage = new ChequeCollectionSettlementPage(driver);
            ChequeCSPage.NavigateToChequeCSPage();
            ChequeCSPage.FilterSalesman(userCode);
            ChequeCSPage.ClickOnRoute();
            ChequeCSPage.FilterWithReceipt(PaymentReceipt);
            ChequeCSPage.Approve();

            //Verify if the outstanding balance is deducted
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double ActualOutbalanceAfterApprove = customerOutstandingPage.VerifyOutstandingBalance();
            double ExpectedOutbalanceAfterApprove = BeforeReversalOutbalance - amount;
            Assert.That(ActualOutbalanceAfterApprove, Is.EqualTo(ExpectedOutbalanceAfterApprove));

            //Reverse it by clicking cancelpayment
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.FilterWithReceiptAndFromDate(PaymentReceipt,fromdate);
            managePaymentPage.CancelPayment();
            //managePaymentPage.FilterWithReceiptAndFromDate(PaymentReceipt, fromdate);
            string ReceiptNo = managePaymentPage.GetPaymentReceipt();
            Assert.That(ReceiptNo.Contains("R"));
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            //loginPage.Navigate(url);
            loginPage.KSASalesSuperUserLogin(username, password);

            // Verify if outstanding balance is same as original balance after reversal
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double AfterCancellingOutbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(AfterCancellingOutbalanceinitial, Is.EqualTo(BeforeReversalOutbalance));

            Console.WriteLine("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeReversalOutbalance);
            test.Info("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeReversalOutbalance);
        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.BankOnlinePaymentSettleAndReversal))]
        public void BankOnlinePaymentSettleAndReversal(string customercode, string paymentmode, string documentType, string currency,
        string bankName, string branchName, string refNum, string transferDate, string invoicenumber, string comment, double amount,
        string fromdate, string cashieruser, string cashierpassword, string userCode, string username, string password)
        {

           // CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
          //  double BeforeReversalOutbalance = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documentType, currency);

            string InvoiceOriginal = paymentPage.OnlinePaymentAndGetInvoiceUsingIS(bankName, branchName, refNum, amount, transferDate, comment, invoicenumber);
            
            //string InvoiceOriginal = paymentPage.GetTheInvoice(invoicenumber, amount, bankName);

            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);
            Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceOriginal);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceOriginal);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
           // double OutbalanceAfterPayment = customerOutstandingPage.VerifyOutstandingBalance();
           // double OutbalanceExpected = BeforeReversalOutbalance - amount;
           // Assert.That(OutbalanceAfterPayment, Is.EqualTo(OutbalanceExpected));
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, cashierpassword);
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();
            


            //Verify if the outstanding balance is deducted
           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
           // double ActualOutbalanceAfterApprove = customerOutstandingPage.VerifyOutstandingBalance();
           // double ExpectedOutbalanceAfterApprove = BeforeReversalOutbalance - amount;
           // Assert.That(ActualOutbalanceAfterApprove, Is.EqualTo(ExpectedOutbalanceAfterApprove));

            //Reverse it by clicking cancelpayment
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.FilterWithReceiptAndFromDate(PaymentReceipt, fromdate);
            managePaymentPage.CancelPayment();
            //Filter with receipt not working due to defect. Instead FilterReset and FilterSalesMan method can be used temporarily
            //managePaymentPage.FilterWithReceiptAndFromDate(PaymentReceipt, fromdate);
            managePaymentPage.FilterReset();
            //managePaymentPage.EnterSalesOrg();
            managePaymentPage.FilterSalesOrgSalesman(userCode);
            string ReceiptNo = managePaymentPage.GetPaymentReceipt();
            Assert.That(ReceiptNo.Contains("R"));
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            //loginPage.Navigate(url);
            loginPage.KSASalesSuperUserLogin(username, password);

            // Verify if outstanding balance is same as original balance after reversal
            // customerOutstandingPage.NavigateToCustomerOutstandingPage();
            // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            // double AfterCancellingOutbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            // Assert.That(AfterCancellingOutbalanceinitial, Is.EqualTo(BeforeReversalOutbalance));
            //Console.WriteLine("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeReversalOutbalance);
            //test.Info("Test Pass: Actual outstanding balance:" + AfterCancellingOutbalanceinitial + " is equal to Expected outstanding balance:" + BeforeReversalOutbalance);
        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.POSPaymentBounce))]
        public void POSPaymentBounce(string customercode, string fromdate, string paymentmode, string documenttype, string currency, string bankname, string branchname, string refnumber, float amount, string transferdate, string userCode, string cashieruser, string cashierpassword, string username, string password)

        {
            //CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
           // customerOutstandingPage.NavigateToCustomerOutstandingPage();
           // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            //double OutbalanceInitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            string InvoiceOriginal = paymentPage.POSPayment(bankname, branchname, refnumber, amount, transferdate, documenttype);
            
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);

            managePaymentPage.VerifyInvoiceNo(InvoiceOriginal);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();


            //Assert.That(InvoiceActual, Is.EqualTo(InvoiceOriginal));


            // double Expectedbalanceamount = OutbalanceInitial - amount;


            // customerOutstandingPage.NavigateToCustomerOutstandingPage();
            // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            // double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            //Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalanceamount));


            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, cashierpassword);

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            collectionSettlementPage.Settlement();

            POSCollectionSettlementPage pOSCollectionSettlementPage = new POSCollectionSettlementPage(driver);
            pOSCollectionSettlementPage.NavigateToPOSCollectionSettlement();
            pOSCollectionSettlementPage.POSBounce();

            //pOSCollectionSettlementPage.FilterSalesman(userCode);
            pOSCollectionSettlementPage.ClickBounceTabAndRouteLink();
            pOSCollectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            int rowcount = pOSCollectionSettlementPage.VerifyRowCount();

            Assert.That(rowcount, Is.EqualTo(2));
            

            homePage.Logout();
            homePage.ClickHereToLoginAgain();
         
            loginPage.KSASalesSuperUserLogin(username, password);
            // customerOutstandingPage.NavigateToCustomerOutstandingPage();
            // customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            // double AfterBounceOutbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            // Assert.That(AfterBounceOutbalanceinitial, Is.EqualTo(OutbalanceInitial));
            // Console.WriteLine("Test Pass: Actual outstanding balance:" + AfterBounceOutbalanceinitial + " is equal to Expected outstanding balance:" + OutbalanceInitial);
            // test.Info("Test Pass: Actual outstanding balance:" + AfterBounceOutbalanceinitial + " is equal to Expected outstanding balance:" + OutbalanceInitial);


        }

        //Developed by Gowri Prabhu

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CreditNoteCreation))]
        public void CreditNoteCreation(string CustomerCode, string Item1, string Item2, string RefNum, string customerDocDate, string postingDate, double amount, string sellOut, string TurnOverDiscount, string description, string fromdate, string paymentmode, string documenttype, string currency, string invoiceNumber, double editableamount)
        {

            //NOTE:Mandatory fileds to update
            //1.invoiceslist     2.Ref.No in data
            CustomerOutstandingPage CustomerOutstandingPage = new CustomerOutstandingPage(driver);

            CustomerOutstandingPage.NavigateToCustomerOutstandingPage();
            CustomerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
            double BeforeCancellingOutbalance = CustomerOutstandingPage.VerifyOutstandingBalance();

            CreateCreditNote createCreditNote = new CreateCreditNote(driver);
            createCreditNote.NavigateToCreateCreditNote();
            //createCreditNote.ImportCreditNotefile();
            createCreditNote.AddNewCreditNote(CustomerCode, Item1, Item2, sellOut, RefNum, customerDocDate, postingDate);
            string TargetCreditNoteInvoice = createCreditNote.SKUDetails(amount, sellOut, description, TurnOverDiscount);
            double CNGrandTotal = createCreditNote.GetGrandTotalCN();
            createCreditNote.FirstLevelApprove();
            createCreditNote.SecondLevelApprove(TargetCreditNoteInvoice);
            string FinalApprovedCreditNoteNumber = createCreditNote.FinalApprovedTab(TargetCreditNoteInvoice);
            Assert.That(FinalApprovedCreditNoteNumber, Is.EqualTo(TargetCreditNoteInvoice));

            CustomerOutstandingPage.NavigateToCustomerOutstandingPage();
            CustomerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
            double AfterGeneratingCreditNote = CustomerOutstandingPage.VerifyOutstandingBalance();

            Assert.That(AfterGeneratingCreditNote, Is.EqualTo(BeforeCancellingOutbalance - CNGrandTotal));
            // double InvoiceNumberOSP= BrowserActions.InvoiceInserteddOSP(InvoiceNumber);
            List<double> OSAmountInitial = CustomerOutstandingPage.OutStandingLinesGetText(TargetCreditNoteInvoice);
            Assert.That(OSAmountInitial[1] != null, "CreditNote Inserted outstanding page");


            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
            // List<IWebElement> ListOfInvoiceNumbers = GetListOfInvoices();
            paymentPage.VerifyingTheInvoicesAndCheckIt(TargetCreditNoteInvoice, invoiceNumber);

            var dict = paymentPage.PaymentModeandAmountInitial();
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            List<string> strings1 = managePaymentPage.AfterPaymentGetDetailsByRow(invoiceNumber);
            double TotalPaidamountInitial = dict.Item2;
            string PaymentModeInital = dict.Item1;
            Assert.That(double.Parse(strings1[2]), Is.EqualTo(TotalPaidamountInitial));              //
            Assert.That(string.Equals(PaymentModeInital, strings1[1], StringComparison.OrdinalIgnoreCase));// 

            // paymentPage.SavePaymnt();
            //ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string InvoiceActual = managePaymentPage.GetPaymentDetails(CustomerCode);
            string ReceiptNumber = managePaymentPage.GetReceiptNumberofTransaction(TargetCreditNoteInvoice);
            Assert.That(InvoiceActual, Is.EqualTo(invoiceNumber));
            CustomerOutstandingPage.NavigateToCustomerOutstandingPage();
            CustomerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
            double Outbalancefinal = CustomerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(BeforeCancellingOutbalance, Is.Not.EqualTo(Outbalancefinal));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + BeforeCancellingOutbalance + " is equal to Expected outstanding balance:" + Outbalancefinal);
            test.Info("Test Pass: Actual outstanding balance:" + BeforeCancellingOutbalance + " is equal to Expected outstanding balance:" + Outbalancefinal);
            try
            {
                CustomerOutstandingPage.OutStandingLinesGetText(TargetCreditNoteInvoice);
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("CN noted Removed succesfully: " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("An error occurred: " + ex.Message);
            }
        }

        //Developed by Raghul
        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.OnAccountBankPaymentAndSettleDCJ))]
        public void OnAccountBankPaymentAndSettleDCJ(string customercode, string fromdate, string paymentmode,
        string documenttype, string currency, string bankname, string branchname, string refnumber, double amount,
        string transferdate, string username, string password, string usercode)

        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            double Expectedbalance = Outbalanceinitial - amount;

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.BankOnAccount(bankname, branchname, refnumber, amount, transferdate);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string ReceiptNo = managePaymentPage.GetReceiptNoFromViewPaymentDetails();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(username, password);

            DailyCashJournalPage dailyCashJournal = new DailyCashJournalPage(driver);
            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double InitialCashAmount = dailyCashJournal.CaptureTotalOnlineAmount();
            double ExpectedCashAmount = InitialCashAmount + amount;

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(usercode);
            collectionSettlementPage.FilterWithReceipt(ReceiptNo);
            collectionSettlementPage.Settlement();

            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double FinalCashAmount = dailyCashJournal.CaptureTotalOnlineAmount();
            Assert.That(FinalCashAmount, Is.EqualTo(ExpectedCashAmount));
            Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalance));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalance);
            test.Info("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalance);

        }

        //Developed by Raghul, Test Passed. 

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.OnAccountPOSPaymentAndSettleDCJ))]
        public void OnAccountPOSPaymentAndSettleDCJ(string customercode, string fromdate, string paymentmode,
        string documenttype, string currency, string bankname, string branchname, string refnumber, double amount,
        string transferdate, string username, string password, string usercode)

        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            double Expectedbalance = Outbalanceinitial - amount;

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.BankOnAccount(bankname, branchname, refnumber, amount, transferdate);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string ReceiptNo = managePaymentPage.GetReceiptNoFromViewPaymentDetails();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(username, password);

            DailyCashJournalPage dailyCashJournal = new DailyCashJournalPage(driver);
            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double InitialCashAmount = dailyCashJournal.CaptureTotalPOSAmount();
            double ExpectedCashAmount = InitialCashAmount + amount;

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(usercode);
            collectionSettlementPage.FilterWithReceipt(ReceiptNo);
            collectionSettlementPage.Settlement();

            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double FinalCashAmount = dailyCashJournal.CaptureTotalPOSAmount();
            Assert.That(FinalCashAmount, Is.EqualTo(ExpectedCashAmount));
            Assert.That(FinalOutStandingBalance, Is.EqualTo(Expectedbalance));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalance);
            test.Info("Test Pass: Actual outstanding balance:" + FinalOutStandingBalance + " is equal to Expected outstanding balance:" + Expectedbalance);

        }

        //Developed by Gowri Prabhu C

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.CashPaymentCancellation))]
        public void CashPaymentCancellation(string customercode, string paymentmode, string documenttype, string currency, 
        string invoiceNum, float amount, string fromdate, string cashieruser, string password, string userCode)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            var details = paymentPage.GetInvoiceandSelect(invoiceNum, amount);
            double TotalduetobePaid = details.Item2;
            string InvoiceNumber = details.Item1;
            double BalanceAmount = details.Item3;
            Assert.That(BalanceAmount, Is.EqualTo(TotalduetobePaid - amount));
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);

            Assert.That(InvoiceActual, Is.EqualTo(InvoiceNumber), "Invoice Assertion Fail");
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceNumber);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceNumber);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);

            double OutbalanceAfterPayment = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalanceinitial, Is.Not.EqualTo(OutbalanceAfterPayment));
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, password);
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            //collectionSettlementPage.Settlement();
            collectionSettlementPage.CancelCashPayment();
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double OutbalanceAfterCancelation = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(OutbalanceAfterCancelation, Is.EqualTo(Outbalanceinitial));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + OutbalanceAfterCancelation + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            test.Info("Test Pass: Actual outstanding balance:" + OutbalanceAfterCancelation + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.GetPaymentDetails(customercode);
            managePaymentPage.VerifyRowContainsVoidText();
            Console.WriteLine("Cancelled successfully: Row contains void text");
            test.Info("Cancelled successfully: Row contains void text");

        }

        // Developed by Gowri Prabhu C

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.BankOnlinePaymentcancellatation))]
        public void BankOnlinePaymentcancellatation(string customercode, string paymentmode, string documenttype,
        string currency, string bankName, string branchName, string refNum, string transferDate, string comment, string
        invoiceNum, float amount, string fromdate, string cashieruser, string password, string userCode)
        {
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            var details = paymentPage.OnlinePaymentAndGetInvoiceAmtDetails(bankName, branchName, refNum, amount,
            transferDate, invoiceNum, comment);
            double TotalduetobePaid = details.Item2;
            string InvoiceNum = details.Item1;
            double BalanceAmount = details.Item3;
            Assert.That(BalanceAmount, Is.EqualTo(TotalduetobePaid - amount));
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            String InvoiceActual = managePaymentPage.GetPaymentDetails(customercode);

            Assert.That(InvoiceActual, Is.EqualTo(InvoiceNum));
            Console.WriteLine("Invoice Actual:" + InvoiceActual + " is equal to Invoice Original:" + InvoiceNum);
            test.Info("Invoice Actual: " + InvoiceActual + " is equal to Invoice Original: " + InvoiceNum);
            string PaymentReceipt = managePaymentPage.GetPaymentReceipt();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double OutbalanceAfterPayment = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalanceinitial, Is.Not.EqualTo(OutbalanceAfterPayment));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + Outbalanceinitial + " is equal to Expected outstanding balance:" + OutbalanceAfterPayment);
            test.Info("Test Pass: Actual outstanding balance:" + Outbalanceinitial + " is equal to Expected outstanding balance:" + OutbalanceAfterPayment);

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(cashieruser, password);
            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(userCode);
            collectionSettlementPage.FilterWithReceipt(PaymentReceipt);
            //collectionSettlementPage.Settlement();
            collectionSettlementPage.CancelBankPayment();
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double OutbalanceAfterCancelation = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(OutbalanceAfterCancelation, Is.EqualTo(Outbalanceinitial));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + OutbalanceAfterCancelation + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            test.Info("Test Pass: Actual outstanding balance:" + OutbalanceAfterCancelation + " is equal to Expected outstanding balance:" + Outbalanceinitial);
            managePaymentPage.NavigateToManagePaymentPage();
            managePaymentPage.GetPaymentDetails(customercode);
            managePaymentPage.VerifyRowContainsVoidText();
            Console.WriteLine("Cancelled successfully: Row contains void text");
            test.Info("Cancelled successfully: Row contains void text");
        }

        //Developed by Raghul A

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.OnAccountChequePaymentAndSettleDCJ))]
        public void OnAccountChequePaymentAndSettleDCJ(string customercode, string fromdate, string paymentmode,
        string documenttype, string currency, string bankname, string branchname, string refnumber, double amount,
        string transferdate, string username, string password, string usercode)

        {

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double Outbalanceinitial = customerOutstandingPage.VerifyOutstandingBalance();

            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.NavigateToPaymentPage();
            paymentPage.SearchCustomer(customercode, paymentmode, documenttype, currency);
            paymentPage.ChequeOnAccount(bankname, branchname, refnumber, amount, transferdate);
            ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
            string ReceiptNo = managePaymentPage.GetReceiptNoFromViewPaymentDetails();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double FinalOutStandingBalance = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(Outbalanceinitial, Is.EqualTo(FinalOutStandingBalance));

            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            homePage.ClickHereToLoginAgain();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.CashierLogin(username, password);

            DailyCashJournalPage dailyCashJournal = new DailyCashJournalPage(driver);
            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double InitialCashAmount = dailyCashJournal.CaptureTotalChequeAmount();
            double ExpectedCashAmount = InitialCashAmount + amount;

            CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
            collectionSettlementPage.NavigateToCollectionSettlementPage();
            collectionSettlementPage.FilterWithUser(usercode);
            collectionSettlementPage.FilterWithReceipt(ReceiptNo);
            collectionSettlementPage.Settlement();

            dailyCashJournal.NavigateToDailyCashJournal();
            dailyCashJournal.FilterWithUser(usercode);
            double FinalCashAmount = dailyCashJournal.CaptureTotalChequeAmount();
            Assert.That(FinalCashAmount, Is.EqualTo(ExpectedCashAmount));

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double OutbalanceBeforeSettlement = customerOutstandingPage.VerifyOutstandingBalance();
            double Expectedbalance = OutbalanceBeforeSettlement - amount;

            ChequeCollectionSettlementPage chequeCollectionSettlementPage = new ChequeCollectionSettlementPage(driver);
            chequeCollectionSettlementPage.NavigateToChequeCSPage();
            chequeCollectionSettlementPage.FilterSalesman(usercode);
            chequeCollectionSettlementPage.ClickOnRoute();
            chequeCollectionSettlementPage.FilterWithReceipt(ReceiptNo);
            chequeCollectionSettlementPage.Approve();

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            double OutbalanceAfterSettlement = customerOutstandingPage.VerifyOutstandingBalance();
            Assert.That(OutbalanceAfterSettlement, Is.EqualTo(Expectedbalance));
            Console.WriteLine("Test Pass: Actual outstanding balance:" + OutbalanceAfterSettlement + " is equal to Expected outstanding balance:" + Expectedbalance);
            test.Info("Test Pass: Actual outstanding balance:" + OutbalanceAfterSettlement + " is equal to Expected outstanding balance:" + Expectedbalance);

        }

        // Developed by Manoj C

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.DebitNoteImport))]
        public void DebitNoteImport(string CustomerCode, string RefNum, string paymentmode, string documenttype, string currency, string fromdate, string ModifyAmount, string filename)
        {
                //NOTE:Mandatory fileds to update --      1.Ref.No in data

                CreateDebitNotePage createDebitNote = new CreateDebitNotePage(driver);
                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.ImportDebitNotefile(filename);


                RentalAgreementPage ImportPopupMsg = new RentalAgreementPage(driver);
                Console.WriteLine(ImportPopupMsg.GetSuccessMsg());
                Assert.IsTrue(ImportPopupMsg.GetSuccessMsg().Contains("Succesfully"));

                string InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
                Assert.That(InvoiceNumber != null, "Assertion Fail: DebitNote not Inserted with Invoice Number :" + InvoiceNumber + "");
                Console.WriteLine("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                test.Info("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
                createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

                CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
                customerOutstandingPage.NavigateToCustomerOutstandingPage();
                customerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
                List<double> DebitNoteinOutStandingPage = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
                Assert.That(DebitNoteinOutStandingPage != null, "Assertion Fail: DebitNote not Inserted Outstanding Page");
                Console.WriteLine("Assertion Pass: DebitNote inserted in Outstanding Page");
                test.Info("Assertion Pass: DebitNote inserted in Outstanding Page");

                PaymentPage paymentpage = new PaymentPage(driver);
                paymentpage.NavigateToPaymentPage();
                paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
                Boolean DebitNoteinCreatePaymentPage = createDebitNote.CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
                Assert.That(DebitNoteinCreatePaymentPage == true, "Assertion Fail: DebitNote not showing in Create Payment Page");
                Console.WriteLine("Assertion Pass: DebitNote showing in Create Payment Page");
                test.Info("Assertion Pass: DebitNote showing in Create Payment Page");

            //createDebitNote.NavigateToSalesTransaction();

        }

        // Developed by Manoj C

            [Test]
            [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.DebitNoteReject))]
            public void DebitNoteReject(string CustomerCode, string RefNum, string filename)
            {

                //NOTE:Mandatory fileds to update --      1.Ref.No in data

                CreateDebitNotePage createDebitNote = new CreateDebitNotePage(driver);
                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.ImportDebitNotefile(filename);


                RentalAgreementPage ImportPopupMsg = new RentalAgreementPage(driver);
                Assert.IsTrue(ImportPopupMsg.GetSuccessMsg().Contains("Succesfully"));

                string InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
                Assert.That(InvoiceNumber != null, "DebitNote not Inserted with Invoice Number :" + InvoiceNumber + "");
                Console.WriteLine("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                test.Info("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.Reject(CustomerCode, RefNum);
                string DebitNoteinRejectTab = createDebitNote.GetDebitNoteConfirmationByNumber(CustomerCode, RefNum);
                Assert.That(DebitNoteinRejectTab != null, "Assertion Fail: DebitNote not cancelled successfully");
                Console.WriteLine("Assertion Pass: DebitNote cancelled successfully");
                test.Info("Assertion Pass: DebitNote cancelled successfully");

        }

        // Developed by Manoj

            [Test]
            [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.DebitNoteCancel))]
            public void DebitNoteCancel(string CustomerCode, string RefNum, string paymentmode, string documenttype, string currency, string fromdate, string ModifyAmount, string filename)
            {
                //NOTE:Mandatory fileds to update --      1.Ref.No in data
                CreateDebitNotePage createDebitNote = new CreateDebitNotePage(driver);
                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.ImportDebitNotefile(filename);

                RentalAgreementPage ImportPopupMsg = new RentalAgreementPage(driver);
                Console.WriteLine(ImportPopupMsg.GetSuccessMsg());
                Assert.IsTrue(ImportPopupMsg.GetSuccessMsg().Contains("Succesfully"));

                string InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
                Assert.That(InvoiceNumber != null, "DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
                createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

                CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage(driver);
                customeroutstandingpage.NavigateToCustomerOutstandingPage();
                customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
                List<double> DebitNoteinOutStandingPage = customeroutstandingpage.OutStandingLinesGetText(InvoiceNumber);
                Assert.That(DebitNoteinOutStandingPage != null, "DebitNote Inserted Outstanding Page");

                PaymentPage paymentpage = new PaymentPage(driver);
                paymentpage.NavigateToPaymentPage();
                paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
                Boolean DebitNoteinCreatePaymentPage = createDebitNote.CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
                Assert.That(DebitNoteinCreatePaymentPage == true, "Assertion Fail: DebitNote not showing in Create Payment Page");
                Console.WriteLine("Assertion Pass: DebitNote showing in Create Payment Page");
                test.Info("Assertion Pass: DebitNote showing in Create Payment Page");

                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.Cancel(CustomerCode, RefNum);
                string DebitNoteinCanceledTab = createDebitNote.DebitNoteConfirmationCancelTab(CustomerCode, RefNum);
                Assert.That(DebitNoteinCanceledTab != null, "DebitNote cancelled successfully");
                Console.WriteLine("Assertion Pass: DebitNote cancelled successfully");
                test.Info("Assertion Pass: DebitNote cancelled succussfully");

        }

        // Developed by Manoj C

            [Test]
            [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.DebitNoteCollectAndSettle))]
            public void DebitNoteCollectAndSettle(string CustomerCode, string RefNum, string paymentmode, string documenttype, string currency,
                string fromdate, string ModifyAmount, string filename, string UserCode, string cashieruser, string cashierpassword)
            {
                //NOTE:Mandatory fileds to update --      1.Ref.No in data
                CreateDebitNotePage createDebitNote = new CreateDebitNotePage(driver);
                createDebitNote.NavigateToCreateDebitNote();
                createDebitNote.ImportDebitNotefile(filename);

                RentalAgreementPage ImportPopupMsg = new RentalAgreementPage(driver);
                Console.WriteLine(ImportPopupMsg.GetSuccessMsg());
                Assert.IsTrue(ImportPopupMsg.GetSuccessMsg().Contains("Succesfully"));
                Console.WriteLine("Assertion Pass: Import success message displayed");
                test.Info("Assertion Pass: Import success message displayed");

            string InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
                Assert.That(InvoiceNumber != null, "Assertion Fail: DebitNote not Inserted with Invoice Number :" + InvoiceNumber + "");
                Console.WriteLine("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                test.Info("Assertion Pass: DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
                createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
                createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

                CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
                customerOutstandingPage.NavigateToCustomerOutstandingPage();
                customerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
                List<double> DebitNoteinOutStandingPage = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
                Assert.That(DebitNoteinOutStandingPage != null, "Assertion Fail: DebitNote not inserted in Outstanding Page");
                Console.WriteLine("Assertion Pass: DebitNote inserted in Outstanding Page");
                test.Info("Assertion Pass: DebitNote inserted in Outstanding Page");
                PaymentPage paymentpage = new PaymentPage(driver);
                paymentpage.NavigateToPaymentPage();
                paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
                Boolean DebitNoteinCreatePaymentPage = createDebitNote.CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
                createDebitNote.SavePayement();
                driver.Navigate().Refresh();
                WaitUtil.ShortSleep();
                ManagePaymentPage managePaymentPage = new ManagePaymentPage(driver);
                List<string> PaymentPage = managePaymentPage.AfterPaymentGetDetailsByRow(InvoiceNumber);
                string ReceiptNumber = managePaymentPage.ReceiptNumbertext.ToString();
                Assert.That(DebitNoteinCreatePaymentPage == true, "Collected DebitNote not showing in Payment Page");
                Console.WriteLine("Assertion Pass: collected DebitNote showing in Payment Page");
                test.Info("Assertion Pass: collected DebitNote showing in Create Payment Page");
                Assert.That(PaymentPage, Is.Not.EqualTo(null), "DebitNote not showing in Create Payment Page");
                Console.WriteLine("Assertion Pass: DebitNote showing in Create Payment Page");
                test.Info("Assertion Pass: DebitNote showing in Create Payment Page");

            customerOutstandingPage.NavigateToCustomerOutstandingPage();
                customerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
                try
                {
                    customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
                }
                catch (NoSuchElementException ex)
                {
                    //Assert.Pass("DebitNote Removed from Outstanding Page" + ex.Message);
                    Console.WriteLine("DebitNote Removed from Outstanding Page" + ex.Message);
                }
                //catch (Exception ex)
                //{
                //    Assert.Fail("An eroor Occcured" + ex.Message);
                //}

                HomePage homePage = new HomePage(driver);
                homePage.Logout();
                homePage.ClickHereToLoginAgain();
                LoginPage loginPage = new LoginPage(driver);
                loginPage.CashierLogin(cashieruser, cashierpassword);

                CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage(driver);
                collectionSettlementPage.NavigateToCollectionSettlementPage();
                collectionSettlementPage.FilterWithUser(UserCode);
                collectionSettlementPage.FilterWithReceipt(ReceiptNumber);
                collectionSettlementPage.Settlement();

                DailyCashJournalPage dailyCashJournalPage = new DailyCashJournalPage(driver);
                dailyCashJournalPage.NavigateToDailyCashJournal();
                dailyCashJournalPage.DailyCashJoournalFilter(UserCode, fromdate);
                // string DebitNoteData=createDebitNote.DailyCashJournalPage(UserCode, PaymentPage[2]);
                // Assert.That(DebitNoteData, Is.Not.EqualTo(null), "DebitNote showing in DAILY CASH JOURNAL Page");

                //createDebitNote.NavigateToSalesTransaction();

            }

        [Test]
        [TestCaseSource(typeof(CreatePaymentData), nameof(CreatePaymentData.DebitNoteCreationManual))]
        public void DebitNoteCreationManual(string CustomerCode, string RefNum, string customerDocDate,
        string postingDate, double amount, string sellOut, string TurnOverDiscount, string description, string fromdate,
        string paymentmode, string documenttype, string currency)
        {

            CreateDebitNotePage createDebitNote = new CreateDebitNotePage(driver);
            createDebitNote.NavigateToCreateDebitNote();

            List<string> items = new List<string> { "19596", "38876" };

            createDebitNote.AddNewDebitNote(CustomerCode, sellOut, RefNum, customerDocDate, postingDate, items);
            createDebitNote.FillSKUDetails(amount, sellOut, description, TurnOverDiscount);
            double CNGrandTotal = createDebitNote.GetGrandTotalCN();
            string DebitNoteInvoiceNumber = createDebitNote.SaveandGetInvoiceNumber();
            createDebitNote.Approve();

            //createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
            createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
            List<double> DebitNoteinOutStandingPage = customerOutstandingPage.OutStandingLinesGetText(DebitNoteInvoiceNumber);
            Assert.That(DebitNoteinOutStandingPage != null, "DebitNote Inserted Outstanding Page");
            Console.WriteLine("Assertion Pass: DebitNote inserted in Outstanding Page");
            test.Info("Assertion Pass: DebitNote inserted in Outstanding Page");

            PaymentPage paymentpage = new PaymentPage(driver);
            paymentpage.NavigateToPaymentPage();
            paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
            Boolean DebitNoteinCreatePaymentPage = createDebitNote.CreditOrDebitNoteShowingInCreatePaymentPage(DebitNoteInvoiceNumber);
            Assert.That(DebitNoteinCreatePaymentPage == true, "DebitNote in Create Payment Page assertion fail");
            Console.WriteLine("Assertion Pass: DebitNote showing in Create Payment Page");
            test.Info("Assertion Pass: DebitNote showing in Create Payment Page");

        }









    }














}
    
