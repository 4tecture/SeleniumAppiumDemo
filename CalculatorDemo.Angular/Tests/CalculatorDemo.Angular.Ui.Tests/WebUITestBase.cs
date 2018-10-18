using System;
using CalculatorDemo.Angular.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UiTestAutomationBase;

namespace CalculatorDemo.Angular.Ui.Tests
{
    public class WebUITestBase
    {
        public string BaseUrl { get; private set; }
        public CalculatorAppPageObject CurrentApplication { get; private set; }

        [TestCleanup]
        public void TeardownTest()
        {
            CloseCurrentApplication();
        }

        private void CloseCurrentApplication()
        {
            this.CurrentApplication?.Close();
            this.CurrentApplication = null;
        }

        public CalculatorAppPageObject Launch(string url = null, TargetBrowser targetBrowser = TargetBrowser.Undefined, int width = 0, int height = 0)
        {
            if (url == null)
            {
                url = TestContext?.Properties["baseUrl"]?.ToString();
                if (url == null)
                {
                    throw new ArgumentNullException("Invalid base url parameter detected in the test context");
                }
            }

            if (targetBrowser == TargetBrowser.Undefined)
            {
                if (!Enum.TryParse(TestContext?.Properties["targetBrowser"]?.ToString(), true, out targetBrowser))
                {
                    throw new ArgumentNullException("Invalid target browser parameter detected in the test context");
                }
            }

            if (width <= 0 || height <= 0)
            {
                if (!int.TryParse(TestContext?.Properties["resolutionWidth"].ToString(), out width))
                {
                    throw new ArgumentNullException("Invalid resolution width parameter detected in the test context");
                }

                if (!int.TryParse(TestContext?.Properties["resolutionHeight"].ToString(), out height))
                {
                    throw new ArgumentNullException("Invalid resolution height parameter detected in the test context");
                }
            }

            if (CurrentApplication != null)
            {
                CloseCurrentApplication();
            }

            this.BaseUrl = url;
            this.CurrentApplication = CalculatorAppPageObject.Launch(url, targetBrowser, width, height);
            return CurrentApplication;
        }

        public void SaveScreenshot(string name = null)
        {
            throw new NotImplementedException("Currently not supported for .NET Core");
            //https://github.com/Microsoft/testfx/issues/394
        }

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

    }

}
