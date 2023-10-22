using AutomationFramework_HT;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class MailPageTests : CommonConditions
    {
        private CloudPage _cloudPage;
        private MailPage _mailPage;

        [TestInitialize]
        public void TestInitialize()
        {
            base.TestInitialize();
            _cloudPage = new CloudPage(driver);
            _mailPage = new MailPage(driver);
        }

        [TestMethod]
        [DataRow("test_email")]
        public void CreateEmail_ShouldGenerateNewEmailWithPredefinedName(string email)
        {
            //Act
            _mailPage.Navigate();
            _mailPage.CreateEmail(email);
        }
    }
}
