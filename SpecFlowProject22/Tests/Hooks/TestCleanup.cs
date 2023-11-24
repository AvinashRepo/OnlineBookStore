using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Tests.Hooks
{
    [Binding]
    public class TestCleanup
    {
        private readonly ScenarioContext _scenarioContext;
        IWebDriver driver;

        public TestCleanup(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // This method will run after each scenario.

            driver.Quit();
            
            
            
        }
    }
}
