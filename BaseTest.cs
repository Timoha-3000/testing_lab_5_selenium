using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace testing_lab_5_selenium
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // Для Firefox будет так:
            // driver = new FirefoxDriver();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
