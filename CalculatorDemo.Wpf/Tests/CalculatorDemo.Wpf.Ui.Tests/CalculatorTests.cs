using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorDemo.Wpf.Ui.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [TestClass]
    public class CalculatorTests : WpfUITestBase
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

            SaveScreenshot();

            var result = calculationsPanel.GetResultFieldValue();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
