using OpenQA.Selenium;

namespace TheNewYorkTimesAutomation
{
    public class TNYTSearchPage : TNYTBaseClass
    {
        const string CALL_SEARCH_BUTTON = "//button[@data-testid='search-button']";
        const string REQUEST_INPUT_FIELD = "//input[@data-testid='search-input']";
        const string CLICK_SEARCH_BUTTON = "//button[@data-testid='search-submit']";
        const string SEARCH_TITLES = "//li//h4[text()]";
        const string COUNT_RESULTS_FOUND = "//p[@class='css-nayoou']";

        public TNYTSearchPage(IWebDriver webDriver) : base(webDriver) { }

        public List<string>? GetSearchResults(string searchRequest) 
        {
            WaitAndClickOnElement(CALL_SEARCH_BUTTON);
            FindElementAndInputValue(REQUEST_INPUT_FIELD, searchRequest);
            ClickOnElement(CLICK_SEARCH_BUTTON);

            if (CheckCountOfSearchResults(GetElementByXPath(COUNT_RESULTS_FOUND)) != 0)
            {
                return ConvertCollectionFromWebElementToString(GetElementsByXPath(SEARCH_TITLES));
            }
            else { return null; }
        }

    }
}
