package PageObjects;

import TestSetUp.Base;
import TestUtils.BrowserActions;
import TestUtils.WaitUtil;
import org.openqa.selenium.By;
import org.openqa.selenium.NoSuchElementException;
import org.openqa.selenium.WebElement;
import org.testng.Assert;

import java.util.List;

public class JourneyPlanSetupPage extends Base {

    By AdmistritaionMenu = By.id("ancSfaAdministration");
    By UsersLink = By.linkText("Journey Plan Setup");

    By AddNew = By.cssSelector("a#cphContent_ancImportsku");

    By JourneyPlanName = By.cssSelector("input#cphContent_txtJPName");
    By Description = By.cssSelector("textarea#cphContent_txtJPDesc");
    By StartDate = By.id("cphContent_txtStartDate");
    By EndDate = By.id("cphContent_txtEndDate");
    By Country = By.cssSelector("select#cphContent_ddlCountry");
    By Division = By.cssSelector("select#cphContent_ddlSalesOrgCode");
    By Continue = By.cssSelector("input#btnContinue1");

    By WeekWise = By.cssSelector("input#rdDayWise");
    By DayWise = By.cssSelector("input#rdDateWise");
    By NoOfWorkingDays = By.cssSelector("input#txtNoofWorkingDays");
    By Continue2 = By.cssSelector("input#btnContinue2");

    By SelectRoute = By.xpath("//input[@placeholder='Select Route']");
    By CancelRoute = By.cssSelector("button.alertable-cancel");
    By OkRoute = By.cssSelector("button.alertable-ok");
    By Continue3 = By.cssSelector("input#btnContinue3");

    By AddCustomers = By.xpath("(//span/a[contains(text(),'Add')])[2]");
    By DonePopUp = By.cssSelector("img#btnAddCustomers");

    By FinalizeButton = By.cssSelector("input#cphContent_btnContinue5");


    public void NavigateToJourneyPlanSetup() {
        WaitUtil.WaitForLoaderToComplete();
        BrowserActions.Click(AdmistritaionMenu);
        BrowserActions.Click(UsersLink);
    }

    public void JourneyPlanInfo(String journeyPlanName, String description, String startDate, String endDate,
                                String country, String division) {
        BrowserActions.Click(AddNew);
        WaitUtil.shortSleep();
        BrowserActions.Type(JourneyPlanName, journeyPlanName);
        BrowserActions.Type(Description, description);
        BrowserActions.SelectDate(StartDate, startDate);
        BrowserActions.SelectDate(EndDate, endDate);
        BrowserActions.Select(Country, country);
        BrowserActions.Select(Division, division);
        BrowserActions.JSFindAndClick(Continue);
        WaitUtil.shortSleep();
    }

    public void ScheduleWeekWise(List<String> Weeks) {
        BrowserActions.Click(WeekWise);

        for (String week : Weeks) {
            driver.findElement(By.xpath("//input[contains(@id,'chkWeek') and @data-displayval='" + week + "']")).click();
        }
        BrowserActions.JSFindAndClick(Continue2);

    }

    public void ScheduleDayWise(String days) {
        BrowserActions.Click(WeekWise);
        WebElement Days = driver.findElement(By.xpath("input#txtNoofWorkingDays"));
        Days.clear();
        Days.sendKeys(days);
        BrowserActions.JSFindAndClick(Continue2);
        WaitUtil.shortSleep();

    }

    public void AssignToRoutes(String routeName) {
        WaitUtil.Sleep();
        BrowserActions.Type(SelectRoute, routeName);
        WaitUtil.Sleep();
        WebElement ele = null;
        try {
            ele = driver.findElement(By.xpath("//input[contains(@value,'" + routeName + "')]"));
            ele.click();
            WaitUtil.WaitForLoaderToComplete();
            BrowserActions.JSFindAndClick(OkRoute);
            BrowserActions.JSFindAndClick(Continue3);
        } catch (Exception e) {
        }
        Assert.assertNotNull(ele, "Route not found");
    }

    public void AddCustomers(List<String> WeeksWise, List<String> DayNames, List<String> CustomerCodes) {

        for (String WeekWise : WeeksWise) {
            WeekWiseMethod(WeekWise);

            for (String DayName : DayNames) {
                DayWiseMethod(DayName);
                BrowserActions.JSFindAndClick(AddCustomers);
                WaitUtil.shortSleep();

                for (String customerCode : CustomerCodes) {
                    WebElement ele = driver.findElement(By.id("txtSiteId"));
                    ele.sendKeys(customerCode);
                    WaitUtil.Sleep();
                    driver.findElement(By.id("btnSeachSubChannel")).click();
                    WaitUtil.shortSleep();

                    try {
                        driver.findElement(By.xpath(".//table//tr[td[span[text()='[" + customerCode + "]']]]")).click();
                        WaitUtil.Sleep();
                        driver.findElement(By.xpath("//*[@id='divMoveIcon']/a/img")).click();
                    } catch (NoSuchElementException e) {
                        System.out.println("Customer: " + customerCode + " is not available");
                    }
                    ele.clear();
                }
                WaitUtil.Sleep();
                BrowserActions.JSFindAndClick(DonePopUp);
                WaitUtil.Sleep();
            }
            WaitUtil.shortSleep();
        }
        driver.findElement(By.id("btnContinue4")).click();
    }

    public void WeekWiseMethod(String WeekWise) {
        String Week = WeekWise;
        switch (Week) {
            case "week1":
                WebElement ele = driver.findElement(By.xpath("//a[text()='Week 1 [1-7]']"));
                JSScrollAndClick(ele);
                break;
            case "week2":
                WebElement ele2 = driver.findElement(By.xpath("//a[text()='Week 2 [8-14]']"));
                JSScrollAndClick(ele2);
                break;
            case "week3":
                WebElement ele3 = driver.findElement(By.xpath("//a[text()='Week 3 [15-28]']"));
                JSScrollAndClick(ele3);
                break;
        }
    }

    public void DayWiseMethod(String DayName) {
        String Day = DayName;
        switch (Day) {
            case "Monday":
                WebElement ele = driver.findElement(By.xpath("//li/a[contains(text(),'Monday')]"));
                JSScrollAndClick(ele);
                break;
            case "Tuesday":
                WebElement ele2 = driver.findElement(By.xpath("//li/a[contains(text(),'Tuesday')]"));
                JSScrollAndClick(ele2);
                break;
            case "Wednesday":
                WebElement ele3 = driver.findElement(By.xpath("//li/a[contains(text(),'Wednesday')]"));
                JSScrollAndClick(ele3);
                break;
            case "Thursday":
                WebElement ele4 = driver.findElement(By.xpath("//li/a[contains(text(),'Thursday')]"));
                JSScrollAndClick(ele4);
                break;
            case "Friday":
                WebElement ele5 = driver.findElement(By.xpath("//li/a[contains(text(),'Friday')]"));
                JSScrollAndClick(ele5);
                break;
            case "Saturday":
                WebElement ele6 = driver.findElement(By.xpath("//li/a[contains(text(),'Saturday')]"));
                JSScrollAndClick(ele6);
                break;
            case "Sunday":
                WebElement ele7 = driver.findElement(By.xpath("//li/a[contains(text(),'Sunday')]"));
                JSScrollAndClick(ele7);
                break;
        }
    }

    public void JSScrollAndClick(WebElement filed) {
        BrowserActions.JSScrollToWebElement(filed);
        BrowserActions.WebElementJSFindAndClick(filed);

    }

    public void Finalize() {
        BrowserActions.Click(FinalizeButton);
    }

}
