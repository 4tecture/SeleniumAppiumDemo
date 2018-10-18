using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using UiTestAutomationBase;

namespace CalculatorDemo.Wpf.PageObjects
{
    public class CalculationPanelPageObject : AppiumWpfPageObjectBase
    {
        private WindowsElement firstNumberField;
        private WindowsElement secondNumberField;
        private WindowsElement resultField;
        private WindowsElement addButton;
        private WindowsElement subtractButton;
        private WindowsElement multiplyButton;
        private WindowsElement divideButton;

        protected CalculationPanelPageObject(PageObjectBase parent) : base(parent)
        {
        }

        public CalculationPanelPageObject(PageObjectBase parent, ISearchContext searchContext)
            : base(parent, searchContext)
        {
        }

        public WindowsElement FirstNumberField
        {
            get
            {
                if (firstNumberField == null)
                {
                    firstNumberField = FindById<WindowsElement>("SimpleCalculatorTxtFirstNumber");
                }
                return firstNumberField;
            }
        }

        public WindowsElement SecondNumberField
        {
            get
            {
                if (secondNumberField == null)
                {
                    secondNumberField = FindById<WindowsElement>("SimpleCalculatorTxtSecondNumber");
                }
                return secondNumberField;
            }
        }

        public WindowsElement ResultField
        {
            get
            {
                if (resultField == null)
                {
                    resultField = FindById<WindowsElement>("SimpleCalculatorTxtResult");
                }
                return resultField;
            }
        }

        public WindowsElement AddButton
        {
            get
            {
                if (addButton == null)
                {
                    addButton = FindById<WindowsElement>("SimpleCalculatorBtnAdd");
                }
                return addButton;
            }
        }

        public WindowsElement SubtractButton
        {
            get
            {
                if (subtractButton == null)
                {
                    subtractButton = FindById<WindowsElement>("SimpleCalculatorBtnSubtract");
                }
                return subtractButton;
            }
        }

        public WindowsElement MultiplyButton
        {
            get
            {
                if (multiplyButton == null)
                {
                    multiplyButton = FindById<WindowsElement>("SimpleCalculatorBtnMultiply");
                }
                return multiplyButton;
            }
        }

        public WindowsElement DivideButton
        {
            get
            {
                if (divideButton == null)
                {
                    divideButton = FindById<WindowsElement>("SimpleCalculatorBtnDivide");
                }
                return divideButton;
            }
        }

        public CalculationPanelPageObject EnterFirstNumber(double number)
        {
            this.FirstNumberField.SetText(number.ToString());
            return this;
        }

        public CalculationPanelPageObject EnterSecondNumber(double number)
        {
            this.SecondNumberField.SetText(number.ToString());
            return this;
        }

        public double GetResultFieldValue()
        {
            if (double.TryParse(this.ResultField.GetText(), out double res))
            {
                return res;
            }
            else
            {
                return double.MinValue;
            }
        }

        public CalculationPanelPageObject PressAdd()
        {
            this.AddButton.Click();
            return this;
        }

        public CalculationPanelPageObject PressSubtract()
        {
            this.SubtractButton.Click();
            return this;
        }

        public CalculationPanelPageObject PressMultiply()
        {
            this.MultiplyButton.Click();
            return this;
        }

        public CalculationPanelPageObject PressDivide()
        {
            this.DivideButton.Click();
            return this;
        }
    }
}
