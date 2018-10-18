using System;
using System.IO;
using CalculatorDemo.Wpf.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorDemo.Wpf.Ui.Tests
{
    public class WpfUITestBase
    {
        public string File { get; private set; }
        public CalculatorAppPageObject CurrentApplication { get; private set; }

        [TestCleanup]
        public void TeardownTest()
        {
            CloseCurrentApplication();
        }

        private void CloseCurrentApplication()
        {
            CurrentApplication?.Quit();
            CurrentApplication = null;
        }

        public CalculatorAppPageObject Launch(string file = null)
        {
            if (CurrentApplication != null)
            {
                CloseCurrentApplication();
            }

            File = file;
            CurrentApplication = CalculatorAppPageObject.Launch(file);
            return CurrentApplication;
        }

        public void SaveScreenshot(string name = null)
        {
            var screenshot = CurrentApplication.TakeScreenshot();
            if (string.IsNullOrWhiteSpace(name)) name = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss-fff");
            var path = Path.Combine(Path.GetTempPath(), $"{name}.png");
            screenshot.SaveAsFile(path);
            TestContext.AddResultFile(path);
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
