using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace UiTestAutomationBase
{
    public abstract class AppiumXamarinPageObjectBase<TDriver, TElement> : PageObjectBase
        where TDriver : AppiumDriver<TElement>
        where TElement : AppiumWebElement
    {
        public AppiumXamarinPageObjectBase(ISearchContext searchContext) : base(searchContext)
        {
        }

        public AppiumXamarinPageObjectBase(PageObjectBase parent) : base(parent)
        {

        }

        public AppiumXamarinPageObjectBase(PageObjectBase parent, ISearchContext searchContext) : base(parent, searchContext)
        {
        }

        public TDriver Session { get; protected set; }

        public abstract AppiumXamarinPageObjectBase<TDriver, TElement> Start(Uri appiumServerUrl, Dictionary<string, object> appiumCapabilities);

        public void Quit()
        {
            Session?.Quit();
            Session?.Dispose();
            Session = null;
        }

        public override Screenshot TakeScreenshot()
        {
            return Session.GetScreenshot();
        }
    }
}
