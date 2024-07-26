using Microsoft.Playwright;
using System.Threading.Tasks;

namespace MyPWTests.PageObject
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator UserNameField => _page.Locator("#user-name");
        private ILocator PasswordField => _page.Locator("#password");
        private ILocator LoginButton => _page.Locator("#login-button");

        public async Task GoToMainPage()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }


        public async Task LoginAsync(string username, string password)
        {
            await UserNameField.FillAsync(username);
            await PasswordField.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}


