using NUnit.Framework;
using OnlineBookStore.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace OnlineBookStore.Tests.StepDefinitions
{
    [Binding]
    public class BookSearchSteps
    {
        BookSearchPage bookSearchPage;

        private IWebDriver driver;

        public BookSearchSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the homepage of the online bookstore")]
        public void GivenTheUserIsOnTheHomepageOfTheOnlineBookstore()
        {
            driver.Navigate().GoToUrl("http://www.onlinebookstore.com");
            bookSearchPage = new BookSearchPage(driver);
        }

        [When(@"the user enters ""(.*)"" into the search bar")]
        public void WhenTheUserEntersIntoTheSearchBar(string searchTerm)
        {
            bookSearchPage.EnterSearchTerm(searchTerm);
        }

        [When(@"the user clicks on the search button")]
        public void WhenTheUserClicksOnTheSearchButton()
        {
            bookSearchPage.ClickSearchButton();
        }

        [Then(@"the search results should display a list of books related to ""(.*)""")]
        public void ThenTheSearchResultsShouldDisplayAListOfBooksRelatedTo(string bookTitle)
        {
            var results = bookSearchPage.GetResultsText();
            Assert.IsTrue(results.Contains(bookTitle));
        }

        [When(@"the search results for ""(.*)"" are displayed")]
        public void WhenTheSearchResultsForAreDisplayed(string bookTitle)
        {
            var results = bookSearchPage.GetResultsText();
            Assert.IsTrue(results.Contains(bookTitle));
        }

        [When(@"the user clicks on the book titled ""(.*)"" by ""(.*)"" from the search results")]
        public void WhenTheUserClicksOnTheBookTitledByFromTheSearchResults(string bookTitle, string author)
        {
            bookSearchPage.ClickOnBookInResults(bookTitle, author);
        }

        [Then(@"the book's detail page should open with the title ""(.*)""")]
        public void ThenTheBookSDetailPageShouldOpenWithTheTitle(string bookTitle)
        {
            var detailTitle = bookSearchPage.GetBookDetailTitle();
            Assert.AreEqual(bookTitle, detailTitle);
        }

        [Then(@"the author name should be displayed as ""(.*)""")]
        public void ThenTheAuthorNameShouldBeDisplayedAs(string author)
        {
            var detailAuthor = bookSearchPage.GetBookDetailAuthor();
            Assert.AreEqual(author, detailAuthor);
        }

        [Then(@"the page should display a message saying ""(.*)""")]
        public void ThenThePageShouldDisplayAMessageSaying(string expectedMessage)
        {
            var errorMessage = bookSearchPage.GetErrorMessage();
            Assert.AreEqual(expectedMessage, errorMessage);
        }
    }

}
