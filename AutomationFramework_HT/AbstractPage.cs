using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT
{
    public abstract class AbstractPage
    {
        protected const int WaitTimeoutSeconds = 10;
        protected readonly By _firstFrameLocator = By.XPath("//*[starts-with(@name, 'goog_')]");
        protected readonly By _secondFrameLocator = By.Id("myFrame");

        protected string url;
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait _wait;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTimeoutSeconds));
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void SwitchToFrames()
        {
            var firstFrameElement = _wait.Until(ExpectedConditions.ElementExists(_firstFrameLocator));
            driver.SwitchTo().Frame(firstFrameElement);

            var secondFrameElement = _wait.Until(ExpectedConditions.ElementExists(_secondFrameLocator));
            driver.SwitchTo().Frame(secondFrameElement);
        }
    }
}
