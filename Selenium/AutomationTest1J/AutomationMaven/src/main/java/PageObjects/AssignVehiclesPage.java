package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;

public class AssignVehiclesPage extends Base {

    By AdmistritaionMenu = By.id("ancSfaAdministration");
    By AssignVehicles = By.linkText("Assign Vehicles");

    By AddNew = By.cssSelector("a#cphContent_lnkAddNew");
    By Org = By.cssSelector("select#cphContent_ddlSalesorg");
    By Route = By.xpath("//span[contains(text(),'Select Route')]");
    By TypeRoute = By.xpath("(//input[@placeholder='Enter keywords'])[1]");
    By TypeVechile = By.xpath("(//input[@placeholder='Enter keywords'])[3]");

    By Vechile = By.xpath("//button/span[contains(text(),'Select Vehicle')]");
    By Save = By.cssSelector("input#cphContent_btnSave");

    public void NavigateToAssignVehiclesPage() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(AdmistritaionMenu);
        BrowserActions.Click(AssignVehicles);
        WaitUtil.shortSleep();

    }

    public void AddVechileDetails(String org, String route, String vechileNo) {

        BrowserActions.Click(AddNew);
        WaitUtil.shortSleep();
        BrowserActions.Select(Org, org);
        WaitUtil.shortSleep();

        BrowserActions.Click(Route); // Route
        BrowserActions.Type(TypeRoute, route);
        try {
            driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlRoute-option') and span[contains(text(),'" + route + "')]]")).click();
            WaitUtil.Sleep();
        } catch (NoSuchElementException e) {
            System.out.println(route + " : is not avialble");
        }
        WaitUtil.shortSleep();
        BrowserActions.Click(Vechile); // Route
        BrowserActions.Type(TypeVechile, vechileNo);
        try {
            driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlVehicleNo-option') and span[contains(text(),'" + vechileNo + "')]]")).click();
            WaitUtil.Sleep();
        } catch (NoSuchElementException e) {
            System.out.println(vechileNo + " : is not avialble");
        }

        BrowserActions.Click(Save);
        WaitUtil.shortSleep();
    }

}
