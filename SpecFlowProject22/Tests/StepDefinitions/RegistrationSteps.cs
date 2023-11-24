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
    public class RegistrationSteps
    {
        
        RegistrationPage registrationPage;

        private IWebDriver driver;

        public RegistrationSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"the user is on the registration page")]
        public void GivenTheUserIsOnTheRegistrationPage()
        {
            driver.Navigate().GoToUrl("http://www.website.com/registration");
        }

        [When(@"user enters valid registration details username as ""(.*)"", password is ""(.*)"" and confirm password as ""(.*)""")]
        [When(@"the user provides invalid registration details username as ""(.*)"", password is ""(.*)"" and confirm password as ""(.*)""")]
        [When(@"the user provides registration details with the existing username as ""(.*)""")]
        public void WhenUserEntersRegistrationDetails(string username, string password, string confirmPassword)
        {
            registrationPage.EnterRegistrationDetails(username, password, confirmPassword);
        }

        [When(@"user provides passwords as ""(.*)"" and ""(.*)""")]
        public void WhenUserProvidesPasswords(string password, string confirmPassword)
        {
            registrationPage.EnterRegistrationDetails("", password, confirmPassword);
        }

        [Then(@"clicks the Register button")]
        public void ThenClicksTheRegisterButton()
        {
            registrationPage.ClickRegisterButton();
        }

        [Then(@"the user should be able to view registration success message")]
        public void ThenTheUserShouldBeAbleToViewRegistrationSuccessMessage()
        {
            Assert.IsTrue(registrationPage.GetSuccessMessage().Contains("Registration successful"));
        }

        [Then(@"an error message should be displayed")]
        public void ThenAnErrorMessageShouldBeDisplayed()
        {
            Assert.IsFalse(string.IsNullOrEmpty(registrationPage.GetErrorMessage()));
        }

        [Then(@"the user should remain on the registration page")]
        public void ThenTheUserShouldRemainOnTheRegistrationPage()
        {
            Assert.IsTrue(driver.Url.Contains("/registration"));
        }
    }
}
