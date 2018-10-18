using System;
using System.ComponentModel;
using System.Windows.Input;
using SimpleCalculatorWpf.Helper;

namespace SimpleCalculatorWpf.ViewModels
{
    public class CalculationViewModel : INotifyPropertyChanged
    {
        public CalculationViewModel()
        {
            this.AddCommand = new DelegateCommand(Add);
            this.SubtractCommand = new DelegateCommand(Subtract);
            this.MultiplyCommand = new DelegateCommand(Multiply);
            this.DivideCommand = new DelegateCommand(Divide);
        }

        private int firstNumber;

        public int FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; RaisePropetyChanged("FirstNumber"); }
        }

        private int secondNumber;

        public int SecondNumber
        {
            get { return secondNumber; }
            set { secondNumber = value; RaisePropetyChanged("SecondNumber"); }
        }

        private int result;

        public int Result
        {
            get { return result; }
            set { result = value; RaisePropetyChanged("Result"); }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; RaisePropetyChanged("ErrorMessage"); }
        }

        public ICommand AddCommand { get; set; }
        private void Add()
        {
            try
            {
                Result = FirstNumber + SecondNumber;
                ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                ErrorMessage = "Cannot add the given numbers";
            }
        }

        public ICommand SubtractCommand { get; set; }
        private void Subtract()
        {
            try
            {
                Result = FirstNumber - SecondNumber;
                ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                ErrorMessage = "Cannot subtract with the given numbers";
            }
        }

        public ICommand MultiplyCommand { get; set; }
        private void Multiply()
        {
            try
            {
                Result = FirstNumber * SecondNumber;
                ErrorMessage = string.Empty;
            }
            catch (Exception)
            {
                ErrorMessage = "Cannot multiply with the given numbers";
            }
        }

        public ICommand DivideCommand { get; set; }
        private void Divide()
        {
            try
            {
                Result = FirstNumber / SecondNumber;
                ErrorMessage = string.Empty;
            }
            catch (DivideByZeroException)
            {
                ErrorMessage = "Divide by zero not possible!";
            }
            catch (Exception)
            {
                ErrorMessage = "Cannot divide with the given numbers";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropetyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
