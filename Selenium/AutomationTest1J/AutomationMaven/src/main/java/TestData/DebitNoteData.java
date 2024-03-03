package TestData;

import org.testng.annotations.DataProvider;

public class DebitNoteData {

    @DataProvider(name = "DebitNoteImport")
    public Object[][] DebitNoteImport() {
        return new Object[][]{
                {"96602223", "Ref100", "Cash", "Invoice", "SAR", "Nov 27, 2023", "20", "ImportDebitNote"}};
    }

    @DataProvider(name = "DebitNoteReject")
    public Object[][] DebitNoteReject() {
        return new Object[][]{
                {"96602223", "Ref100", "ImportDebitNote"}};
    }

    @DataProvider(name = "DebitNoteCancel")
    public Object[][] DebitNoteCancel() {
        return new Object[][]{
                {"96602223", "Ref100", "Cash", "Invoice", "SAR", "Nov 27, 2023", "20", "ImportDebitNote"}};
    }

    @DataProvider(name = "DebitNoteCollectAndSettle")
    public Object[][] DebitNoteCollectAndSettle() {
        return new Object[][]{{"96602223", "raf2", "Cash", "Invoice", "SAR", "Nov 27, 2023", "20",
                "ImportDebitNote", "10039203", "10039690", "1234"}};
    }

    @DataProvider(name = "DebitNoteCreationManualData")
    public Object[][] DebitNoteCreationManualData() {
        return new Object[][]{{"96600304", "Ref100", "Nov 27, 2023", "Nov 30, 2023", 3, "sell", "TurnOverDiscount",
                "ManojTetsingDebitnote2", "Nov 27, 2023", "Cash", "Invoice", "SAR"}};
    }
}