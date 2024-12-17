using TechTalk.SpecFlow;
using TestProject.Pages;
using TestProject.Setup;

namespace TestProject.Steps
{
    [Binding]
    public class LoginSteps
    {
        
        private readonly LoginPage _loginPage;
        private readonly DashboardPage _dashboardPage;
        private readonly Config _config;

        public LoginSteps(DashboardPage dashboardPage,LoginPage loginPage)
        {
           
            _loginPage = loginPage;
            _dashboardPage = dashboardPage;
            _config = ConfigReader.GetConfig();
        }

        [Given(@"I navigate to login page")]
        public async Task GivenINavigateToLoginPage()
        {
            await _loginPage.Load();
            
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
        public async Task ThenIShouldRedirectedToTheDashboard()
        {
            await _dashboardPage.AssertDashboardMessage();
        }


        [When(@"I enter invalid (.*) (.*)")]
        public async Task WhenIEnterInvalidIncorrectUserPassword(string username,string password)
        {
            await _loginPage.EnterUsername(username);
            await _loginPage.EnterPassword(password);
        }

        [Then(@"I should see an (.*)")]
        public async Task ThenIShouldSeeAnYourUsernameIsInvalid(string expectedErrorMessage)
        {
            await _loginPage.AssertErrorMessage(expectedErrorMessage);
            
        }
    }
}
