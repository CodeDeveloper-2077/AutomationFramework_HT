using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationFramework_HT
{
    public class CloudPage
    {
        private readonly string _url = "https://cloud.google.com";
        private readonly IWebDriver _driver;

        public CloudPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='gs-title']")]
        public IWebElement CalculatorPageLink { get; set; }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void SearchPage(string pageToSearch)
        {
            SearchInput.Click();
            SearchInput.SendKeys(pageToSearch);
            SearchInput.SendKeys(Keys.Enter);
            CalculatorPageLink.Click();
        }
    }
}