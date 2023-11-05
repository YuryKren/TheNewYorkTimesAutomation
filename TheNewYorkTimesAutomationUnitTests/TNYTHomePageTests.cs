using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheNewYorkTimesAutomation;

namespace TheNewYorkTimesAutomationUnitTests
{
    [TestClass]
    public class TNYTHomePageTests
    {
        IWebDriver _driver;

        [TestInitialize] 
        public void Initialize() 
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]

        [DataRow("World")]
        [DataRow("Business")]
        [DataRow("Arts")]
        [DataRow("Lifestyle")]
        [DataRow("Opinion")]

        public void CheckingPerformanceOfNewsSelectionMenu(string item)
        {
            TNYTHomePage homePage = new(_driver);
            Assert.IsTrue(homePage.CheckPageLink(item));
        }

        [TestCleanup] 
        public void Cleanup() 
        {
            _driver.Close();
        }

    }
}