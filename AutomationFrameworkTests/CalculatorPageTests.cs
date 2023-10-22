using OpenQA.Selenium;
using AutomationFramework_HT.Pages;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class CalculatorPageTests : CommonConditions
    {
        private CloudPage _cloudPage;
        private CalculatorPage _calculatorPage;
        private MailPage _mailPage;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _cloudPage = new CloudPage(driver);
            _calculatorPage = new CalculatorPage(driver);
            _mailPage = new MailPage(driver);
        }

        [TestMethod]
        [DataRow("Google Cloud Platform Pricing Calculator", "test_email")]
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
            _calculatorPage.CalculatePrice();
            _calculatorPage.SendPrice($"{email}@yopmail.com");

            //Assert
            Assert.AreEqual(expected, _calculatorPage.GetEstimatedMessage());
        }
    }
}
