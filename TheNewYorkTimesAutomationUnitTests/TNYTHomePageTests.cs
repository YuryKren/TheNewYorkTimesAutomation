using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheNewYorkTimesAutomation;

namespace TheNewYorkTimesAutomationUnitTests
{
    [TestClass]
    public class TNYTHomePageTests
    {
        [TestMethod]

        [DataRow("World")]
        [DataRow("Business")]
        [DataRow("Arts")]
        [DataRow("Lifestyle")]
        [DataRow("Opinion")]

        public void CheckingPerformanceOfNewsSelectionMenu(string item)
        {
            IWebDriver driver = new ChromeDriver();

            TNYTHomePage homePage = new(driver);

            homePage.ClickAgreeWithOnConditions();

            Assert.IsTrue(homePage.CheckPage(item));

            driver.Close();

        }
    }
}