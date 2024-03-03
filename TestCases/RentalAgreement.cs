using ArlaFunctionalTests.PageObjects;
using ArlaFunctionalTests.TestSetup;
using ArlaFunctionalTests.TestUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.TestCases
{
    public class RentalAgreement : Base
    {
        [Test]
        [TestCaseSource(nameof(RentalAgreementData))]
        public void RentalAgreementImport(string FileName, string CustomerCode, string fromdate, string cashieruser, string cashierpassword, string Month, string RemarksText)
        {

            RentalAgreementPage rentalagreementpage = new RentalAgreementPage(driver);
            rentalagreementpage.NavigateToRentalAgreementPage();
            rentalagreementpage.ImportRentalAgreement(FileName);

             Console.WriteLine(rentalagreementpage.GetSuccessMsg());
            //Assert.IsTrue(GetSuccessMsg.Contains("success"));
            //Assert.IsFalse(rentalagreementpage.GetSuccessMsg().Contains("Category Already exists"));
            Assert.IsTrue(rentalagreementpage.GetSuccessMsg().Contains("Success"));




            HomePage homepage = new HomePage(driver);
            homepage.Logout();
            homepage.ClickHereToLoginAgain();
            LoginPage LoginPage = new LoginPage(driver);
            LoginPage.CashierLogin(cashieruser, cashierpassword);

            rentalagreementpage.NavigateToRentalAgreementPage();
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            rentalagreementpage.FilterToSearchCustomer(CustomerCode, fromdate);
            rentalagreementpage.PendingToFirstLevelApprove(CustomerCode, Month, RemarksText);
            rentalagreementpage.FirstLevelToSecondLevelApprove(CustomerCode, RemarksText);
            rentalagreementpage.SecondLevelToFinalApprove(CustomerCode, RemarksText);
            string InvoiceNumber = rentalagreementpage.FinalApprovedTab(CustomerCode, RemarksText).ToString();

            //CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(CustomerCode, fromdate);
            List<double> Row = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
            //double OutbalanceInitial = customeroutstandingpage.VerifyOutstandingBalance();
            Assert.That(Row != null, "Rental Agreement Inserted Outstanding Page");
            // Assert.That(BrowserActions.OutStandingLinesGetText(CustomerCode) != null, "Rental Agreement Inserted Outstanding Page");
        }



        [Test]
        [TestCaseSource(nameof(RentalAgreementManualData))]
        public void RentalAgreementManual(string customercode, string category, string quantity, string rentalcost, string itemname,
            string reason, string Frequency, string fromdate
            , string cashieruser, string cashierpassword, string Month, string RemarksText)
        {

            RentalAgreementPage rentalagreementpage = new RentalAgreementPage(driver);
            rentalagreementpage.NavigateToRentalAgreementPage();
            rentalagreementpage.RentalAgreementAddNew(customercode, category, quantity, rentalcost, itemname, reason, Frequency);


            HomePage homepage = new HomePage(driver);
            homepage.Logout();
            homepage.ClickHereToLoginAgain();
            LoginPage LoginPage = new LoginPage(driver);
            LoginPage.CashierLogin(cashieruser, cashierpassword);

            rentalagreementpage.NavigateToRentalAgreementPage();
            CustomerOutstandingPage customerOutstandingPage = new CustomerOutstandingPage(driver);
            rentalagreementpage.FilterToSearchCustomer(customercode, fromdate);
            rentalagreementpage.PendingToFirstLevelApprove(customercode, Month, RemarksText);
            rentalagreementpage.FirstLevelToSecondLevelApprove(customercode, RemarksText);
            rentalagreementpage.SecondLevelToFinalApprove(customercode, RemarksText);

            string InvoiceNumber = rentalagreementpage.FinalApprovedTab(customercode, RemarksText).ToString();

            //CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage(driver);
            customerOutstandingPage.NavigateToCustomerOutstandingPage();
            customerOutstandingPage.FilterToSearchCustomer(customercode, fromdate);
            List<double> Row = customerOutstandingPage.OutStandingLinesGetText(InvoiceNumber);
            //double OutbalanceInitial = customeroutstandingpage.VerifyOutstandingBalance();
            Assert.That(Row != null, "Rental Agreement Inserted Outstanding Page");
            // Assert.That(BrowserActions.OutStandingLinesGetText(CustomerCode) != null, "Rental Agreement Inserted Outstanding Page");
        }

        public static IEnumerable<TestCaseData> RentalAgreementData()
        {
            yield return new TestCaseData("RentalAgreement", "96610346", "Jan 1, 2023", "10039690", "1234", "November", "practice7");//96600365

        }
        public static IEnumerable<TestCaseData> RentalAgreementManualData()
        {
            yield return new TestCaseData
                ("96602223", "Lurpak Cooler", "1", "64", "10003", "Space Rental", "Yearly", "Jan 1, 2023", "10039690", "1234", "November", "practice7");//96600365
                                                                                                                                                        //customercode, category, quantity, rentalcost, itemname,reason, Frequency, fromdate, cashieruser, cashierpassword, Month, RemarksText
                                                                                                                                                        //Puck Labneh Cooler  ,  Lurpak Cooler  , CCSM    , Puck Cooler  , BDA Do not use

        }


    }
}





    

