using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using Protractor;

namespace UiTestAutomationBase
{
    public abstract class BrowserPageObject : WebPageObjectBase
    {
        protected BrowserPageObject(ISearchContext parentSearchContext) : base(parentSearchContext)
        {
        }

        protected override IWebDriver Browser => this.SearchContext as IWebDriver;

        public void Close()
        {
            Browser.Quit();
        }

        protected static IWebDriver LaunchWebDriver(string url, TargetBrowser targetBrowser = TargetBrowser.InternetExplorer, int width = 1024, int height = 768, bool useAngular = false)
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
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new InternetExplorerDriver(ieOptions)) : new InternetExplorerDriver(ieOptions);
                    break;
                case TargetBrowser.Edge:
                    var edgeOptions = new EdgeOptions
                    {
                        PageLoadStrategy = EdgePageLoadStrategy.Eager
                    };
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new EdgeDriver(edgeOptions)) : new EdgeDriver(edgeOptions);
                    break;
                case TargetBrowser.Chrome:
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))) : new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case TargetBrowser.Firefox:
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new FirefoxDriver()) : new FirefoxDriver();
                    break;
                case TargetBrowser.Safari:
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new SafariDriver()) : new SafariDriver();
                    break;
                case TargetBrowser.PhantomJSDriver:
                    browser = useAngular ? (IWebDriver)new NgWebDriver(new PhantomJSDriver()) : new PhantomJSDriver();
                    break;
                default:
                    throw new ArgumentException($"Unknown target browser type {targetBrowser}");
            }

            browser.Manage().Window.Size = new Size(width, height);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);

            browser.Navigate().GoToUrl(url);

            return browser;
        }
    }

}
