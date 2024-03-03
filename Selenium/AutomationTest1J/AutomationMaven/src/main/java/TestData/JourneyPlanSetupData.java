package TestData;

import org.testng.annotations.DataProvider;

public class JourneyPlanSetupData {

    @DataProvider(name = "JourneyPlanSetupManual")
    public static Object[][] JourneyPlanSetupManual() {

        return new Object[][]{{"TestJP5", "Test description", "Dec 05, 2023", "Dec 31, 2024", "KSA", "[DFML] Arla KSA", "111723"}};

    }

}
