using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT.Pages
{
    public class MailPage : AbstractPage
    {
        private readonly By _emailLocator = By.ClassName("bname");
        private readonly ILogger<MailPage> _logger;
        private readonly PrintScreenService _printScreenService;

        public MailPage(IWebDriver driver, ILogger<MailPage> logger, PrintScreenService printScreenService)
            : base(driver)
        {
            _logger = logger;
            _printScreenService = printScreenService;
            url = "https://yopmail.com";
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "login")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "necesary")]
        public IWebElement NecessaryCookiesButton { get; set; }

        public void CreateEmail(string email)
        {
            try
            {
                NecessaryCookiesButton.Click();
            }
            catch (NoSuchElementException ex)
            {
                _logger.LogError(ex, "No Terms Alert");
                _printScreenService.CaptureScreenToFile("screen.png", System.Drawing.Imaging.ImageFormat.Png);
            }

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
