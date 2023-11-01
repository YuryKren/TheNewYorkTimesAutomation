using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheNewYorkTimesAutomation
{
    internal class Program
    {
        static void CheckPage(IWebDriver driver, string xPath)
        {
            IWebElement webElement = driver.FindElement(By.XPath($"//div[@data-testid]//a[@data-navid='{xPath}']"));
            webElement.Click();

            Thread.Sleep(1000);
            string titlePage = driver.Title;
            Console.WriteLine("Title page {0} contains - {1}", xPath, titlePage.Contains(xPath));

            string pageUrl = driver.Url;
            Console.WriteLine("Page {0} URL contains - {1}", xPath, pageUrl.Contains(xPath.ToLower()));

            driver.Url = "https://www.nytimes.com/";
        }

        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.nytimes.com/";
            driver.Manage().Window.Maximize();

            IWebElement agreePolicy = driver.FindElement(By.XPath("//button[text()='Continue']"));
            agreePolicy.Click();

            CheckPage(driver, "U.S.");
            CheckPage(driver, "World");
            CheckPage(driver, "Arts");



            driver.Close();

        }
    }
}