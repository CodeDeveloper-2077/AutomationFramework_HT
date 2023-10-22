using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace AutomationFramework_HT.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver _driver;

        private DriverSingleton() { }

        public static IWebDriver GetInstance()
        {
            if (_driver == null)
            {
                _driver = new ChromeDriver();
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }

        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
