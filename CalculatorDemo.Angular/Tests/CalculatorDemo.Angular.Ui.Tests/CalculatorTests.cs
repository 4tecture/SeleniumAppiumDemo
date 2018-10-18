using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace CalculatorDemo.Angular.Ui.Tests
{
    [TestClass]
    public class CalculatorTests : WebUITestBase
    {
        [TestMethod]
        [DataRow(2, 5, 7)]
        [DataRow(22, 58, 80)]
        public void UI_Wpf_AddWithPageObjects(double firstNumber, double secondNumber, double expectedResult)
        {
            // Arrange
            var app = Launch();
            var calculationsPanel = app.NavigateToCalculations();

            // Act 
            calculationsPanel
                .EnterFirstNumber(firstNumber)
                .EnterSecondNumber(secondNumber)
                .PressAdd();

            var result = calculationsPanel.GetResultFieldValue();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [DataRow(2, 5, 7)]
        [DataRow(22, 58, 80)]
        public void UI_Wpf_AddWithSeleniumOnly(double firstNumber, double secondNumber, double expectedResult)
        {
            // Arrange
            var baseUri = new Uri(TestContext?.Properties["baseUrl"].ToString());
            var resolutionWidth = int.Parse(TestContext?.Properties["resolutionWidth"].ToString());
            var resolutionHeight = int.Parse(TestContext?.Properties["resolutionHeight"].ToString());

            var browserOptions = new ChromeOptions()
            {
                LeaveBrowserRunning = false
            };
            var browser = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), browserOptions);
            browser.Manage().Window.Size = new Size(1024, 768);
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            browser.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            browser.Navigate().GoToUrl(baseUri);

            var textInputNum1 = browser.FindElementById("field_1");
            var textInputNum2 = browser.FindElementById("field_2");
            var buttonAdd = browser.FindElementById("add");
            var textResult = browser.FindElementById("result");

            // Act
            textInputNum1.SendKeys(firstNumber.ToString());
            textInputNum2.SendKeys(secondNumber.ToString());
            buttonAdd.Click();
            var result = textResult.Text;

            // Assert
            Assert.IsTrue(double.TryParse(result, out double parsedResult));
            Assert.AreEqual(expectedResult, parsedResult);

            // Clean up
            browser.Quit();
        }
    }
}
