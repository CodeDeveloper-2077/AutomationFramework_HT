using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT
{
    public class CalculatorPage : AbstractPage
    {
        private readonly WebDriverWait _wait;

        public CalculatorPage(IWebDriver driver)
            : base(driver)
        {
            url = "https://cloud.google.com/products/calculator";
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTimeoutSeconds));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "input_99")]
        public IWebElement InstancesNumberInput { get; set; }

        public void FillTheForm()
        {
            SwitchToFrames();
        }
    }
}
