using System.Collections.Generic;
using OpenQA.Selenium;
using System.Diagnostics;

namespace Selenium.Helpers
{
    public class RecursiveLocatorHelper
    {
        private int depth = 0;

        public IWebElement FindElementRecursive(IWebDriver webDriver, By searchCriteria)
        {
            depth++;
            IWebElement element = null;
            bool found = false;

            try
            {
                element = webDriver.FindElement(searchCriteria);
            }
            catch (NoSuchElementException ex)
            {
                Trace.WriteLine("   Element not found in ctx: " + ex.Message);
            }

            if (null == element)
            {
                var iframes = webDriver.FindElements(By.CssSelector("iframe"));
                var framesetframes = webDriver.FindElements(By.CssSelector("frame"));
                var frames = new List<IWebElement>();
                frames.AddRange(iframes);
                frames.AddRange(framesetframes);

                if (frames.Count == 0)
                {
                    webDriver.SwitchTo().ParentFrame();
                    return element;
                }

                foreach (var frame in frames)
                {
                    if (element == null)
                    {
                        webDriver.SwitchTo().Frame(frame);
                        element = FindElementRecursive(webDriver, searchCriteria);
                    }
                }
                if (null == element)
                {
                    // Finished lookig in the current frame, so go back to the parent.
                    webDriver.SwitchTo().ParentFrame();
                }

                found = null != element;
            }

            depth--;

            if (0 == depth && null == element)
            {
                // We have looked in all children, and cant find it, so raise the standard exception
                throw new NoSuchElementException();
            }

            return element;
        }
    }
}
