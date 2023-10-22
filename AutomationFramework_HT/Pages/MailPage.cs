using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT.Pages
{
    public class MailPage : AbstractPage
    {
        private readonly By _emailLocator = By.ClassName("bname");

        public MailPage(IWebDriver driver)
            : base(driver)
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

        public string GetFullEmail()
        {
            var emailElement = wait.Until(ExpectedConditions.ElementExists(_emailLocator));
            return emailElement.Text;
        }
    }
}
