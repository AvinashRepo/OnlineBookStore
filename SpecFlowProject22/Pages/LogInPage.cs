using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Pages
{
    internal class LogInPage
    {
        private IWebDriver driver;

        public LogInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Define locators using By
        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By welcomeMessage = By.Id("welcome-message");
        private By errorMessage = By.Id("error-message");
    

        public void EnterUsernameAndPassword(string username, string password)
        {
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }

        public string GetWelcomeMessage()
        {
            return driver.FindElement(welcomeMessage).Text;
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }
    }
}
