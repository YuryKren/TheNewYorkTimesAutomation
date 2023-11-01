using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheNewYorkTimesAutomation
{
    internal class TNYTHomePage
    {
        IWebDriver _driver;
        const string HOME_PAGE = "https://www.nytimes.com/";
        const string BUTTON_TO_AGREE_WITH_CHANGES = "//button[text()='Continue']";
        const string MENU_ITEM_TEMPLATE = "//div[@data-testid]//a[@data-navid='{0}']";

        public TNYTHomePage(IWebDriver webDriver) 
        {
            _driver = webDriver;
            _driver.Url = HOME_PAGE;
            _driver.Manage().Window.Maximize();
        }

        public void ClickAgreementOnCondition() 
        {
            IWebElement agreePolicy = _driver.FindElement(By.XPath(BUTTON_TO_AGREE_WITH_CHANGES));
            agreePolicy.Click();
        }

        public bool CheckPage(string xPath)
        {
            string result = string.Format(MENU_ITEM_TEMPLATE, xPath);
            IWebElement webElement = _driver.FindElement(By.XPath(result));
            webElement.Click();

            Thread.Sleep(1000);
            string titlePage = _driver.Title;
            string pageUrl = _driver.Url;

            _driver.Url = HOME_PAGE;

            return titlePage.Contains(xPath) && pageUrl.Contains(xPath.ToLower());
        }
    }
}
