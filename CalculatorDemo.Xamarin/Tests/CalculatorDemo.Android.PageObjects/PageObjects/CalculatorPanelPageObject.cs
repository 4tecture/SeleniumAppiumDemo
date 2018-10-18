using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using UiTestAutomationBase;

namespace CalculatorDemo.Android.PageObjects.PageObjects
{
    public class CalculationPanelPageObject : AndroidPageObjectBase
    {
        private AndroidElement firstNumberField;
        private AndroidElement secondNumberField;
        private AndroidElement resultField;
        private AndroidElement addButton;
        private AndroidElement subtractButton;
        private AndroidElement multiplyButton;
        private AndroidElement divideButton;
        private AndroidElement clearButton;

        protected CalculationPanelPageObject(PageObjectBase parent) : base(parent)
        {
        }

        public CalculationPanelPageObject(PageObjectBase parent, ISearchContext searchContext)
            : base(parent, searchContext)
        {
        }

        public AndroidElement FirstNumberField
        {
            get
            {
                if (firstNumberField == null)
                {
                    firstNumberField = FindById<AndroidElement>("TextInput1");
                }
                return firstNumberField;
            }
        }

        public AndroidElement SecondNumberField
        {
            get
            {
                if (secondNumberField == null)
                {
                    secondNumberField = FindById<AndroidElement>("TextInput2");
                }
                return secondNumberField;
            }
        }

        public AndroidElement ResultField
        {
            get
            {
                if (resultField == null)
                {
                    resultField = FindById<AndroidElement>("TextResult");
                }
                return resultField;
            }
        }

        public AndroidElement AddButton
        {
            get
            {
                if (addButton == null)
                {
                    addButton = FindById<AndroidElement>("ButtonAdd");
                }
                return addButton;
            }
        }

        public AndroidElement SubtractButton
        {
            get
            {
                if (subtractButton == null)
                {
                    subtractButton = FindById<AndroidElement>("ButtonSubtract");
                }
                return subtractButton;
            }
        }

        public AndroidElement MultiplyButton
        {
            get
            {
                if (multiplyButton == null)
                {
                    multiplyButton = FindById<AndroidElement>("ButtonMultiply");
                }
                return multiplyButton;
            }
        }

        public AndroidElement DivideButton
        {
            get
            {
                if (divideButton == null)
                {
                    divideButton = FindById<AndroidElement>("ButtonDivide");
                }
                return divideButton;
            }
        }

        public AndroidElement ClearButton
        {
            get
            {
                if (clearButton == null)
                {
                    clearButton = FindById<AndroidElement>("ButtonClear");
                }
                return clearButton;
            }
        }

        public CalculationPanelPageObject EnterFirstNumber(double number)
        {
            this.FirstNumberField.ReplaceValue(number.ToString());
            return this;
        }

        public CalculationPanelPageObject EnterSecondNumber(double number)
        {
            this.SecondNumberField.ReplaceValue(number.ToString());
            return this;
        }

        public double GetResultFieldValue()
        {
            if (double.TryParse(this.ResultField.Text, out double res))
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
