﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace TheNewYorkTimesAutomation
{
    public abstract class TNYTBaseClass
    {
        protected IWebDriver _driver;
        protected WebDriverWait _waiter;
        const string HOME_PAGE = "https://www.nytimes.com/";
        const string BUTTON_TO_AGREE_WITH_CHANGES = "//button[text()='Continue']";

        public TNYTBaseClass(IWebDriver webDriver)
        {
            _driver = webDriver;
            _driver.Url = HOME_PAGE;
            _driver.Manage().Window.Maximize();
            _waiter = new WebDriverWait(webDriver, TimeSpan.FromSeconds(5));
            ClickAgreeWithOnConditions();
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

        public void WaitAndClickOnElement(string xPath)
        {
            IWebElement webElement = GetElementsByXPath(xPath).First();
            webElement.Click();
        }

        public void ClickOnElement(string xPath)
        {
            IWebElement webElement = _driver.FindElement(By.XPath(xPath));
            webElement.Click();
        }

        public void FindElementAndInputValue(string xPath, string value)
        {
            IWebElement webElement = _driver.FindElement(By.XPath(xPath));
            webElement.SendKeys(value);
        }

        public IWebElement GetElementByXPath(string xPath)
        {
            return _waiter.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
        }

        public ReadOnlyCollection<IWebElement> GetElementsByXPath(string xPath)
        {
            return _waiter.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
        }

        public bool AreTitleAndUrlContainsKeyword(string keyword)
        {
            _waiter.Until(ExpectedConditions.TitleContains(keyword));
            string titlePage = _driver.Title;
            string pageUrl = _driver.Url;
            return titlePage.Contains(keyword) && pageUrl.Contains(keyword.ToLower());
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

        public List<string> ConvertCollectionFromWebElementToString(ReadOnlyCollection<IWebElement> collection)
        {
            List<string> textResult = new(collection.Select(x => x.Text));
            return textResult;
        }

    }
}
