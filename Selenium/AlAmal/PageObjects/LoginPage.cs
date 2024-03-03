using AlAmalFunctionalTests.TestUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.PageObjects
{
    public class LoginPage : BasePage
    {
        By Username = By.Id("txtUsername");
        By Password = By.Id("txtPassword");
        By LoginButton = By.Id("btnLogin");
       // By KSASalesSuperUser = By.Id("chk_KSA Sales Super User_4");
      //  By DoneButton = By.Id("btnNavigate");
      //  By Title = By.XPath("//*[@id='divWrapper']/div/div/div[1]/div/h3");
        By InvalidLoginError = By.XPath("//*[@id='lblErrorMessage']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        //By SurName = By.Name("lastname");

        public void KSASalesSuperUserLogin(string username, string password)
        {
            BrowserActions.Type(Username, username);
            BrowserActions.Type(Password, password);
            BrowserActions.Click(LoginButton);
//            BrowserActions.Click(KSASalesSuperUser);
   //         BrowserActions.Click(DoneButton);
            WaitUtil.WaitForLoaderToComplete();
            //String Header = BrowserActions.GetText(Title);
            //Assert.That(Header, Is.EqualTo("Dashboard"));
            //Assert home page is displayed
        }


        public void InvalidLogin(string username, string pass)
        {
            BrowserActions.Type(Username, username);
            BrowserActions.Type(Password, pass);
            BrowserActions.Click(LoginButton);
            //Assert Error message has occured
            String InvalidLogin = BrowserActions.GetText(InvalidLoginError);
            Assert.That(InvalidLogin, Is.EqualTo("Invalid UserCode."));
        }


        public void Navigate(string url)
        {
            BrowserActions.Navigate();
        }


        public void CashierLogin(string cashieruser, string cashierpassword)
        {
            BrowserActions.Type(Username, cashieruser);
            BrowserActions.Type(Password, cashierpassword);
            BrowserActions.Click(LoginButton);
            WaitUtil.WaitForLoaderToComplete();
        }



    }
}
