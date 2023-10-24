using OpenQA.Selenium;
using AutomationFramework_HT.Driver;

namespace AutomationFrameworkTests
{
    public class CommonConditions
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = DriverSingleton.GetInstance();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverSingleton.CloseBrowser();
        }
    }
}