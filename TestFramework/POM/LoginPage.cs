using OpenQA.Selenium;
using Selenium.Helpers;
using System;
using System.IO;
using WebSitePOM.Utils;

namespace WebSitePOM.POM
{
    public class LoginPage
    {
        static string reltativePath = "sut\\logon.html";

        private static string PageTitle = "IBM TRIRIGA Beta";

        public void Goto()
        {
            string convertedUri = FolderUtils.GetPathAsLocalFileUri(reltativePath);
            Browser.Goto(convertedUri);
        }

        public bool IsAt()
        {
            return Browser.Title == PageTitle;
        }

        public void Login(string userName, string password)
        {
            var userNameEdt = Browser.Driver.FindElementRecursive(By.Id("userNameField"));
            userNameEdt.SendKeys(userName);
            var passwordEdt = Browser.Driver.FindElementRecursive(By.Id("passwordField"));
            passwordEdt.SendKeys(password);

            var submitBtn = Browser.Driver.FindElementRecursive(By.ClassName("loginButton"));
            submitBtn.Click();
        }
    }
}