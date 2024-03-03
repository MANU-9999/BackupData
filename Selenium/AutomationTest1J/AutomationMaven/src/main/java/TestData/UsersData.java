package TestData;

import org.testng.annotations.DataProvider;

public class UsersData {

    @DataProvider(name = "CreateUserManual")
    public static Object[][] CreateUserManual() {

        return new Object[][]{{"VanSales", "TestUserCode7", "TestUserName7", "C_PRESALES_VANSALES", "96604719",
                "Sales", "Arla KSA", "SELF", "Dammam", "DAMT01"}};
    }

    @DataProvider(name = "AddVehicle")
    public static Object[][] AddVehicle() {

        return new Object[][]{{"Vechile1", "TS01AB0001", "[DFML] Arla KSA"}};
    }


    @DataProvider(name = "AssignVehicles")
    public static Object[][] AssignVehicles() {

        return new Object[][]{{"[DFML] Arla KSA", "BATT01", "96617000"}};
    }

}
