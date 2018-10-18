using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using Protractor;

namespace WebUIAutomationBase.Extensions
{
    public static class WebDriverExtension
    {
        public static void ScrollToElement(this IWebDriver webDriver, IWebElement webElement)
        {
            if (webDriver == null)
            {
                throw new ArgumentNullException(nameof(webDriver));

            }
            if (webElement == null)
            {
                throw new ArgumentNullException(nameof(webElement));
            }

            var jsExecutor = ((NgWebDriver)webDriver).WrappedDriver as IJavaScriptExecutor;

            // Get current scroll position
            var scrollPosition = (long)jsExecutor.ExecuteScript("return window.scrollY;");

            // Get browser and element positioning
            var pointX = webElement.Location.X;
            var pointY = webElement.Location.Y;
            var screenHeight = webDriver.Manage().Window.Size.Height;

            // Calculate required scroll offset
            var scrollOffsetY = scrollPosition < pointY ? pointY - scrollPosition - screenHeight / 2 : -(scrollPosition - pointY + screenHeight / 2);

            // Execute scroll script
            jsExecutor?.ExecuteScript($"window.scrollBy({pointX},{scrollOffsetY})");
        }

        public static string GetBrowserName(this IWebDriver webDriver)
        {
            if (webDriver == null)
            {
                throw new ArgumentNullException(nameof(webDriver));
            }

            if (webDriver is NgWebDriver)
            {
                webDriver = (webDriver as NgWebDriver).WrappedDriver;
            }

            if (!(webDriver is RemoteWebDriver))
            {
                throw new InvalidOperationException("The webdriver is not of type RemoteWebDriver");
            }

            var browserName = (webDriver as RemoteWebDriver).Capabilities.BrowserName;
            return browserName;
        }
    }
}
