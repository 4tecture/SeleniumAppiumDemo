using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using Protractor;
using WebUIAutomationBase.Definitions;

namespace WebUIAutomationBase
{
    public abstract class BrowserPageObject : PageObjectBase
    {
        protected BrowserPageObject(ISearchContext parentSearchContext) : base(parentSearchContext)
        {

        }

        public IWebDriver Browser => this.SearchContext as IWebDriver;

        public void Close()
        {
            Browser.Quit();
        }

        protected static IWebDriver LaunchWebDriver(string url, TargetBrowser targetBrowser = TargetBrowser.InternetExplorer, int width = 1024, int height = 768)
        {
            IWebDriver browser = null;

            switch (targetBrowser)
            {
                case TargetBrowser.InternetExplorer:
                    var ieOptions = new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                        EnsureCleanSession = true
                    };
                    browser = new NgWebDriver(new InternetExplorerDriver(ieOptions));
                    break;
                case TargetBrowser.Edge:
                    var edgeOptions = new EdgeOptions
                    {
                        PageLoadStrategy = EdgePageLoadStrategy.Eager
                    };
                    browser = new NgWebDriver(new EdgeDriver(edgeOptions));
                    break;
                case TargetBrowser.Chrome:
                    browser = new NgWebDriver(new ChromeDriver());
                    break;
                case TargetBrowser.Firefox:
                    browser = new NgWebDriver(new FirefoxDriver());
                    break;
                case TargetBrowser.Safari:
                    browser = new NgWebDriver(new SafariDriver());
                    break;
                default:
                    throw new ArgumentException($"Unknown target browser type {targetBrowser}");
            }

            browser.Manage().Window.Size = new Size(width, height);
            browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            browser.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            browser.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));  // Set script timeouts to 5 secs

            browser.Navigate().GoToUrl(url);

            return browser;
        }
    }
}
