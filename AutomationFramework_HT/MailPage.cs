using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationFramework_HT
{
    public class MailPage : AbstractPage
    {
        public MailPage(IWebDriver driver)
            :base(driver)
        {
            url = "https://yopmail.com";
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "necesary")]
        public IWebElement NecessaryCookiesButton { get; set; }

        public void CreateEmail(string email)
        {
            NecessaryCookiesButton.Click();
            EmailInput.SendKeys(email);
            EmailInput.SendKeys(Keys.Enter);
        }
    }
}
