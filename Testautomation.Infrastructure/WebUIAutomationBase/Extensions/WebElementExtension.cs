using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Extensions;
using Protractor;

namespace WebUIAutomationBase.Extensions
{
    public static class WebElementExtension
    {
        public static void SendKeys(this IWebElement webElement, string text, IWebDriver webDriver, bool clear = false)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException(nameof(webElement));

            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (clear)
            {
                webElement.Clear();
            }

            if (webDriver != null && webDriver.GetBrowserName().Equals("MicrosoftEdge", StringComparison.OrdinalIgnoreCase))
            {
                // Workaround for Edge WebDriver that has an issue when sending special characters inside a text.
                IJavaScriptExecutor js = ((NgWebDriver)webDriver).WrappedDriver as IJavaScriptExecutor;
                var script = "arguments[0].setAttribute('value', arguments[1]);";
                js.ExecuteScript(script, webElement, text);
            }
            else
            {
                webElement.SendKeys(text);
            }
        }

        public static void ScrollAndClick(this IWebElement webElement, IWebDriver browser)
        {
            if (webElement == null)
            {
                throw new ArgumentNullException(nameof(webElement));

            }
            if (browser == null)
            {
                throw new ArgumentNullException(nameof(browser));
            }

            browser.ScrollToElement(webElement);
            webElement.Click();
        }
    }
}
