using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestUtils
{
    public static class DriverFactory
    {
        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {

                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.LeaveBrowserRunning = true;
                    //new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver(options);
                    break;
                case "firefox":
                    //new DriverManager().SetUpDriver(new FirefoxConfig());
                    return new FirefoxDriver();
                    break;
                case "safari":
                    SafariOptions sOption = new SafariOptions();
                    sOption.AddAdditionalOption("--lang", "de-DE");
                    return new SafariDriver();
                    break;
                default:
                    ChromeOptions options1 = new ChromeOptions();
                    options1.LeaveBrowserRunning = true;
                    //new DriverManager().SetUpDriver(new ChromeConfig());
                    return new ChromeDriver(options1);
                    break;
            }
        }
    }
}
