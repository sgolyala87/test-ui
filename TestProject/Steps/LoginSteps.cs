using Microsoft.Playwright;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestProject.Pages;
using TestProject.Setup;

namespace TestProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly LoginPage _loginPage;
        private readonly IBrowser _browser;
        private readonly IPage _page;
        private readonly Config _config;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _page = _scenarioContext["Page"] as IPage;
            _loginPage = new LoginPage(_page);
            _config = ConfigReader.GetConfig();
        }

        [Given(@"I navigate to login page")]
        public async Task GivenINavigateToLoginPage()
        {
            await _page.GotoAsync(_config.BaseUrl + "/practice-test-login");
        }

        [When(@"I enter valid credentials")]
        public async Task WhenIEnterValidCredentials()
        {
            await _loginPage.EnterUsername(_config.Username);
            await _loginPage.EnterPassword(_config.Password);
        }

        [When(@"I click on Submit button")]
        public async Task WhenIClickOnSubmitButton()
        {
            await _loginPage.ClickSubmitButton();
        }

        [Then(@"I should redirected to the dashboard")]
        public void ThenIShouldRedirectedToTheDashboard()
        {
            Assert.Equal("https://practicetestautomation.com/logged-in-successfully/", _page.Url);
        }


        [When(@"I enter invalid (.*) (.*)")]
        public async Task WhenIEnterInvalidIncorrectUserPassword(string username,string password)
        {
            await _loginPage.EnterUsername(username);
            await _loginPage.EnterPassword(password);
        }

        [Then(@"I should see an (.*)")]
        public async void ThenIShouldSeeAnYourUsernameIsInvalid(string expectedErrorMessage)
        {
            string actualErrorMessage = await _loginPage.GetErrorMessage();
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
    }
}
