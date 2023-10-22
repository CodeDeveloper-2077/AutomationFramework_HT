using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Microsoft.Extensions.Configuration;

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
                var configBuilder = new ConfigurationBuilder()
                                                            .AddJsonFile("Appsettings.json")
                                                            .Build();

                var configSection = configBuilder.GetSection("Appsettings");
                switch (configSection["browser"])
                {
                    case "firefox":
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            _driver = new FirefoxDriver();
                            break;
                        }
                    default:
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            _driver = new ChromeDriver();
                            break;
                        }
                }

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