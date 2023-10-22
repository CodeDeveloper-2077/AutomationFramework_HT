using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT.Pages
{
    public class CloudPage : AbstractPage
    {
        private readonly By _frameHeaderLocator = By.ClassName("ng-binding");

        public CloudPage(IWebDriver driver)
            : base(driver)
        {
            url = "https://cloud.google.com";
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='gs-title']")]
        public IWebElement CalculatorPageLink { get; set; }

        public void SearchPage(string pageToSearch)
        {
            SearchInput.Click();
            SearchInput.SendKeys(pageToSearch);
            SearchInput.SendKeys(Keys.Enter);
            CalculatorPageLink.Click();
        }

        public string GetFrameHeader()
        {
            SwitchToFrames();

            var frameHeader = wait.Until(ExpectedConditions.ElementExists(_frameHeaderLocator));
            return frameHeader.Text;
        }
    }
}