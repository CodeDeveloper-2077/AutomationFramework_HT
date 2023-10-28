using AutomationFramework_HT.Pages;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class MailPageTests : CommonConditions
    {
        private MailPage _mailPage;
        private ILogger<MailPage> _logger;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _logger = LoggerFactory.Create(builder => builder.AddNLog())
                                   .CreateLogger<MailPage>();
            _logger.LogInformation("MailPageLogger has been created");

            _mailPage = new MailPage(driver, _logger, printScreenService);
        }

        [TestMethod]
        [DataRow("test_email")]
        public void CreateEmail_ShouldGenerateNewEmailWithPredefinedName(string email)
        {
            //Arrange
            string expectedEmail = "test_email@yopmail.com";

            //Act
            _mailPage.Navigate();
            _mailPage.CreateEmail(email);

            //Assert
            Assert.AreEqual(expectedEmail, _mailPage.GetFullEmail(), $"Actual email should be equal to {expectedEmail}");
        }
    }
}
