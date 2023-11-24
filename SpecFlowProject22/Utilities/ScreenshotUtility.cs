using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Utilities
{
    public class ScreenshotUtility
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _webDriver;

        public ScreenshotUtility(ScenarioContext scenarioContext, IWebDriver webDriver)
        {
            _scenarioContext = scenarioContext;
            _webDriver = webDriver;
        }

        [AfterScenario]
        public void TakeScreenshotAfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                var screenshot = ((ITakesScreenshot)_webDriver).GetScreenshot();
                var screenshotFileName = $"{_scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
                Console.WriteLine($"Screenshot: {screenshotFileName}");
            }
        }
    }
}
