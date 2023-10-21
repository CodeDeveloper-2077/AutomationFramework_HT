using AutomationFramework_HT;

namespace AutomationFrameworkTests
{
    [TestClass]
    public class CalculatorPageTests : CommonConditions
    {
        private CloudPage _cloudPage;
        private CalculatorPage _calculatorPage;

        [TestInitialize]
        new public void TestInitialize()
        {
            base.TestInitialize();
            _cloudPage = new CloudPage(driver);
            _calculatorPage = new CalculatorPage(driver);
        }

        [TestMethod]
        [DataRow("Google Cloud Platform Pricing Calculator")]
        public void FillTheForm_ShouldFillTheFormToEstimation(string page)
        {
            //Arrange
            string expected = "Total Estimated Cost: USD 1,081.20 per 1 month";

            //Act
            _cloudPage.Navigate();
            _cloudPage.SearchPage(page);
            _calculatorPage.FillTheForm();

            //Assert
            Assert.AreEqual(expected, _calculatorPage.GetEstimatedMessage());
        }
    }
}
