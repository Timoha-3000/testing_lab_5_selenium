using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;

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

/*        [Test]
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
        }*/

        [Test]
        public void TestSearchFunctionalityForWiki()
        {
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");

            IWebElement searchInput = driver.FindElement(By.Id("searchInput"));
            searchInput.SendKeys("Selenium (software)");

            IWebElement searchButton = driver.FindElement(By.XPath("//button[@type='submit']"));
            searchButton.Click();

            Assert.That(driver.Title, Does.Contain("Selenium (software)"));
        }

        [Test]
        public void TestForumRegistration()
        {
            driver.Navigate().GoToUrl("http://example.com/forum/registration");

            driver.FindElement(By.Id("username")).SendKeys("testuser");
            driver.FindElement(By.Id("email")).SendKeys("testuser@example.com");
            driver.FindElement(By.Id("password")).SendKeys("password123");
            driver.FindElement(By.Id("confirmPassword")).SendKeys("password123");

            driver.FindElement(By.Id("registerButton")).Click();

            // Проверка успешной регистрации
            Assert.That(driver.FindElement(By.Id("successMessage")), Is.Not.Null);
        }

        [Test]
        public void TestVotingSystem()
        {
            driver.Navigate().GoToUrl("http://example.com/vote");

            var voteOption = driver.FindElement(By.Id("option1"));
            voteOption.Click();

            driver.FindElement(By.Id("voteButton")).Click();

            // Проверка подтверждения голосования
            Assert.That(driver.FindElement(By.Id("voteConfirmation")), Is.Not.Null);
        }

        [Test]
        public void TestPhoneDirectorySearch()
        {
            driver.Navigate().GoToUrl("https://telefonio.ru/1-e_krasnikovo.html");

            driver.FindElement(By.Name("fam")).SendKeys("Малахов");
            driver.FindElement(By.Name("tel")).SendKeys("+7 (967) 662-79-98");
            Thread.Sleep(4000);
            driver.FindElement(By.ClassName("text1")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

            IWebElement noResultsText = driver.FindElement(By.XPath("//text()[.='Воспользуйтесь формой для онлайн поиска или скачайте телефонный справочник целиком. Вы можете найти абонента по номеру телефона, фамилии или адресу.']"));
            bool flag = noResultsText.Text.Contains("Воспользуйтесь формой для");
            Assert.That(flag, Is.True, "No results text not found.");
        }
    }
}
