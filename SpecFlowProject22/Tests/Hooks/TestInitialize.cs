using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Tests.Hooks
{
    [Binding]
    public class TestInitialize
    {
        private readonly ScenarioContext _scenarioContext;

        public TestInitialize(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // This method will run before each scenario.
            IWebDriver driver = new ChromeDriver();
            _scenarioContext["driver"] = driver;
        }
    }
}
