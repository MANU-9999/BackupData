package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;

public class VehicleMasterPage extends Base {

    By AdmistritaionMenu = By.id("ancSfaAdministration");
    By VechileMaster = By.linkText("Vehicle Master");

    By AddNew = By.cssSelector("a#cphContent_lnkAddNew");
    By VehicleCode = By.cssSelector("input#cphContent_txtVehicleCode");
    By VehicleNo = By.cssSelector("input#cphContent_txtVehicleNo");
    By Asset = By.cssSelector("input#cphContent_txtAsset");
    By EQPNo = By.cssSelector("input#cphContent_txtEQP");
    By Org = By.cssSelector("select#cphContent_ddlSalesOrg");
    By VehicleType = By.cssSelector("select#cphContent_ddlVehicleType");

    By Save = By.id("cphContent_btnSave");

    public void NavigateToVechileMasterPage() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(AdmistritaionMenu);
        BrowserActions.Click(VechileMaster);
        WaitUtil.shortSleep();

    }

    public void AddDetails(String vehicleCode, String vehicleNo, String org) {

        BrowserActions.Click(AddNew);
        WaitUtil.shortSleep();
        BrowserActions.Type(VehicleCode, vehicleCode);
        BrowserActions.Type(VehicleNo, vehicleNo);
        BrowserActions.Select(Org, org);
        BrowserActions.Click(Save);
        WaitUtil.shortSleep();
    }

}
