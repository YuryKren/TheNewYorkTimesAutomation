using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheNewYorkTimesAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.nytimes.com/";

            driver.Close();
            Console.WriteLine();
        }
    }
}