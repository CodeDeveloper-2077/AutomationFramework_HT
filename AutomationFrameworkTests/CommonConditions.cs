using OpenQA.Selenium;
using AutomationFramework_HT.Driver;

namespace AutomationFrameworkTests
{
    public class CommonConditions
    {
        protected IWebDriver driver;
        protected PrintScreenService printScreenService;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = DriverSingleton.GetInstance();
            printScreenService = new PrintScreenService();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverSingleton.CloseBrowser();
        }
    }
}