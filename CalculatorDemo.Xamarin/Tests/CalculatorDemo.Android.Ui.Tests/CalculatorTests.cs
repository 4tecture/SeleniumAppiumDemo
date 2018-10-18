using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorDemo.Android.Ui.Tests
{
    [TestClass]
    public class CalculatorTests : AndroidUITestBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            TestContext = context;
            Launch();
        }

        [TestMethod]
        [DataRow(2, 5, 7)]
        [DataRow(22, 58, 80)]
        public void UI_Android_AddWithPageObjects(double firstNumber, double secondNumber, double expectedResult)
        {
            // Arrange
            // from inline data as parameters

            // Act 
            var calculationsPanel = CurrentApplication.NavigateToCalculations();

            calculationsPanel
                .EnterFirstNumber(firstNumber)
                .EnterSecondNumber(secondNumber)
                .PressAdd();

            var result = calculationsPanel.GetResultFieldValue();

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
