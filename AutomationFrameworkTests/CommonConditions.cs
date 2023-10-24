using OpenQA.Selenium;
using AutomationFramework_HT.Driver;
using Microsoft.Extensions.Logging;
using AutomationFramework_HT.Pages;
using NLog.Extensions.Logging;

namespace AutomationFrameworkTests
{
    public class CommonConditions
    {
        protected IWebDriver driver;
        protected ILogger<CalculatorPage> logger;

        [TestInitialize]
        public void TestInitialize()
        {
            logger = LoggerFactory.Create(builder => builder.AddNLog()).CreateLogger<CalculatorPage>();
            driver = DriverSingleton.GetInstance();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DriverSingleton.CloseBrowser();
        }
    }
}