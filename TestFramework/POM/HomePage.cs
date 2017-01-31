using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace WebSitePOM.POM
{
    public class HomePage
    {
        static string reltativePath = "sut\\home.html";
        private static string PageTitle = "Home Page";

        [FindsBy(How = How.LinkText, Using = "Sign Out")]
        private IWebElement signOutLink;

        public void Goto()
        {
            string convertedUri = Utils.FolderUtils.GetPathAsLocalFileUri(reltativePath);

            Browser.Goto(convertedUri);
        }

        public bool IsAt()
        {
            var timeout = 1;
            bool match = false;
            while (!match && timeout < 5)
            {
                match = Browser.Title == PageTitle;
                Thread.Sleep(200);
                timeout++;
            }
            return match;
        }

        public void SignOut()
        {
            signOutLink.Click();
        }
    }
}