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
        protected readonly WebDriverWait wait;

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WaitTimeoutSeconds));
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        protected void SwitchToFrames()
        {
            var firstFrameElement = wait.Until(ExpectedConditions.ElementExists(_firstFrameLocator));
            driver.SwitchTo().Frame(firstFrameElement);

            var secondFrameElement = wait.Until(ExpectedConditions.ElementExists(_secondFrameLocator));
            driver.SwitchTo().Frame(secondFrameElement);
        }
    }
}
