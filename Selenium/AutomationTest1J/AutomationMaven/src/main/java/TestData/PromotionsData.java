package TestData;

import org.testng.annotations.DataProvider;

public class PromotionsData {

    @DataProvider(name = "InstantPromotionFOC")
    public static Object[][] InstantPromotionFOC() {
        return new Object[][]{{"TestPromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Instant", "Test And Dummy Description", "PCS", "Qty", "10", "PCS", "1"}};
    }

    @DataProvider(name = "InstantPromotionDiscountPer")
    public static Object[][] InstantPromotionDiscountPer() {
        return new Object[][]{{"TestPromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Instant", "Test And Dummy Description", "PCS", "Discount %", "10", "PCS", "4"}};
    }

    @DataProvider(name = "InstantPromotionDiscountAmount")
    public static Object[][] InstantPromotionDiscountAmount() {
        return new Object[][]{{"TestPromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Instant", "Test And Dummy Description", "PCS", "Discount Amount", "10", "PCS", "50"}};
    }

    // Bundle Promotions--------------------

    @DataProvider(name = "BundlePromotionFOC")
    public static Object[][] BundlePromotionFOC() {
        return new Object[][]{{"BundlePromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Bundle", "Test And Dummy Description", "PCS", "5", "100", "10000", "FOC", "7", "PCS", "1"}};
    }

    @DataProvider(name = "BundlePromotionDiscountPer")
    public static Object[][] BundlePromotionDiscountPer() {
        return new Object[][]{{"BundlePromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Bundle", "Test And Dummy Description", "PCS", "5", "100", "10000", "FOC", "7", "PCS", "4", "1"}};
    }

    @DataProvider(name = "BundlePromotionDiscountAmount")
    public static Object[][] BundlePromotionDiscountAmount() {
        return new Object[][]{{"BundlePromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Bundle", "Test And Dummy Description", "PCS", "5", "100", "10000", "FOC", "7", "PCS", "4", "1"}};
    }
    // Invoice Promotions--------------------

    @DataProvider(name = "InvoicePromotionDiscountPer")
    public static Object[][] InvoicePromotionDiscountPer() {
        return new Object[][]{{"TestPromotion1", "Nov 30, 2023", "Nov 30, 2023", "[DFML] Arla KSA", "[4] SALES REP",
                "1001 (1001)", "Invoice", "Test And Dummy Description", "5", "650", "Discount (%)"}};
    }
}
