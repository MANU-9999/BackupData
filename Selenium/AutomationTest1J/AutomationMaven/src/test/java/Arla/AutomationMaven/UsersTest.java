package Arla.AutomationMaven;

import PageObjects.AssignVehiclesPage;
import PageObjects.UsersPage;
import PageObjects.VehicleMasterPage;
import TestData.UsersData;
import TestSetUp.Base;
import org.testng.annotations.Test;

public class UsersTest extends Base {

    @Test(dataProvider = "CreateUserManual", dataProviderClass = UsersData.class)
    public void CreateUserManual(String UserType, String userCode, String name, String RoleType, String billToCustomer,
                                 String departmentType, String orgType, String ReportTo, String Depot, String Route) {

        UsersPage usersPage = new UsersPage();
        usersPage.NavigateToUsers();
        usersPage.UserDetails(UserType, userCode, name, RoleType, billToCustomer, departmentType, orgType, ReportTo);
        usersPage.AssignLocationsRouteLevel(Depot, Route);
    }

    @Test(dataProvider = "AddVehicle", dataProviderClass = UsersData.class)
    public void AddVehicle(String vehicleCode, String vehicleNo, String org) {

        VehicleMasterPage vehicleMasterPage = new VehicleMasterPage();
        vehicleMasterPage.NavigateToVechileMasterPage();
        vehicleMasterPage.AddDetails(vehicleCode, vehicleNo, org);
    }


    @Test(dataProvider = "AssignVehicles", dataProviderClass = UsersData.class)
    public void AssignVehicles(String org, String route, String vechileNo) {

        AssignVehiclesPage assignVehiclesPage = new AssignVehiclesPage();
        assignVehiclesPage.NavigateToAssignVehiclesPage();
        assignVehiclesPage.AddVechileDetails(org, route, vechileNo);
    }
}