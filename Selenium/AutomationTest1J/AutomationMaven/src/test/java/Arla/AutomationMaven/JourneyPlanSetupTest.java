package Arla.AutomationMaven;

import PageObjects.JourneyPlanSetupPage;
import TestData.JourneyPlanSetupData;
import TestSetUp.Base;
import org.testng.annotations.Test;

import java.util.List;

public class JourneyPlanSetupTest extends Base {

    @Test(dataProvider = "JourneyPlanSetupManual", dataProviderClass = JourneyPlanSetupData.class)
    public void JourneyPlanSetupManual(String journeyPlanName, String description, String startDate, String endDate,
                                       String country, String division, String routeName) {

        JourneyPlanSetupPage journeyPlanSetupPage = new JourneyPlanSetupPage();
        journeyPlanSetupPage.NavigateToJourneyPlanSetup();
        journeyPlanSetupPage.JourneyPlanInfo(journeyPlanName, description, startDate, endDate, country, division);

        List<String> Weeks = List.of("1", "2", "3");
        journeyPlanSetupPage.ScheduleWeekWise(Weeks);
        journeyPlanSetupPage.AssignToRoutes(routeName);

        List<String> WeeksWise = List.of("week1", "week2");
        List<String> DayNames = List.of("Monday", "Tuesday");// ,"Wednesday"
        List<String> CustomerCodes = List.of("96619964", "96619964"); // "96619962","96619958" "C76801" ,"C75741"
        journeyPlanSetupPage.AddCustomers(WeeksWise, DayNames, CustomerCodes);

        journeyPlanSetupPage.Finalize();
    }

}
