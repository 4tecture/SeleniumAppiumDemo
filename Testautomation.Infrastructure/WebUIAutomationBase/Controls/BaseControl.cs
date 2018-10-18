using System;
using OpenQA.Selenium;

namespace WebUIAutomationBase.Controls
{
    public abstract class BaseControl
    {
        protected BaseControl(IWebElement webElement, IWebDriver browser)
        {
            if (webElement == null) throw new ArgumentNullException(nameof(webElement));

            this.WebElement = webElement;
            this.Browser = browser;
        }

        protected IWebDriver Browser { get; }

        protected IWebElement WebElement { get; }

        public string GetId()
        {
            return WebElement.GetAttribute("id");
        }

        public string GetValue()
        {
            return WebElement.GetAttribute("value");
        }
    }
}
