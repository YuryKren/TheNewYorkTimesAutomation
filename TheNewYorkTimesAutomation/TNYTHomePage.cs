using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TheNewYorkTimesAutomation
{
    public class TNYTHomePage
    {
        IWebDriver _driver;
        WebDriverWait _waiter;
        const string HOME_PAGE = "https://www.nytimes.com/";
        const string BUTTON_TO_AGREE_WITH_CHANGES = "//button[text()='Continue']";
        const string MENU_ITEM_TEMPLATE = "//div[@data-testid]//a[@data-navid='{0}']";

        public TNYTHomePage(IWebDriver webDriver) 
        {
            _driver = webDriver;
            _driver.Url = HOME_PAGE;
            _driver.Manage().Window.Maximize();
            _waiter = new(_driver, TimeSpan.FromSeconds(5));
        }

        public void ClickAgreeWithOnConditions() 
        {
            var foundElements = _driver.FindElements(By.XPath(BUTTON_TO_AGREE_WITH_CHANGES));
            if (foundElements.Count() != 0) 
            {
                foundElements[0].Click();
            }
            else 
            {
                Console.WriteLine("There isn't Button \"Agree with the conditions\" ");
            }
        }

        public bool CheckPage(string xPath)
        {
            string result = string.Format(MENU_ITEM_TEMPLATE, xPath);
            IWebElement webElement = _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(result))).First();
            webElement.Click();

            _waiter.Until(ExpectedConditions.TitleContains(xPath));
            string titlePage = _driver.Title;
            string pageUrl = _driver.Url;

            _driver.Navigate().Back();

            return titlePage.Contains(xPath) && pageUrl.Contains(xPath.ToLower());
        }
    }
}
