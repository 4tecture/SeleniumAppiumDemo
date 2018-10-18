using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CalculatorDemo.Android.PageObjects.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorDemo.Android.Ui.Tests
{
    public class AndroidUITestBase
    {
        public static CalculatorAppPageObject CurrentApplication { get; private set; }

        [ClassCleanup]
        public static void TeardownTest()
        {
            CloseCurrentApplication();
        }

        private static void CloseCurrentApplication()
        {
            CurrentApplication?.Quit();
            CurrentApplication = null;
        }

        public static CalculatorAppPageObject Launch(Uri appiumServerUrl = null, Dictionary<string, object> customCapabilities = null)
        {

            if (appiumServerUrl == null)
            {
                if (!Uri.TryCreate(TestContext?.Properties["Appium.Server.RemoteAddress"]?.ToString(), UriKind.RelativeOrAbsolute, out appiumServerUrl))
                {
                    throw new ArgumentNullException("Invalid appium server url detected in the test context");
                }
            }

            string capPrefix = "Appium.Cap.";
            var contextCapabilities = TestContext.Properties.Where(p => p.Key.StartsWith(capPrefix, true, CultureInfo.InvariantCulture))
                .ToDictionary(i => i.Key.Substring(capPrefix.Count()), i => i.Value);

            var appiumCapabilities = new Dictionary<string, object>();
            if (customCapabilities != null)
            {
                // merge appium capabilities from context and parameter
                customCapabilities.ToList().ForEach(x => appiumCapabilities.Add(x.Key, x.Value));
            }

            if (contextCapabilities != null)
            {
                // merge appium capabilities from context and parameter
                contextCapabilities.ToList().ForEach(x => appiumCapabilities.Add(x.Key, x.Value));
            }

            if (CurrentApplication != null)
            {
                CloseCurrentApplication();
            }

            CurrentApplication = CalculatorAppPageObject.Launch(appiumServerUrl, appiumCapabilities);

            return CurrentApplication;
        }

        public static TestContext TestContext { get; set; }
    }

}
