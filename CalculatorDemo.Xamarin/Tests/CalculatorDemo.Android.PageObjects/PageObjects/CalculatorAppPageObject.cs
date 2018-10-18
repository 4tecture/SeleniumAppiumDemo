using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using UiTestAutomationBase;

namespace CalculatorDemo.Android.PageObjects.PageObjects
{
    public class CalculatorAppPageObject : AndroidPageObjectBase
    {
        private CalculatorAppPageObject(ISearchContext parentSearchContext)
            : base(parentSearchContext)
        {
        }

        public CalculationPanelPageObject NavigateToCalculations()
        {
            return new CalculationPanelPageObject(this, this.SearchContext);
        }

        public static CalculatorAppPageObject Launch(Uri appiumServerUrl, Dictionary<string, object> appiumCapabilities)
        {
            var app = new CalculatorAppPageObject(null).Start(appiumServerUrl, appiumCapabilities) as CalculatorAppPageObject;
            return app;
        }
    }
}
