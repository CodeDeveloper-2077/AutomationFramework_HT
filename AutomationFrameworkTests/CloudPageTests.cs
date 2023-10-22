using AutomationFramework_HT.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class CloudPageTests : CommonConditions
    {
        private CloudPage _cloudPage;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _cloudPage = new CloudPage(driver);
        }

        [TestMethod]
        public void SearchPage_ShouldNavigateToGoogleCalculatorPage()
        {
            //Arrange
            string expectedHeader = "Google Cloud Pricing Calculator";
            string pageToSearchName = "Google Cloud Platform Pricing Calculator";

            //Act
            _cloudPage.Navigate();
            _cloudPage.SearchPage(pageToSearchName);

            //Assert
            Assert.AreEqual(expectedHeader, _cloudPage.GetFrameHeader(), $"Actual header should be equal to {expectedHeader}");
        }
    }
}