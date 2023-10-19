using AutomationFramework_HT;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class CloudPageTests
    {
        private IWebDriver _driver;
        private CloudPage _cloudPage;

        [TestInitialize]
        public void TestInitialize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _cloudPage = new CloudPage(_driver);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void SearchPage_ShouldNavigateToGoogleCalculatorPage()
        {
            //Arrange
            string pageToSearchName = "Google Cloud Platform Pricing Calculator";

            //Act
            _cloudPage.Navigate();
            _cloudPage.SearchPage(pageToSearchName);

            //TODO: Do Assert in this class
        }
    }
}