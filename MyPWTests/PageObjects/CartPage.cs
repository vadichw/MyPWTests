using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyPWTests.PageObject
{
    public class CartPage
    {
        private readonly IPage _page;
        private readonly LoginPage _loginPage;

        private ILocator AddToCartClick => _page.Locator("#add-to-cart-sauce-labs-backpack");

        public CartPage(IPage page)
        {
            _page = page;
            _loginPage = new LoginPage(page);
        }

        public async Task AddToCart()
        {
            await _loginPage.GoToMainPage();
            await _loginPage.LoginAsync("standard_user", "secret_sauce");
            await AddToCartClick.ClickAsync();
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
    }
}

