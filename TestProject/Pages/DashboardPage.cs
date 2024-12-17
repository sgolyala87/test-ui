using Microsoft.Playwright;


namespace TestProject.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly ILocator _messageLocator;
        public DashboardPage(IPage page) : base(page)
        {
            _messageLocator = page.GetByRole(AriaRole.Heading,new() {  Name = "Logged In Successfully"});
        }

            public async Task AssertDashboardMessage()
            {
                await Assertions.Expect(_messageLocator).ToBeVisibleAsync();
            }
        }
    } 
