using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFrameworkTests
{
    public class CommonConditions
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void  TestCleanup()
        {
            driver.Quit();
        }
    }
}
