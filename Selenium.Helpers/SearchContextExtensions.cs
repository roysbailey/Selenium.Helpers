using OpenQA.Selenium;

namespace Selenium.Helpers
{
    public static class SearchContextExtensions
    {
        public static IWebElement FindElementRecursive(this ISearchContext searchCtx, By searchCriteria)
        {
            var webDriver = searchCtx as IWebDriver;
            webDriver.SwitchTo().DefaultContent();

            var locator = new RecursiveLocatorHelper();
            var element = locator.FindElementRecursive(webDriver, searchCriteria);
            return element;
        }
    }
}
