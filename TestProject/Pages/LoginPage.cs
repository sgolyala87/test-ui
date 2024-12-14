using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        private const string UsernameInput = "#username";
        private const string PasswordInput = "#password";
        private const string SubmitButton = "#submit";
        private const string ErrorMessage = "#error";

        
        public async Task EnterUsername(string username) =>
            await _page.FillAsync(UsernameInput, username.Trim());

        public async Task EnterPassword(string password) =>
            await _page.FillAsync(PasswordInput, password);

        public async Task ClickSubmitButton() =>
            await _page.ClickAsync(SubmitButton);

        public async Task<string> GetErrorMessage() =>
          await _page.TextContentAsync(ErrorMessage);
    }
}
