﻿using AutomationFramework_HT.Model;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework_HT.Pages
{
    public class CalculatorPage : AbstractPage
    {
        private readonly By _estimateButtonLocator = By.XPath("//*[@id='mainForm']//div[20]//button");
        private readonly By _estimatedMessageLocator = By.XPath("(//b[@class='ng-binding'])[last()]");
        private readonly ILogger<CalculatorPage> _logger;
        private readonly PrintScreenService _printScreenService;

        public CalculatorPage(IWebDriver driver, ILogger<CalculatorPage> logger, PrintScreenService printScreenService)
            : base(driver)
        {
            _logger = logger;
            _printScreenService = printScreenService;
            url = "https://cloud.google.com/products/calculator";
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "devsite-snackbar-action")]
        public IWebElement CookiesWindowOkButton { get; set; }

        [FindsBy(How = How.Id, Using = "input_99")]
        public IWebElement InstancesNumberInput { get; set; }

        [FindsBy(How = How.Id, Using = "select_124")]
        public IWebElement SeriesSelectbox { get; set; }

        #region MachineTypeSelectbox
        [FindsBy(How = How.XPath, Using = "//md-select[@placeholder='Instance type']")]
        public IWebElement MachineTypeSelectbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@value='CP-COMPUTEENGINE-VMIMAGE-N1-STANDARD-8']")]
        public IWebElement MachineTypeOption { get; set; }
        #endregion

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Add GPUs']")]
        public IWebElement GPUsCheckbox { get; set; }

        #region GPUTypeSearchbox
        private readonly By _GPUTypeNeededOptionLocator = By.Id("select_option_513");

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='GPU type']")]
        public IWebElement GPUTypeSearchbox { get; set; }
        #endregion

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='Number of GPUs']")]
        public IWebElement GPUsNumberSearchbox { get; set; }

        #region SSDSelectbox
        private By _SSDNeededOptionLocator = By.Id("select_option_491");

        [FindsBy(How = How.XPath, Using = "//*[@placeholder='Local SSD']")]
        public IWebElement SSDSelectbox { get; set; }
        #endregion

        #region DatacenterLocationInput
        private readonly By _dcLocationNeededOptionLocator = By.Id("select_option_264");

        [FindsBy(How = How.Id, Using = "select_132")]
        public IWebElement DatacenterLocationInput { get; set; }
        #endregion;

        [FindsBy(How = How.Id, Using = "select_139")]
        public IWebElement CommittedUsageInput { get; set; }

        [FindsBy(How = How.Id, Using = "Email Estimate")]
        public IWebElement EmailEstimateButton { get; set; }

        [FindsBy(How = How.Id, Using = "input_616")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.XPath, Using = "(//*[starts-with(@id, 'dialogContent_')]//button)[last()]")]
        public IWebElement SendEmailButton { get; set; }

        public void CalculatePrice(ResourceModel model)
        {
            PrepareData(model);

            var EstimateButton = wait.Until(ExpectedConditions.ElementToBeClickable(_estimateButtonLocator));
            EstimateButton.Click();
        }

        public void SendPrice(string email)
        {
            EmailEstimateButton.Click();
            EmailInput.SendKeys(email);
            SendEmailButton.Click();
        }

        private void PrepareData(ResourceModel resources)
        {
            try
            {
                CookiesWindowOkButton.Click();
            }
            catch(NoSuchElementException ex)
            {
                _printScreenService.CaptureScreenToFile("screen.png", System.Drawing.Imaging.ImageFormat.Png);
                _logger.LogError(ex, "No Accept Cookies Alert");
            }

            SwitchToFrames();

            InstancesNumberInput.SendKeys(resources.NumberOfInstances.ToString());

            SeriesSelectbox.SendKeys(resources.Series);

            MachineTypeSelectbox.Click();
            MachineTypeOption.Click();

            GPUsCheckbox.Click();
            GPUTypeSearchbox.Click();
            var GPUTypeNeededOption = wait.Until(ExpectedConditions.ElementToBeClickable(_GPUTypeNeededOptionLocator));
            GPUTypeNeededOption.Click();
            GPUsNumberSearchbox.SendKeys(resources.NumberOfGPUs.ToString());

            SSDSelectbox.Click();
            var sSDNeededOption = wait.Until(ExpectedConditions.ElementToBeClickable(_SSDNeededOptionLocator));
            sSDNeededOption.Click();

            DatacenterLocationInput.SendKeys(resources.DatacenterLocation);
            var dcLocationNeededOption = wait.Until(ExpectedConditions.ElementToBeClickable(_dcLocationNeededOptionLocator));
            dcLocationNeededOption.Click();
            CommittedUsageInput.SendKeys(resources.CommittedUsage.ToString());
        }

        public string GetEstimatedMessage()
        {
            var messageElement = wait.Until(ExpectedConditions.ElementExists(_estimatedMessageLocator));

            return messageElement.Text;
        }
    }
}
