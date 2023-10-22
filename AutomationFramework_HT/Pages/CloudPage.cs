using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT.Pages
{
    public class CloudPage : AbstractPage
    {
        private readonly By _frameHeaderLocator = By.ClassName("ng-binding");
        private readonly By _calculatorPageLinkLocator = By.XPath("//a[@class='gs-title']");

        public CloudPage(IWebDriver driver)
            : base(driver)
        {
            url = "https://cloud.google.com";
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        public IWebElement SearchInput { get; set; }

        public void SearchPage(string pageToSearch)
        {
            SearchInput.Click();
            SearchInput.SendKeys(pageToSearch);
            SearchInput.SendKeys(Keys.Enter);

            var calculatorPageLink = wait.Until(ExpectedConditions.ElementIsVisible(_calculatorPageLinkLocator));
            calculatorPageLink.Click();
        }

        public string GetFrameHeader()
        {
            SwitchToFrames();

            var frameHeader = wait.Until(ExpectedConditions.ElementExists(_frameHeaderLocator));
            return frameHeader.Text;
        }
    }
}