using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TheNewYorkTimesAutomation;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace TheNewYorkTimesAutomationUnitTests
{
    [TestClass]
    public class TNYTSearchResultsTest
    {
        IWebDriver _driver;

        [TestInitialize]
        public void Initialize() 
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        [DataRow("Belarus")]
        [DataRow("Italy")]
        [DataRow("Poland")]
        [DataRow("Canada")]
        

        public void CheckingSearchResultsTestPositive(string item)
        {
            TNYTSearchPage searchPage = new (_driver);
            var headlinesSearchResults = searchPage.GetSearchResults(item);
            var сheckingPresenceOfRequestInContentOfResults = headlinesSearchResults.Where(x => x.Contains(item)).ToList();
            Assert.IsTrue(headlinesSearchResults.Count()/2 <= сheckingPresenceOfRequestInContentOfResults.Count());
        }

        [TestMethod]
        public void CheckingSearchResultsTestNegative()
        {
            TNYTSearchPage searchPage = new(_driver);
            var headlinesSearchResults = searchPage.GetSearchResults("kenbgodjenb");
            Assert.IsTrue(headlinesSearchResults == null);
        }

        [TestCleanup]
        public void Cleanup() 
        {
            _driver.Close();
        }
    }
}
