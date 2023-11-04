using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TheNewYorkTimesAutomation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            TNYTHomePage homePage = new(driver);

            try 
            {
                homePage.ClickAgreementOnCondition();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            bool testCaseLifestyleNews= homePage.CheckPage("Lifestyle");
            bool testCaseWorldNews = homePage.CheckPage("World");
            bool testCaseArtsNews = homePage.CheckPage("Arts");

            Console.WriteLine($"Test results: {testCaseLifestyleNews}, {testCaseWorldNews}, {testCaseArtsNews}");

            driver.Close();

        }
    }
}