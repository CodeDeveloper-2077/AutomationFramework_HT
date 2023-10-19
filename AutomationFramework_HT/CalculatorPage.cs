using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationFramework_HT
{
    public class CalculatorPage
    {
        private readonly string _url = "https://cloud.google.com/products/calculator";
        private readonly IWebDriver _driver;

        public CalculatorPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
