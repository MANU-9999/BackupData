package Arla.AutomationMaven;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

import org.testng.Assert;
import org.testng.annotations.Test;

import PageObjects.CollectionSettlementPage;
import PageObjects.CreateDebitNotePage;
import PageObjects.CustomerOutstandingPage;
import PageObjects.DailyCashJournalPage;
import PageObjects.HomePage;
import PageObjects.LoginPage;
import PageObjects.PaymentPage;
import PageObjects.RentalAgreementPage;
import TestData.DebitNoteData;
import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;


public class DebitNoteTest extends Base {

    @Test(dataProvider = "DebitNoteImport", dataProviderClass = DebitNoteData.class)
    public void DebitNoteImport(String CustomerCode, String RefNum, String paymentmode, String documenttype,
                                String currency, String fromdate, String ModifyAmount, String filename) {
        // NOTE:Mandatory fileds to update -- 1.Ref.No in data

        CreateDebitNotePage createDebitNote = new CreateDebitNotePage();
        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.ImportDebitNotefile(filename);

        RentalAgreementPage ImportPopupMsg = new RentalAgreementPage();
        System.out.println(ImportPopupMsg.GetSuccessMsg());
        Assert.assertTrue(ImportPopupMsg.GetSuccessMsg().contains("Succesfully"));

        String InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
        Assert.assertNotNull(InvoiceNumber, "DebitNote Inserted with Invoice Number: " + InvoiceNumber);

        createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
        createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        List<Double> DebitNoteinOutStandingPage = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
        Assert.assertNotNull(DebitNoteinOutStandingPage, "DebitNote Inserted with Invoice Number: " + InvoiceNumber);

        PaymentPage paymentpage = new PaymentPage();
        paymentpage.NavigateToPaymentPage();
        paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
        Boolean DebitNoteinCreatePaymentPage = createDebitNote
                .CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
        Assert.assertTrue(DebitNoteinCreatePaymentPage, "DebitNote showing in Create Payment Page");

        // createDebitNote.NavigateToSalesTransaction();

    }

    @Test(dataProvider = "DebitNoteReject", dataProviderClass = DebitNoteData.class)
    public void DebitNoteReject(String CustomerCode, String RefNum, String filename) {

        // NOTE:Mandatory fileds to update -- 1.Ref.No in data

        CreateDebitNotePage createDebitNote = new CreateDebitNotePage();
        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.ImportDebitNotefile(filename);

        RentalAgreementPage ImportPopupMsg = new RentalAgreementPage();
        Assert.assertTrue(ImportPopupMsg.GetSuccessMsg().contains("Succesfully"));

        String InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
        Assert.assertNotNull(InvoiceNumber, "DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");

        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.Reject(CustomerCode, RefNum);
        String DebitNoteinRejectTab = createDebitNote.GetDebitNoteConfirmationByNumber(CustomerCode, RefNum);
        Assert.assertNotNull(DebitNoteinRejectTab, "DebitNote cancelled successfully");

    }

    @Test(dataProvider = "DebitNoteCancel", dataProviderClass = DebitNoteData.class)
    public void DebitNoteCancel(String CustomerCode, String RefNum, String paymentmode, String documenttype,
                                String currency, String fromdate, String ModifyAmount, String filename) {
        // NOTE:Mandatory fileds to update -- 1.Ref.No in data
        CreateDebitNotePage createDebitNote = new CreateDebitNotePage();
        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.ImportDebitNotefile(filename);

        RentalAgreementPage ImportPopupMsg = new RentalAgreementPage();
        System.out.println(ImportPopupMsg.GetSuccessMsg());
        Assert.assertTrue(ImportPopupMsg.GetSuccessMsg().contains("Succesfully"));

        String InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
        Assert.assertNotNull(InvoiceNumber, "DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
        createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
        createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        List<Double> DebitNoteinOutStandingPage = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
        Assert.assertNotNull(DebitNoteinOutStandingPage, "DebitNote Inserted Outstanding Page");

        PaymentPage paymentpage = new PaymentPage();
        paymentpage.NavigateToPaymentPage();
        paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
        Boolean DebitNoteinCreatePaymentPage = createDebitNote
                .CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
        Assert.assertTrue(DebitNoteinCreatePaymentPage, "DebitNote showing in Create Payment Page");

        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.Cancel(CustomerCode, RefNum);
        String DebitNoteinCanceledTab = createDebitNote.DebitNoteConfirmationCancelTab(CustomerCode, RefNum);
        Assert.assertNotNull(DebitNoteinCanceledTab, "DebitNote cancelled successfully");

    }


    @Test(dataProvider = "DebitNoteCollectAndSettle", dataProviderClass = DebitNoteData.class)
    public void DebitNoteCollectAndSettle(String CustomerCode, String RefNum, String paymentmode, String documenttype,
                                          String currency, String fromdate, String ModifyAmount, String filename, String UserCode, String cashieruser,
                                          String cashierpassword) {
        // NOTE:Mandatory fileds to update -- 1.Ref.No in data
        CreateDebitNotePage createDebitNote = new CreateDebitNotePage();
        createDebitNote.NavigateToCreateDebitNote();
        createDebitNote.ImportDebitNotefile(filename);

        RentalAgreementPage ImportPopupMsg = new RentalAgreementPage();
        System.out.println(ImportPopupMsg.GetSuccessMsg());
        Assert.assertTrue(ImportPopupMsg.GetSuccessMsg().contains("Succesfully"));

        String InvoiceNumber = createDebitNote.GetDebitNoteInvoiceNumber(CustomerCode, RefNum);
        Assert.assertNotNull(InvoiceNumber, "DebitNote Inserted with Invoice Number :" + InvoiceNumber + "");
        createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
        createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        List<Double> DebitNoteinOutStandingPage = BrowserActions.OutStandingLinesGetText(InvoiceNumber);
        Assert.assertNotNull(DebitNoteinOutStandingPage, "DebitNote Inserted Outstanding Page");

        PaymentPage paymentpage = new PaymentPage();
        paymentpage.NavigateToPaymentPage();
        paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
        Boolean DebitNoteinCreatePaymentPage = createDebitNote.CreditOrDebitNoteShowingInCreatePaymentPage(InvoiceNumber);
        createDebitNote.SavePayement();


        WaitUtil.shortSleep();
        List<Object> PaymentPage = BrowserActions.AfterPaymentGetDetailsByRow(InvoiceNumber);
        String ReceiptNumber = String.valueOf(PaymentPage.get(0));
        Assert.assertTrue(DebitNoteinCreatePaymentPage, "Collected DebitNote showing in Payment Page");
        Assert.assertNotNull(PaymentPage, "DebitNote showing in Create Payment Page");

        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        try {
            BrowserActions.OutStandingLinesGetText(InvoiceNumber);
        } catch (NoSuchElementException ex) {
            System.out.println("DebitNote Removed from Outstanding Page" + ex.getMessage());
        }


        HomePage homePage = new HomePage();
        homePage.logout();
        homePage.clickHereToLoginAgain();
        LoginPage loginPage = new LoginPage();
        loginPage.CashierLogin(cashieruser, cashierpassword);

        CollectionSettlementPage collectionSettlementPage = new CollectionSettlementPage();
        collectionSettlementPage.NavigateToCollectionSettlementPage();
        collectionSettlementPage.FilterWithUser(UserCode);
        collectionSettlementPage.FilterWithReceipt(ReceiptNumber);
        collectionSettlementPage.Settlement();

        DailyCashJournalPage dailyCashJournalPage = new DailyCashJournalPage();
        dailyCashJournalPage.NavigateToDailyCashJournal();
        dailyCashJournalPage.DailyCashJoournalFilter(UserCode, fromdate);
        String DCJConfirmation = DailyCashJournalPage.DCJConfirmation(UserCode, (String) PaymentPage.get(2));
        Assert.assertNotNull(DCJConfirmation, "Test failed in DAILYCASH JOURNAL Page");


    }

    @Test(dataProvider = "DebitNoteCreationManualData", dataProviderClass = DebitNoteData.class)
    public void DebitNoteCreationManual(String CustomerCode, String RefNum, String customerDocDate, String postingDate,
                                        double amount, String sellOut, String TurnOverDiscount, String description, String fromdate,
                                        String paymentmode, String documenttype, String currency) {

        CreateDebitNotePage createDebitNote = new CreateDebitNotePage();
        createDebitNote.NavigateToCreateDebitNote();

        List<String> items = new ArrayList<>();
        List<String> additionalItems = List.of("19596", "38876");
        items.addAll(additionalItems);

        createDebitNote.AddNewDebitNote(CustomerCode, sellOut, RefNum, customerDocDate, postingDate, items);
        createDebitNote.FillSKUDetails(amount, sellOut, description, TurnOverDiscount);
        double CNGrandTotal = createDebitNote.GetGrandTotalCN();
        String DebitNoteInvoiceNumber = createDebitNote.SaveandGetInvoiceNumber();
        createDebitNote.Approve();

        // createDebitNote.FirstLevelApprove(CustomerCode, RefNum);
        createDebitNote.SecondLevelApprove(CustomerCode, RefNum);

        CustomerOutstandingPage customeroutstandingpage = new CustomerOutstandingPage();
        customeroutstandingpage.NavigateToCustomerOutstandingPage();
        customeroutstandingpage.FilterToSearchCustomer(CustomerCode, fromdate);
        List<Double> DebitNoteinOutStandingPage = BrowserActions.OutStandingLinesGetText(DebitNoteInvoiceNumber);
        Assert.assertNotNull(DebitNoteinOutStandingPage, "DebitNote Inserted Outstanding Page");

        PaymentPage paymentpage = new PaymentPage();
        paymentpage.NavigateToPaymentPage();
        paymentpage.SearchCustomer(CustomerCode, paymentmode, documenttype, currency);
        Boolean DebitNoteinCreatePaymentPage = createDebitNote
                .CreditOrDebitNoteShowingInCreatePaymentPage(DebitNoteInvoiceNumber);
        Assert.assertTrue(DebitNoteinCreatePaymentPage, "DebitNote showing in Create Payment Page");
    }

}