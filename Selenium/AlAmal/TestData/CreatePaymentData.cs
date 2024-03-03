using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestData
{
    public class CreatePaymentData
    {

        public static IEnumerable<TestCaseData> CashPaymentAutoAllocate()
        {
            yield return new TestCaseData("96605121", "Cash", "Invoice", "SAR", 10, "Jul 1, 2023");

        }

        public static IEnumerable<TestCaseData> CashPaymentManualAllocate()
        {
            yield return new TestCaseData("96605121", "Cash", "Invoice", "SAR", 10, "Jul 1, 2023");

        }

        public static IEnumerable<TestCaseData> CashPaymentManualAllocateMultipleCustomer()
        {
            yield return new TestCaseData("96602126", "Cash", "Invoice", "SAR", 10, "Jul 1, 2023");
            yield return new TestCaseData("96605122", "Cash", "Invoice", "SAR", 10, "Jul 1, 2023");
        }

        public static IEnumerable<TestCaseData> CashPaymentAllocateButton()
        {
            yield return new TestCaseData("96605121", "Cash", "Invoice", "SAR", 10, "Jul 1, 2023");
        }

        public static IEnumerable<TestCaseData> ChequePaymentVerifyAccStatement()
        {
            yield return new TestCaseData("96600036", "Cheque", "Invoice", "SAR", 10, "Nov 7, 2022", "AL RAJHI BANK", "Riyadh", "1234", "Jul 10, 2023");

        }

        public static IEnumerable<TestCaseData> CashPaymentInnerSearchMultipleCustomer()
        {
            yield return new TestCaseData("96600225", "Cash", "Invoice", "SAR", "120811002328", "INVOICE", "Oct 5, 2022", "Nov 4, 2022", "Oct 5, 2022", "Nov 4, 2022", 7.49, "Jul 10, 2023");

            yield return new TestCaseData("96600098", "Cash", "Invoice", "SAR", "121619000050", "Debit Note", "Aug 18, 2023", "Sep 17, 2023", "Aug 18, 2023", "Sep 17, 2023", 5, "Jul 10, 2023");


        }

        public static IEnumerable<TestCaseData> OnAccountCashPaymentAndSettleDCJ()
        {
            yield return new TestCaseData("96600002", "Jan 1, 2019", "Cash", "OnAccount", "SAR", 20, "10039690", "1234", "10119708");

        }

        public static IEnumerable<TestCaseData> POSPayment()
        {
            yield return new TestCaseData("96600002", "Jan 1, 2019", "POS", "Invoice", "SAR", "RIYAD BANK", "RIYAD", "987654", 30, "Sep 28, 2023");

        }

        public static IEnumerable<TestCaseData> BankOnlinePayment()
        {
            yield return new TestCaseData("96600002", "Jan 1, 2019", "Online", "Invoice", "SAR", "RIYAD BANK", "RIYAD", "123456", 20, "Sep 28, 2023");

        }

        public static IEnumerable<TestCaseData> CashPaymentImportPendingInvoice()
        {
            yield return new TestCaseData("96600001", "Cash", "Invoice", "SAR", "Jul 1, 2023", "120711002119", "CollectionImport");//96602136
        }


        public static IEnumerable<TestCaseData> BankOnlinePaymentSettleAndBounce()
        {
            yield return new TestCaseData("96600304", "Online", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "12345@", "Oct 3, 2023", "111000022983", "Why Only me?", 11, "Feb 21, 2022", "10039690", "1234",
            "10123339", "ksaadmin", "1234");
        }


        public static IEnumerable<TestCaseData> ChequePaymentImportSettlement()
        {
            yield return new TestCaseData
                ("96602223", "Cheque", "Invoice", "SAR", "Nov 1, 2022", "AL RAJHI BANK", "Riyadh", "987654321",
                "Nov 1, 2022", "240311004138", "10039690", "1234", "10039203", "CollectionImport");
        }



        public static IEnumerable<TestCaseData> ChequePaymentAndCancelPayment()
        {
            yield return new TestCaseData("96600304", "Cheque", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "12345@", "Oct 3, 2023", "111000022983", "Why Only me?", 11, "Feb 21, 2022", "10039690", "1234",
            "10123339", "ksaadmin", "1234");
        }

        public static IEnumerable<TestCaseData> OnAccBankOnlinePaymentCancel()
        {
            yield return new TestCaseData("96600002", "Jan 1, 2019", "Online", "OnAccount", "SAR", "RIYAD BANK", "RIYAD", "123456", 20, "Feb 21, 2022", "10039690", "1234", "10119708");


        }

        public static IEnumerable<TestCaseData> CashPaymentImportCreditNote()
        {
            yield return new TestCaseData
                ("96602223", "5074", "Cash", "Invoice", "SAR", "Nov 1, 2022", "10", "CreditImport");//96606270  // 5019 is  reference number,we must change whenever we runs the code
        }

        public static IEnumerable<TestCaseData> ChequePaymentSettleAndBounce()
        {
            yield return new TestCaseData("96600304", "Cheque", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "12345@", "Oct 3, 2023", "111000022983", "Why Only me?", 11, "Feb 21, 2022", "10039690", "1234",
            "10123339", "ksaadmin", "1234");
        }

        public static IEnumerable<TestCaseData> ChequePaymentSettleAndReversal()
        {
            yield return new TestCaseData("96600304", "Cheque", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "12345@", "Oct 3, 2023", "111000022983", "Why Only me?", 11, "Feb 21, 2022", "10039690", "1234",
            "10123339", "ksaadmin", "1234");
        }

        public static IEnumerable<TestCaseData> BankOnlinePaymentSettleAndReversal()
        {
            yield return new TestCaseData("96600304", "Online", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "12345@", "Oct 3, 2023", "111000022983", "Why Only me?", 11, "Feb 21, 2022", "10039690", "1234",
            "10123339", "ksaadmin", "1234");
        }

        public static IEnumerable<TestCaseData> POSPaymentBounce()
        {
            yield return new TestCaseData("96600002", "Jun 1, 2023", "POS", "Invoice", "SAR", "RIYAD BANK", "RIYAD", "987654", 30, "Sep 28, 2023", "10119708", "10039690", "1234", "ksaadmin", "1234");

        }

        public static IEnumerable<TestCaseData> CreditNoteCreation()
        {
            yield return new TestCaseData("96600304", "2002276", "2002279", "57",
         "Oct 17, 2023", "Oct 17, 2023", 3, "sell", "TurnOverDiscount", "Gowri", "Feb 21, 2022", "Cash", "Invoice", "SAR", "111000022983", 20);

        }

        public static IEnumerable<TestCaseData> OnAccountBankPaymentAndSettleDCJ()
        {
            yield return new TestCaseData("96600002", "Sep 1, 2023", "Online", "OnAccount", "SAR", "RIYAD BANK", "RIYAD", "123456", 20, "Nov 2, 2023", "10039690", "1234", "10119708");

        }

        public static IEnumerable<TestCaseData> OnAccountPOSPaymentAndSettleDCJ()
        {
            yield return new TestCaseData("96600002", "Sep 1, 2023", "POS", "OnAccount", "SAR", "RIYAD BANK", "RIYAD", "123456", 20, "Nov 2, 2023", "10039690", "1234", "10119708");

        }

        public static IEnumerable<TestCaseData> CashPaymentCancellation()
        {
            yield return new TestCaseData("96600304", "Cash", "Invoice", "SAR", "111000022983", 5, "Feb 21, 2022",
            "10039690", "1234", "10123339");

        }

        public static IEnumerable<TestCaseData> BankOnlinePaymentcancellatation()
        {
            yield return new TestCaseData("96600304", "Online", "Invoice", "SAR", "POS SAUDI HOLLANDI BANK",
            "HOLLANDI", "1", "Nov 6, 2023", "111000022983", "Why Only me?", 5, "Feb 21, 2022", "10039690", "1234", "10123339");

        }

        public static IEnumerable<TestCaseData> DebitNoteImport()
        {
            yield return new TestCaseData
         ("96602223", "ram999", "Cash", "Invoice", "SAR", "Jan 1, 2023", "20", "DebitImport");//96606270  // 5019 is  reference number,we must change whenever we runs the code
        }
        public static IEnumerable<TestCaseData> DebitNoteReject()
        {
            yield return new TestCaseData
         ("96602223", "999130", "DebitImport");
        }
        public static IEnumerable<TestCaseData> DebitNoteCancel()
        {
            yield return new TestCaseData
         ("96602223", "999130", "Cash", "Invoice", "SAR", "Jan 1, 2023", "20", "DebitImport", "10046478", "10039690", "1234");
        }

        public static IEnumerable<TestCaseData> DebitNoteCollectAndSettle()
        {
            yield return new TestCaseData
         ("96602223", "999130", "Cash", "Invoice", "SAR", "Jan 1, 2023", "20", "DebitImport", "10046478", "10039690", "1234");
        }

        public static IEnumerable<TestCaseData> OnAccountChequePaymentAndSettleDCJ()
        {
            yield return new TestCaseData("96600002", "Sep 1, 2023", "Cheque", "OnAccount", "SAR", "RIYAD BANK", "RIYAD", "123456", 20, "Nov 2, 2023", "10039690", "1234", "10119708");

        }

        public static IEnumerable<TestCaseData> DebitNoteCreationManual()
        {
            yield return new TestCaseData("96600304", "999130",
         "Nov 8, 2023", "Nov 9, 2023", 3, "sell", "TurnOverDiscount", "ManojTetsingDebitnote1", "Feb 21, 2022", "Cash", "Invoice", "SAR");
        }







    }
}
