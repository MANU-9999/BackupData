package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;
import org.testng.Assert;

public class UsersPage extends Base {

    By AdmistritaionMenu = By.id("ancSfaAdministration");
    By UsersLink = By.linkText("Users");

    By AddNew = By.id("cphContent_lnkAddNew");

    By SelectUser = By.xpath("//span[contains(text(),'Select UserType')]");
    By TypeUser = By.xpath("(//input[@placeholder='Enter keywords'])[6]");
    By UserCode = By.cssSelector("input#cphContent_txtUserCode");

    By Role = By.xpath("//span[contains(text(),'Select Role')]");
    By TypeRole = By.xpath("(//input[@placeholder='Enter keywords'])[1]");

    By Email = By.cssSelector("input#cphContent_txtEmail");
    By Name = By.cssSelector("input#cphContent_txtName");
    By MobileNo = By.cssSelector("input#cphContent_txtMobileNo");
    By BillToCustomer = By.cssSelector("input#cphContent_txtBillToCustomer");

    By SelectDepartment = By.xpath("//span[contains(text(),'Select Department')]");
    By TypeDepartment = By.xpath("(//input[@placeholder='Enter keywords'])[5]");

    By SalesOrg = By.xpath("//button[@type='button']//span[contains(text(),'[DFML] Arla KSA')]");
    By TypeOrg = By.xpath("(//input[@placeholder='Enter keywords'])[8]");
    By SelectReportTo = By.xpath("//span[contains(text(),'Select Report To')]");
    By TypeReportTo = By.xpath("(//input[@placeholder='Enter keywords'])[4]");

    By Add = By.cssSelector("img[alt=\"AddImg\"]");
    By SaveAndContinue = By.cssSelector("a#ancDetailsSaveAndContinue");

    By KSAView = By.cssSelector("img#cphContent_rptCountry_imgCountry_0");
    By Save = By.cssSelector("a#cphContent_btnAssignLocSave");

    By SelectRoute = By.xpath("//span[contains(text(),'Select Route')]");
    By TypeRoute = By.xpath("(//input[@placeholder='Enter keywords'])[2]");

    By ok = By.cssSelector("a#cphContent_lnkYesDel");
//	By ErrorMsg = By.cssSelector("span#lblerrmsg");


    public void NavigateToUsers() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(AdmistritaionMenu);
        BrowserActions.Click(UsersLink);
    }

    public void UserDetails(String UserType, String userCode, String name, String RoleType, String billToCustomer, String departmentType, String orgType, String ReportTo) {
        BrowserActions.Click(AddNew);
        WaitUtil.shortSleep();

        BrowserActions.Click(SelectUser); // User Type
        BrowserActions.Type(TypeUser, UserType);
        driver.findElement(By.xpath("//label/span[contains(text(),'" + UserType + "')]")).click();

        BrowserActions.Click(Role); // Role Type
        BrowserActions.Type(TypeRole, RoleType);
        driver.findElement(By.xpath("//label/span[contains(text(),'" + RoleType + "')]")).click();

        BrowserActions.Type(UserCode, userCode); // UserCode Manual
        BrowserActions.Type(Name, name); // UserCode Manual

        BrowserActions.Click(SelectDepartment);        // Department Type
        BrowserActions.Type(TypeDepartment, departmentType);
        driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlDepartment-option-') and span[contains(text(),'" + departmentType + "')]]")).click();

        BrowserActions.Type(BillToCustomer, billToCustomer);
        /*
         * BrowserActions.Click(SelectRoute); // Department Type
         * BrowserActions.Type(TypeRoute, typeRoute);
         * driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlDepartment-option-') and span[contains(text(),'"+ typeRoute + "')]]")).click();
         */

        BrowserActions.Click(SalesOrg);      //Org
        BrowserActions.Type(TypeOrg, orgType);
        driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlSalesOrg-option-') and span[contains(text(),'" + orgType + "')]]")).click();
        WaitUtil.WaitForLoaderToComplete();
        WaitUtil.shortSleep();

        BrowserActions.JSFindAndClick(SelectReportTo); // Report To
        BrowserActions.Type(TypeReportTo, ReportTo);
        WebElement ele = driver.findElement(By.xpath("//label[contains(@for,'ui-multiselect-cphContent_ddlReportTo-option-') and span[contains(text(),'" + ReportTo + "')]]"));
        BrowserActions.WebElementJSFindAndClick(ele);
        BrowserActions.Click(Add); // Report To
        //BrowserActions.ScrollToElement(SaveAndContinue);
        BrowserActions.JSFindAndClick(SaveAndContinue);
        WaitUtil.Sleep();

        WebElement Error = null;
        try {
            Error = driver.findElement(By.cssSelector("span#lblerrmsg"));
            String ErrorText = Error.getText();
            Assert.assertNotEquals(ErrorText, "UserCode already exists.", "UserCode already exists:Use another Unique name ");
        } catch (Exception e) {
        }
    }

    public void AssignLocationsRouteLevel(String Depot, String Route) {
        BrowserActions.Click(KSAView);
        WebElement ele = driver.findElement(By.xpath("//div[div/span[contains(text(),'" + Depot + "')]]"));
        //ele.findElement(By.xpath("//span/input[contains(@id,'cphContent_rptCountry_rptLocation')]")).click();  //check box
        ele.findElement(By.xpath(".//img[@class='Img']")).click();

        WebElement route = driver.findElement(By.xpath("//div[div/span[contains(text(),'" + Route + "')]]"));
        route.findElement(By.xpath(".//span/input[contains(@id,'cphContent_rptCountry_rptLocation')]")).click();

        BrowserActions.ScrollToElement(Save);
        BrowserActions.JSFindAndClick(Save);
        BrowserActions.JSFindAndClick(ok);

    }

}
