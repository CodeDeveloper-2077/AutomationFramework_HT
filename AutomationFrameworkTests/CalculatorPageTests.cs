using OpenQA.Selenium;
using AutomationFramework_HT.Pages;
using AutomationFramework_HT.Service;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class CalculatorPageTests : CommonConditions
    {
        private CloudPage _cloudPage;
        private CalculatorPage _calculatorPage;
        private MailPage _mailPage;
        private ILogger<CalculatorPage> _calculatorPageLogger;
        private ILogger<MailPage> _mailPageLogger;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _calculatorPageLogger = LoggerFactory.Create(builder => builder.AddNLog())
                                                 .CreateLogger<CalculatorPage>();
            _calculatorPageLogger.LogInformation("CalculatorPageLogger has been created");

            _mailPageLogger = LoggerFactory.Create(builder => builder.AddNLog())
                                           .CreateLogger<MailPage>();
            _mailPageLogger.LogInformation("MailPageLogger has been created");

            _cloudPage = new CloudPage(driver);
            _calculatorPage = new CalculatorPage(driver, _calculatorPageLogger, printScreenService);
            _mailPage = new MailPage(driver, _mailPageLogger, printScreenService);
        }

        [TestMethod]
        [DataRow("Google Cloud Platform Pricing Calculator", "test_email")]
        [TestCategory("Smoke")]
        public void CalculatePrice_ShouldFillTheCalculationFormAndShareTheCorrectResult(string page, string email)
        {
            //Arrange
            string expected = "Total Estimated Cost: USD 1,081.20 per 1 month";

            //Act
            _mailPage.Navigate();
            _mailPage.CreateEmail(email);
            driver.SwitchTo().NewWindow(WindowType.Tab);

            _cloudPage.Navigate();
            _cloudPage.SearchPage(page);
            _calculatorPage.CalculatePrice(ResourceCreator.CreateResources());
            _calculatorPage.SendPrice($"{email}@yopmail.com");

            //Assert
            Assert.AreEqual(expected, _calculatorPage.GetEstimatedMessage());
        }
    }
}
