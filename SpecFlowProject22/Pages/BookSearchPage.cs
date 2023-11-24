using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OnlineBookStore.Pages
{
    internal class BookSearchPage
    {
        private IWebDriver driver;

        public BookSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By searchbar = By.Id("searchbar");
        private By searchButton = By.Id("search-button");
        private By results = By.Id("results");
        private By errorMessage = By.Id("error-message");
        private By bookDetailTitle = By.Id("book-detail-title");
        private By bookDetailAuthor = By.Id("book-detail-author");


        public void EnterSearchTerm(string searchTerm)
        {
            driver.FindElement(searchbar).SendKeys(searchTerm);
        }

        public void ClickSearchButton()
        {
            driver.FindElement(searchButton).Click();
        }

        public string GetResultsText()
        {
            return driver.FindElement(results).Text;
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }

        public string GetBookDetailTitle()
        {
            return driver.FindElement(bookDetailTitle).Text;
        }

        public string GetBookDetailAuthor()
        {
            return driver.FindElement(bookDetailAuthor).Text;
        }

        public void ClickOnBookInResults(string bookTitle, string author)
        {
            driver.FindElement(By.XPath("//a[contains(text(), '{bookTitle}') and contains(text(), '{author}')]")).Click();
        }
    }
}
