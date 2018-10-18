using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using UiTestAutomationBase;

namespace CalculatorDemo.Angular.PageObjects
{
    public class CalculatorAppPageObject : BrowserPageObject
    {
        protected Uri BaseUri { get; private set; }
        protected new IWebDriver Browser { get; private set; }

        public CalculatorAppPageObject(ISearchContext parentSearchContext) : base(parentSearchContext)
        {
        }

        public CalculationPanelPageObject NavigateToCalculations()
        {
            return new CalculationPanelPageObject(this, this.SearchContext);
        }

        public static CalculatorAppPageObject Launch(string url, TargetBrowser targetBrowser = TargetBrowser.InternetExplorer, int width = 1024, int height = 768)
        {
            var browser = LaunchWebDriver(url, targetBrowser, width, height);
            var app = new CalculatorAppPageObject(browser)
            {
                BaseUri = new Uri(url),
                Browser = browser
            };
            return app;
        }

    }
}
