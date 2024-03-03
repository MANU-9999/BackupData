package Arla.AutomationMaven;

import PageObjects.CustomerOutstandingPage;
import PageObjects.HomePage;
import PageObjects.LoginPage;
import PageObjects.RentalAgreementPage;
import TestData.RentalAgreementData;
import TestSetUp.Base;
import TestUtils.BrowserActions;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.util.List;

import static org.testng.Assert.assertTrue;

public class RentalAgreementTest extends Base {
    @Test(dataProvider = "RentalAgreement", dataProviderClass = RentalAgreementData.class)
    public void RentalAgreementImport(String FileName, String CustomerCode, String fromdate, String cashieruser,
                                      String cashierpassword) {

        RentalAgreementPage rentalagreementpage = new RentalAgreementPage();
        rentalagreementpage.NavigateToRentalAgreementPage();
        rentalagreementpage.ImportRentalAgreement(FileName);

         System.out.println(rentalagreementpage.GetSuccessMsg());
//       Assert.IsTrue(rentalagreementpage.GetSuccessMsg.Contains("success"));
//       Assert.IsFalse(rentalagreementpage.GetSuccessMsg().contains("Category Already exists"));
         assertTrue(rentalagreementpage.GetSuccessMsg().contains("Success"));

        HomePage homepage = new HomePage();
        homepage.logout();
        homepage.clickHereToLoginAgain();
        LoginPage LoginPage = new LoginPage();
        LoginPage.CashierLogin(cashieruser, cashierpassword);

        rentalagreementpage.NavigateToRentalAgreementPage();

        String Month=BrowserActions.GetSytemTime(); //Getting current system month--------------------
        String RemarksText=BrowserActions.RandomText(6);
        
        rentalagreementpage.FilterToSearchCustomer(CustomerCode, fromdate);
        rentalagreementpage.PendingToFirstLevelApprove(CustomerCode, Month, RemarksText);
        rentalagreementpage.FirstLevelToSecondLevelApprove(CustomerCode, RemarksText);
        rentalagreementpage.SecondLevelToFinalApprove(CustomerCode, RemarksText);
        String InvoiceNumber = String.valueOf(rentalagreementpage.FinalApprovedTab(CustomerCode, RemarksText));

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        List<Double> Row = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
        // double OutbalanceInitial =
        // customeroutstandingpage.VerifyOutstandingBalance();
        Assert.assertNotNull(Row, "Rental Agreement Inserted Outstanding Page");
        // Assert.That(BrowserActions.OutStandingLinesGetText(CustomerCode) != null,
        // "Rental Agreement Inserted Outstanding Page");
    }

    @Test(dataProvider = "RentalAgreementManual", dataProviderClass = RentalAgreementData.class)
    public void RentalAgreementManual(String customercode, String category, String quantity, String rentalcost,
                                      String itemname, String reason, String Frequency, String fromdate, String cashieruser,
                                      String cashierpassword) {

        RentalAgreementPage rentalagreementpage = new RentalAgreementPage();
        rentalagreementpage.NavigateToRentalAgreementPage();
        rentalagreementpage.RentalAgreementAddNew(customercode, category, quantity, rentalcost, itemname, reason, Frequency);

        HomePage homepage = new HomePage();
        homepage.logout();
        homepage.clickHereToLoginAgain();
        LoginPage LoginPage = new LoginPage();
        LoginPage.CashierLogin(cashieruser, cashierpassword);

        rentalagreementpage.NavigateToRentalAgreementPage();
        
        String Month=BrowserActions.GetSytemTime();
        String RemarksText=BrowserActions.RandomText(6);

      
        rentalagreementpage.FilterToSearchCustomer(customercode, fromdate);
        rentalagreementpage.PendingToFirstLevelApprove(customercode, Month, RemarksText);
        rentalagreementpage.FirstLevelToSecondLevelApprove(customercode, RemarksText);
        rentalagreementpage.SecondLevelToFinalApprove(customercode, RemarksText);
        String InvoiceNumber = String.valueOf(rentalagreementpage.FinalApprovedTab(customercode, RemarksText));

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(customercode, fromdate);
        List<Double> Row = BrowserActions.OutStandingLinesGetText(InvoiceNumber);

        Assert.assertNotNull(Row, "Rental Agreement Inserted Outstanding Page");
    }

}
