using OpenQA.Selenium;
using System;
using UiTestAutomationBase;

namespace CalculatorDemo.Angular.PageObjects
{
    public class CalculationPanelPageObject : WebPageObjectBase
    {
        protected CalculationPanelPageObject(PageObjectBase parent) : base(parent)
        {
        }

        public CalculationPanelPageObject(PageObjectBase parent, ISearchContext searchContext)
            : base(parent, searchContext)
        {
        }

        private IWebElement firstNumberField;
        private IWebElement secondNumberField;
        private IWebElement resultField;
        private IWebElement addButton;
        private IWebElement subtractButton;
        private IWebElement multiplyButton;
        private IWebElement divideButton;
        private IWebElement clearButton;

        

        public IWebElement FirstNumberField
        {
            get
            {
                if (firstNumberField == null)
                {
                    firstNumberField = FindById<IWebElement>("field_1");
                }
                return firstNumberField;
            }
        }

        public IWebElement SecondNumberField
        {
            get
            {
                if (secondNumberField == null)
                {
                    secondNumberField = FindById<IWebElement>("field_2");
                }
                return secondNumberField;
            }
        }

        public IWebElement ResultField
        {
            get
            {
                if (resultField == null)
                {
                    resultField = FindById<IWebElement>("result");
                }
                return resultField;
            }
        }

        public IWebElement AddButton
        {
            get
            {
                if (addButton == null)
                {
                    addButton = FindById<IWebElement>("add");
                }
                return addButton;
            }
        }

        public IWebElement SubtractButton
        {
            get
            {
                if (subtractButton == null)
                {
                    subtractButton = FindById<IWebElement>("subtract");
                }
                return subtractButton;
            }
        }

        public IWebElement MultiplyButton
        {
            get
            {
                if (multiplyButton == null)
                {
                    multiplyButton = FindById<IWebElement>("multiply");
                }
                return multiplyButton;
            }
        }

        public IWebElement DivideButton
        {
            get
            {
                if (divideButton == null)
                {
                    divideButton = FindById<IWebElement>("divide");
                }
                return divideButton;
            }
        }

        public IWebElement ClearButton
        {
            get
            {
                if (clearButton == null)
                {
                    clearButton = FindById<IWebElement>("clear");
                }
                return clearButton;
            }
        }

        public CalculationPanelPageObject EnterFirstNumber(double number)
        {
            this.FirstNumberField.SendKeys(number.ToString());
            return this;
        }

        public CalculationPanelPageObject EnterSecondNumber(double number)
        {
            this.SecondNumberField.SendKeys(number.ToString());
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
