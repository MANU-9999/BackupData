using AlAmalFunctionalTests.TestSetUp;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestUtils
{
    public class BrowserActions : Base
    {
        public static void Type(By field, string value)
        {
            WaitUtil.WaitForElementTOBeClickable(field);
            GetDriver().FindElement(field).SendKeys(value);
        }

        public static void TypeFloatValue(By field, double value)
        {

            WaitUtil.WaitForElementTOBeClickable(field);
            string val = Convert.ToString(value);
            GetDriver().FindElement(field).SendKeys(val);
        }

        public static double GetDoubleValue(By field)
        {
            WaitUtil.WaitForElementTOBeDisplayed(field);
            String Text = GetDriver().FindElement(field).Text;
            //Console.WriteLine(Text);
            double Value = double.Parse(Text);
            Console.WriteLine(Value);
            return Value;
        }



        public static void Click(By field)
        {

            WaitUtil.WaitForElementTOBeClickable(field);
            GetDriver().FindElement(field).Click();
        }

        public static void Select(By field, string value)
        {
            WaitUtil.WaitForElementTOBeClickable(field);
            IWebElement selectelement = GetDriver().FindElement(field);
            SelectElement dropDown = new SelectElement(selectelement);
            dropDown.SelectByText(value);
        }

        public static string GetText(By field)
        {
            WaitUtil.WaitForElementTOBeDisplayed(field);
            string Text = GetDriver().FindElement(field).Text;
            return Text;
        }

        public static float GetAmountExcludingCurrency(By field)
        {
            WaitUtil.WaitForElementTOBeDisplayed(field);
            String Text = GetDriver().FindElement(field).Text;
            String dueamt = Text.Substring(0, Text.Length - 4);
            float Value = float.Parse(dueamt);
            return Value;
        }

        public static float GetValue(By field)
        {
            WaitUtil.WaitForElementTOBeDisplayed(field);
            String Text = GetDriver().FindElement(field).Text;
            String val = Regex.Replace(Text, "[^0-9.]", "");
            Console.WriteLine(val);
            float Value = float.Parse(val, new CultureInfo("en-US"));
            Console.WriteLine(Value);
            return Value;
        }

        public static void Clear(By field)
        {
            WaitUtil.WaitForElementTOBeClickable(field);
            GetDriver().FindElement(field).Clear();
        }

        public static void ScrollUp()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Home).Build().Perform();

        }

        public static void ScrollToElement(By field)
        {
            Actions act = new Actions(driver);
            act.ScrollToElement(driver.FindElement(field)).Build().Perform();
        }

        public static void SelectDate(By field, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement inputField = driver.FindElement(field);
            js.ExecuteScript("arguments[0].value = arguments[1]", inputField, value);
            js.ExecuteScript("arguments[0].dispatchEvent(new KeyboardEvent('keydown', { 'key': 'Tab' }))", inputField);
        }

        public static int GetRowCount(By field)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement table = driver.FindElement(field);
            //IWebElement table = driver.FindElement(By.CssSelector("table[class=table]"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));
            return rows.Count;
        }

        public static string GetDateTime(By field)
        {
            string s = GetDriver().FindElement(field).GetAttribute("title");
            string time = s.Substring(10, 13).Trim();
            return time;
        }

        public static void ClickTab()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Tab).Build().Perform();
        }

        public static void ClickEnter()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.Enter).Build().Perform();
        }

        public static void ScrollDown()
        {
            Actions act = new Actions(driver);
            act.SendKeys(Keys.End).Build().Perform();
        }

        public static IWebElement GetTable(By field)
        {
            return GetDriver().FindElement(field);
        }

        //public static float textboxvalue;
        public static float GetTextByJavaScriptExecutor(By field)
        {
            IWebElement ele = GetDriver().FindElement(field);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string textboxvalue1 = (string)js.ExecuteScript("return arguments[0].value;", ele);

            float textboxvalue = float.Parse(textboxvalue1);
            return textboxvalue;
            //if (float.TryParse(textboxvalue1, out textboxvalue)) ;


            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //string script = "return arguments[0].value;";
            //string textBoxValue = (string)js.ExecuteScript(script, driver.FindElement(field));

        }
        public static string FindingRow(String number)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + number + "' ]]"));
            IWebElement ReceiptNumber = row.FindElement(By.XPath("(//tr/td/span[@title])[1]"));
            string s = ReceiptNumber.GetAttribute("title");
            Console.WriteLine(s);
            return s;
        }

        public static void ImportfileFormat(string filename)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // Define the relative path to your file within the project directory
            string relativeFilePath = "TestData\\TestFiles\\" + filename + ".exe";
            // Combine the base directory and the relative path to get the full file path
            string fullPath = Path.Combine(baseDirectory, relativeFilePath);
            string path = fullPath.Replace("\\bin\\Debug\\net6.0", string.Empty);
            // Directory.SetCurrentDirectory(workingDirectory);
            Process.Start(path);

        }

        public static List<IWebElement> FindElements(By locator)
        {
            IWebDriver driver = GetDriver();
            // Use the provided driver to find elements based on the provided locator
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);

            // Convert the IReadOnlyCollection to a List and return it
            return new List<IWebElement>(elements);
        }


        public static void AlertPopAccept()
        {
            IAlert alert = GetDriver().SwitchTo().Alert();
            alert.Accept();
        }

        public static void Navigate()
        {
            GetDriver().Navigate().GoToUrl("https://dev-arlavansales.winitsoftware.com/pages/Login.aspx");
        }





        public static void IWebElementJSFindAndClick(IWebElement field)
        {
            IWebElement element = (field);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public static void JSFindAndClick(By field)
        {
            IWebElement element = driver.FindElement(field);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }






        public static IWebElement FindingRowIWebElement(String number)
        {
            IWebElement row = driver.FindElement(By.XPath("//tbody/tr[td/span[@title='" + number + "' ]]"));
            //tbody/tr[td/span[@title='" + Invoicenumber + "' ]]

            //IWebElement ReceiptNumber = row.FindElement(By.XPath("(//tr/td/span[@title])[1]"));

            //string s = ReceiptNumber.GetAttribute("title");       
            //Console.WriteLine(s);
            return row;
        }


        public static void JSFindAndSelect(IWebElement field)
        {
            IWebElement element = (field);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }


        public static void Zoomout()
        {
            Actions act = new Actions(driver);

            act.KeyDown(Keys.Control);
            act.SendKeys(Keys.Subtract);
            act.KeyUp(Keys.Control);
            act.Build().Perform();

        }
    }
}
