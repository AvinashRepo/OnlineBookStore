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
    internal class LogInSteps
    {
        
        LogInPage logInPage;

        private IWebDriver driver;

        public LogInSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("http://www.website.com/login");
            logInPage = new LogInPage(driver);
        }

        [When(@"user enter a valid username as ""(.*)"" and password as ""(.*)""")]
        [When(@"user enter an invalid username as ""(.*)"" and password as ""(.*)""")]
        public void WhenUserEnterAValidUsernameAsAndPasswordAs(string username, string password)
        {
            logInPage.EnterUsernameAndPassword(username, password);
        }

        [When(@"user leave the username and password field empty")]
        public void WhenUserLeaveTheUsernameAndPasswordFieldEmpty()
        {
            logInPage.EnterUsernameAndPassword("", "");
        }

        [Then(@"user clicks on login button")]
        public void ThenUserClicksOnLoginButton()
        {
            logInPage.ClickLoginButton();
        }

        [Then(@"user should see a welcome message with their username")]
        public void ThenUserShouldSeeAWelcomeMessageWithTheirUsername(Table table)
        {
            var username = table.Rows[0]["username"];
            Assert.IsTrue(logInPage.GetWelcomeMessage().Contains(username));
        }

        [Then(@"user should see an error message indicating invalid credentials")]
        [Then(@"user should see an error message for the required fields")]
        public void ThenUserShouldSeeAnErrorMessageIndicatingInvalidCredentialsOrRequiredFields()
        {
            Assert.IsFalse(string.IsNullOrEmpty(logInPage.GetErrorMessage()));
        }
    }
}
