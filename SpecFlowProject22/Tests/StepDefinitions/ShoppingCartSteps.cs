using NUnit.Framework;
using OnlineBookStore.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OnlineBookStore.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        
        ShoppingCartPage shoppingCartPage;

        private IWebDriver driver;

        public ShoppingCartSteps(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"the user is on the homepage of the online bookstore")]
        public void GivenTheUserIsOnTheHomePage()
        {
            driver.Navigate().GoToUrl("http://www.website.com/");
            
        }

        [Given(@"the user has searched for ""(.*)""")]
        public void GivenTheUserHasSearchedFor(string bookTitle)
        {
            shoppingCartPage.SearchForBook(bookTitle);
        }

        [When(@"the user clicks on the book ""(.*)"" from the search results")]
        public void WhenTheUserClicksOnTheBookFromTheSearchResults(string bookTitle)
        {
            shoppingCartPage.ClickOnBookTitleLink();
        }

        [Then(@"the book details page for ""(.*)"" should be displayed")]
        public void ThenTheBookDetailsPageShouldBeDisplayed(string bookTitle)
        {
            Assert.IsTrue(driver.Url.Contains(bookTitle));
        }

        [When(@"the user clicks on Add to Cart button")]
        public void WhenTheUserClicksOnAddToCartButton()
        {
            shoppingCartPage.AddBookToCart();
        }

        [Then(@"""(.*)"" should be added to the shopping cart")]
        public void ThenShouldBeAddedToTheShoppingCart(string bookTitle)
        {
            Assert.AreEqual(bookTitle, shoppingCartPage.GetBookInCart());
        }

        [Given(@"the user has ""(.*)"" in the shopping cart")]
        public void GivenTheUserHasInTheShoppingCart(string bookTitle)
        {
            shoppingCartPage.SearchForBook(bookTitle);
            shoppingCartPage.ClickOnBookTitleLink();
            shoppingCartPage.AddBookToCart();
        }

        [When(@"the user clicks on Shopping Cart button")]
        public void WhenTheUserClicksOnShoppingCartButton()
        {
            shoppingCartPage.GoToCart();
        }

        [Then(@"the shopping cart page should be displayed")]
        public void ThenTheShoppingCartPageShouldBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("/cart"));
        }

        [When(@"the user clicks on Proceed to Checkout button")]
        public void WhenTheUserClicksOnProceedToCheckoutButton()
        {
            shoppingCartPage.ProceedToCheckout();
        }

        [Then(@"the checkout page should be displayed")]
        public void ThenTheCheckoutPageShouldBeDisplayed()
        {
            Assert.IsTrue(driver.Url.Contains("/checkout"));
        }

        [Then(@"""(.*)"" should be listed in the order summary")]
        public void ThenShouldBeListedInTheOrderSummary(string bookTitle)
        {
            Assert.AreEqual(bookTitle, shoppingCartPage.GetBookInOrderSummary());
        }
    }

}
