using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace UiTestAutomationBase
{
    public class AppiumWpfPageObjectBase : PageObjectBase
    {
        protected AppiumWpfPageObjectBase(ISearchContext searchContext) : base(searchContext)
        {
        }

        protected AppiumWpfPageObjectBase(PageObjectBase parent) : base(parent)
        {

        }

        protected AppiumWpfPageObjectBase(PageObjectBase parent, ISearchContext searchContext) : base(parent, searchContext)
        {
        }

        public WindowsDriver<WindowsElement> Session { get; private set; }

        public AppiumWpfPageObjectBase Start(string filename, string windowsApplicationDriverUrl = "http://127.0.0.1:4723")
        {

            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", filename);
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            Session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), appCapabilities);
            SearchContext = Session.FindElementByClassName("Window");
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            return this;
        }

        public void Quit()
        {
            Session?.Quit();
            Session?.Dispose();
            Session = null;
        }

        public override TControl FindById<TControl>(string id, bool doWait = true)
        {
            var element = (SearchContext as WindowsElement).FindElementByAccessibilityId(id) as TControl;
            return element;
        }

        public override Screenshot TakeScreenshot()
        {
            return Session.GetScreenshot();
        }
    }
}
