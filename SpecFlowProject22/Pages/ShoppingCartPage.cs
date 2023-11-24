using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Pages
{
    internal class ShoppingCartPage
    {
        private IWebDriver driver;

        // Define locators using By
        private By searchField = By.Id("search-field");
        private By bookTitleLink = By.Id("book-title-link");
        private By addToCartButton = By.Id("add-to-cart-button");
        private By shoppingCartButton = By.Id("shopping-cart-button");
        private By proceedToCheckoutButton = By.Id("proceed-to-checkout-button");
        private By bookInCart = By.Id("book-in-cart");
        private By bookInOrderSummary = By.Id("book-in-order-summary");

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchForBook(string bookTitle)
        {
            driver.FindElement(searchField).SendKeys(bookTitle);
            driver.FindElement(searchField).Submit();
        }

        public void ClickOnBookTitleLink()
        {
            driver.FindElement(bookTitleLink).Click();
        }

        public void AddBookToCart()
        {
            driver.FindElement(addToCartButton).Click();
        }

        public string GetBookInCart()
        {
            return driver.FindElement(bookInCart).Text;
        }

        public void GoToCart()
        {
            driver.FindElement(shoppingCartButton).Click();
        }

        public void ProceedToCheckout()
        {
            driver.FindElement(proceedToCheckoutButton).Click();
        }

        public string GetBookInOrderSummary()
        {
            return driver.FindElement(bookInOrderSummary).Text;
        }
    }
}
