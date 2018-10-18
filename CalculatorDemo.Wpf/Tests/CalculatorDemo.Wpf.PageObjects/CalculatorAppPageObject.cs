using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using UiTestAutomationBase;

namespace CalculatorDemo.Wpf.PageObjects
{
    public class CalculatorAppPageObject : AppiumWpfPageObjectBase
    {
        public CalculatorAppPageObject(ISearchContext parentSearchContext)
            : base(parentSearchContext)
        {
        }

        public CalculationPanelPageObject NavigateToCalculations()
        {
            return new CalculationPanelPageObject(this, this.SearchContext);
        }

        public static CalculatorAppPageObject Launch(string file = null)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                var location = Assembly.GetExecutingAssembly().Location;
                var basePath = Directory.GetParent(location).Parent.Parent.Parent.Parent.FullName;

                file = Path.Combine(basePath + @"\CalculatorDemo.Wpf.App\bin\Debug\SimpleCalculatorWpf.exe");
            }

            var app = new CalculatorAppPageObject(null).Start(file, "http://127.0.0.1:4723/wd/hub") as CalculatorAppPageObject;
            return app;
        }
    }
}
