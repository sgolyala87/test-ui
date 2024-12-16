using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject.Setup.Logging;
using Xunit.Abstractions;

namespace TestProject.Setup
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ITestOutputHelper _testOutputHelper;
        private IBrowser _browser;
        private IPage _page;
        private Config _config;

        
        public ScenarioHooks(ScenarioContext scenarioContext, ITestOutputHelper testOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _testOutputHelper = testOutputHelper;
            _config = ConfigReader.GetConfig();
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            
            ConsoleLogger.LogMessage($"[{DateTime.Now}] Starting setup for scenario: {_scenarioContext.ScenarioInfo.Title}");

            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();

            _scenarioContext["Browser"] = _browser;
            _scenarioContext["Page"] = _page;

            
            ConsoleLogger.LogMessage($"[{DateTime.Now}] Browser setup completed successfully.");
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
           
            ConsoleLogger.LogMessage($"[{DateTime.Now}] Starting teardown for scenario: {_scenarioContext.ScenarioInfo.Title}");

            if (_browser != null)
            {
                await _browser.CloseAsync();
                ConsoleLogger.LogMessage($"[{DateTime.Now}] Browser closed successfully.");
            }

            
            ConsoleLogger.OutputLogs(_testOutputHelper);
        }
    }
}
