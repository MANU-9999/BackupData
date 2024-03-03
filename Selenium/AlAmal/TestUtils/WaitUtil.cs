using AlAmalFunctionalTests.TestSetUp;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestUtils
{
    public class WaitUtil : Base
    {
        public static void WaitForElementTOBeDisplayed(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(element));

        }


        public static void WaitForElementTOBeClickable(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }

        public static void WaitForElementTOBePresent(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(element));
        }

        public static void WaitForLoaderToComplete()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("divLoader")));
        }

        public static void ShortSleep()
        {
            Thread.Sleep(2000);
        }


        public static void Sleep5sec()
        {
            Thread.Sleep(5000);
        }

        public static void Sleep10sec()
        {
            Thread.Sleep(10000);
        }





    }
}

