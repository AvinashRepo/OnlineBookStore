using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Pages
{
    internal class RegistrationPage
    {
        private IWebDriver driver;

        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Define locators using By
        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By confirmPasswordField = By.Id("confirm-password");
        private By registerButton = By.Id("register-button");
        private By successMessage = By.Id("success-message");
        private By errorMessage = By.Id("error-message");

       

        public void EnterRegistrationDetails(string username, string password, string confirmPassword)
        {
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(confirmPasswordField).SendKeys(confirmPassword);
        }

        public void ClickRegisterButton()
        {
            driver.FindElement(registerButton).Click();
        }

        public string GetSuccessMessage()
        {
            return driver.FindElement(successMessage).Text;
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(errorMessage).Text;
        }
    }
}
