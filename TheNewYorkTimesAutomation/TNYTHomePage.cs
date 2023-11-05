using OpenQA.Selenium;

namespace TheNewYorkTimesAutomation
{
    public class TNYTHomePage : TNYTBaseClass
    {
        const string MENU_ITEM_TEMPLATE_XPATH = "//div[@data-testid]//a[@data-navid='{0}']";

        public TNYTHomePage(IWebDriver webDriver) : base(webDriver) { }

        public bool CheckPageLink(string keyword)
        {
            string finalLocator = string.Format(MENU_ITEM_TEMPLATE_XPATH, keyword);
            WaitAndClickOnElement(finalLocator);

            return AreTitleAndUrlContainsKeyword(keyword);
        }
    }
}
