using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Configuration;
using NUnit.Framework.Interfaces;
using ArlaFunctionalTests.TestUtils;
using ArlaFunctionalTests.PageObjects;
using RazorEngine.Compilation.ImpromptuInterface;
using NUnit.Framework;

namespace ArlaFunctionalTests.TestSetup
{
    public class Base
    {
        public static IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void TestSuiteSetup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            //Get path of Base.cs
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "/index.html";

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportPath);


            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "WINITAutomation");

        }

        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string browser = ConfigurationManager.AppSettings["browser"];
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            driver = DriverFactory.InitBrowser(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(100);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60);
            driver.Url = ConfigurationManager.AppSettings["testURL"];
            LoginPage loginPage = new LoginPage(driver);
            loginPage.KSASalesSuperUserLogin(username, password);


        }

        [TearDown]

        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                test.Fail("Test Case Failed");
            }
            else if (status == TestStatus.Passed)
            {
                test.Pass("Test Case Passed");
            }
            else if (status == TestStatus.Skipped)
            {
                test.Pass("Test Case Skipped");
            }


            if (driver != null)
            {
                driver.Quit();
            }

        }

        [OneTimeTearDown]
        public void TestSuiteTearDown()
        {
            extent.Flush();
        }




        public static IWebDriver GetDriver()
        {
            return driver;
        }


    }
}
