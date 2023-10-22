using AutomationFramework_HT;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class MailPageTests : CommonConditions
    {
        private MailPage _mailPage;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _mailPage = new MailPage(driver);
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
