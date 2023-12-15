using OpenQA.Selenium;

namespace testing_lab_5_selenium
{
    public class SearchTest : BaseTest
    {
        [Test]
        public void TestSearchFunctionality()
        {
            driver.Navigate().GoToUrl("https://miet.ru/search/");

            IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input")); 
            Assert.That(searchBox, Is.Not.Null, "Search box not found.");
        }

        [Test]
        public void TestSearchFunctionality2()
        {
            //IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input"));
            IWebElement searchText = driver.FindElement(By.XPath("//text()[.='Поиск по сайту']"));
            Assert.That(searchText, Is.Not.Null, "Search text 'Поиск по сайту' not found.");
        }

        [Test]
        public void TestSearchFunctionality3()
        {
            IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input")); 

            searchBox.SendKeys("asdfghjkl");
            searchBox.Submit();

            IWebElement noResultsText = driver.FindElement(By.XPath("//text()[.='К сожалению, на ваш поисковый запрос ничего не найдено']"));
            Assert.That(noResultsText, Is.Not.Null, "No results text not found.");
        }

        [Test]
        public void TestSearchFunctionality4()
        {
            IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input")); 

            searchBox.Clear();
            searchBox.SendKeys("Кожухов");
            searchBox.Submit();

            IWebElement resultsTable = driver.FindElement(By.ClassName("result-list__news")); // Замените на актуальный класс
            Assert.That(resultsTable, Is.Not.Null, "Results table not found.");

            IWebElement specificPerson = driver.FindElement(By.XPath("//text()[.='Кожухов Игорь Борисович']"));
            Assert.That(specificPerson, Is.Not.Null, "Specific person not found in search results.");
        }

        [Test]
        public void TestSearchFunctionality5()
        {
            driver.Navigate().GoToUrl("https://miet.ru/search/");

            IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input")); 
            Assert.That(searchBox, Is.Not.Null, "Search box not found.");
        }

        [Test]
        public void AllTestSearchFunctionality()
        {
            driver.Navigate().GoToUrl("https://miet.ru/search/");

            IWebElement searchBox = driver.FindElement(By.ClassName("search-bar__input")); 
            Assert.That(searchBox, Is.Not.Null, "Search box not found.");

            IWebElement searchText = driver.FindElement(By.XPath("//text()[.='Поиск по сайту']"));
            Assert.That(searchText, Is.Not.Null, "Search text 'Поиск по сайту' not found.");

            searchBox.SendKeys("asdfghjkl");
            searchBox.Submit();

            IWebElement noResultsText = driver.FindElement(By.XPath("//text()[.='К сожалению, на ваш поисковый запрос ничего не найдено']"));
            Assert.That(noResultsText, Is.Not.Null, "No results text not found.");

            searchBox.Clear();
            searchBox.SendKeys("Кожухов");
            searchBox.Submit();

            IWebElement resultsTable = driver.FindElement(By.ClassName("search-bar__input")); // Замените на актуальный класс
            Assert.That(resultsTable, Is.Not.Null, "Results table not found.");

            IWebElement specificPerson = driver.FindElement(By.XPath("//text()[.='Кожухов Игорь Борисович']"));
            Assert.That(specificPerson, Is.Not.Null, "Specific person not found in search results.");
        }
    }
}
