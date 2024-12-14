using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject.Setup
{
    [Binding]
    public class ScenarioHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IBrowser _browser;
        private IPage _page;
        private Config _config;

        public ScenarioHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _config = ConfigReader.GetConfig();
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await _browser.NewContextAsync();
            _page = await context.NewPageAsync();

            
            _scenarioContext["Browser"] = _browser;
            _scenarioContext["Page"] = _page;
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync();
            }
        }
    }
}