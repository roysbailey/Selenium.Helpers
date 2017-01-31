using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace WebSitePOM
{
    public static class Browser
    {
        static Browser()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            webDriver = new ChromeDriver(@"C:\Users\RoyBailey\AppData\Roaming\nvm\v6.7.0", options);
        }

        //static IWebDriver webDriver = new FirefoxDriver();
        static IWebDriver webDriver;

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }
        public static IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;           
        }

        public static void Close()
        {
            webDriver.Close();
        }
    }
}