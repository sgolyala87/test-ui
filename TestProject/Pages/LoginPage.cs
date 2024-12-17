using Microsoft.Playwright;
using TestProject.Setup;

namespace TestProject.Pages
{
    public class LoginPage : BasePage
    {
        private readonly ILocator _usernameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _submitButton;
        private readonly ILocator _errorMessage;
        private readonly Config _config;

        public LoginPage(IPage page) :base(page) 
        {
            _usernameInput = page.Locator("#username");
            _passwordInput = page.Locator("#password");
            _submitButton = page.Locator("#submit");
            _errorMessage = page.Locator("#error");
            _config = ConfigReader.GetConfig();
        }

        public async Task Load()
        {
            await Page.GotoAsync(_config.BaseUrl + "/practice-test-login");
        }

        public async Task EnterUsername(string username)
        {
            await Assertions.Expect(_usernameInput).ToBeVisibleAsync();
            await _usernameInput.FillAsync(username.Trim());
        }

        public async Task EnterPassword(string password)
        {
            await _passwordInput.FillAsync(password);
        }

        public async Task ClickSubmitButton()
        {
            await _submitButton.ClickAsync();
        }

        public async Task AssertErrorMessage(string message)
        {
            await Assertions.Expect(_errorMessage).ToHaveTextAsync(message);
        }
    }
}
