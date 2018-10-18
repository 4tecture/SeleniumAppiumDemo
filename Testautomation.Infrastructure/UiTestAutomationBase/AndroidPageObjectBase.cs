using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace UiTestAutomationBase
{
    public class AndroidPageObjectBase : AppiumXamarinPageObjectBase<AndroidDriver<AndroidElement>, AndroidElement>
    {
        protected AndroidPageObjectBase(ISearchContext searchContext) : base(searchContext)
        {
        }

        protected AndroidPageObjectBase(PageObjectBase parent) : base(parent)
        {

        }

        protected AndroidPageObjectBase(PageObjectBase parent, ISearchContext searchContext) : base(parent, searchContext)
        {
        }

        public override TControl FindById<TControl>(string id, bool doWait = true)
        {
            var ae = SearchContext as AndroidElement;
            if (ae != null)
            {
                return ae.FindElementByAccessibilityId(id) as TControl;
            }

            var ad = SearchContext as AndroidDriver<AndroidElement>;
            if (ad != null)
            {
                return ad.FindElementByAccessibilityId(id) as TControl;
            }

            throw new NotImplementedException();
        }

        public override AppiumXamarinPageObjectBase<AndroidDriver<AndroidElement>, AndroidElement> Start(Uri appiumServerUrl, Dictionary<string, object> appiumCapabilities)
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities(appiumCapabilities);

            Session = new AndroidDriver<AndroidElement>(appiumServerUrl, appCapabilities, TimeSpan.FromSeconds(300));
            SearchContext = Session;
            Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            return this;
        }
    }
}
