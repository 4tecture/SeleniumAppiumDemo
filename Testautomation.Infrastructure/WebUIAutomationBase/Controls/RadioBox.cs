using OpenQA.Selenium;
using WebUIAutomationBase.Extensions;

namespace WebUIAutomationBase.Controls
{
    public class RadioBox : BaseControl
    {
        public RadioBox(IWebElement webElement, IWebDriver browser)
            : base(webElement, browser)
        {

        }

        public bool IsSelected()
        {
            return WebElement.Selected;
        }

        public void Select()
        {
            WebElement.ScrollAndClick(Browser);
        }
    }
}
