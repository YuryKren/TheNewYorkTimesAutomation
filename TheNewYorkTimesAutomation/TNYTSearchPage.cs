using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using System.IO;

namespace TheNewYorkTimesAutomation
{
    public class TNYTSearchPage
    {
        IWebDriver _driver;
        WebDriverWait _waiter;
        const string HOME_PAGE_ADDRESS = "https://www.nytimes.com/";
        const string CALL_SEARCH_BUTTON = "//button[@data-testid='search-button']";
        const string REQUEST_INPUT_FIELD = "//input[@data-testid='search-input']";
        const string CLICK_SEARCH_BUTTON = "//button[@data-testid='search-submit']";
        const string RESULT_OBTAINED = "//li//h4[text()]";
        const string COUNT_RESULTS_FOUND = "//p[@class='css-nayoou']";

        public TNYTSearchPage(IWebDriver driver) 
        {
            _driver = driver;
            _driver.Url = HOME_PAGE_ADDRESS;
            _driver.Manage().Window.Maximize();
            _waiter = new(_driver, TimeSpan.FromSeconds(5));
        }

        public List<string> GetSearchResults(string searchRequest) 
        {
            var callSearchButton = _driver.FindElement(By.XPath(CALL_SEARCH_BUTTON));
            callSearchButton.Click();
            var inputSearchRequest = _driver.FindElement(By.XPath(REQUEST_INPUT_FIELD));
            inputSearchRequest.SendKeys(searchRequest);
            var searchButton = _driver.FindElement(By.XPath(CLICK_SEARCH_BUTTON));
            searchButton.Click();

            var countOfResultsString = _waiter.Until(ExpectedConditions.ElementExists(By.XPath(COUNT_RESULTS_FOUND)));
            
            if (CheckCountOfSearchResults(countOfResultsString) != 0)
            {
                var resultSearch = _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(RESULT_OBTAINED)));
                List<string> textResult = new(resultSearch.Select(x => x.Text));

                return textResult;
            }
            else 
            {
                return null;
            }
        }

        public int CheckCountOfSearchResults(IWebElement countOfResultsString)
        {
            string[] findingNumber = countOfResultsString.Text.Split(' ');
            int n = 0;
            foreach (string part in findingNumber)
            {
                bool success = int.TryParse(part, out n);
                if (success)
                {
                    n = int.Parse(part);
                    break;
                }
            }
            return n;
        }

    }
}
