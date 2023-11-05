using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheNewYorkTimesAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            TNYTSearchPage testPage = new(driver);

            var result = testPage.GetSearchResults("Belarus");

            foreach (var resultItem in result) 
            {
                Console.WriteLine(resultItem);
            }

            driver.Close();
        }
    }
}