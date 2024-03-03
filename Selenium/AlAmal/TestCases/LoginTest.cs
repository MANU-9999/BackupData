using AlAmalFunctionalTests.PageObjects;
using AlAmalFunctionalTests.TestSetUp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestCases
{
    public class LoginTest : Base
    {
        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(nameof(ValidLoginData))]
        public void VerifyValidLogin(string username, string password)

        {
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            GetDriver().Navigate().GoToUrl("https://alamalicecream-dev.winitsoftware.com/SiteV1/pages/login.aspx");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.KSASalesSuperUserLogin(username, password);
            // Thread.Sleep(10000);
            Console.WriteLine("Valid Login Test Pass");
            test.Info("Valid Login Test Pass");
        }

        //Developed by Ramakrishna G
        [Test]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void VerifyInvalidLogin(string username, string password)
        {
            HomePage homePage = new HomePage(driver);
            homePage.Logout();
            GetDriver().Navigate().GoToUrl("https://alamalicecream-dev.winitsoftware.com/SiteV1/pages/Login.aspx");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InvalidLogin(username, password);
            Thread.Sleep(10000);
            Console.WriteLine("Invalid Login Test Pass");
            test.Info("Invalid Login Test Pass");
        }

        public static IEnumerable<TestCaseData> ValidLoginData()
        {
            yield return new TestCaseData("admin", "Alamal@123");

        }

        public static IEnumerable<TestCaseData> InvalidLoginData()
        {
            yield return new TestCaseData("sdhfsdf", "sdfsdf");

        }

    }
}
