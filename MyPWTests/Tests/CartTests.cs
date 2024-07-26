using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

using MyPWTests.PageObject;

namespace MyPWTests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("CartTests")]

public class CartTests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    private CartPage _cartPage;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 1000 });
        _page = await _browser.NewPageAsync();

        _cartPage = new CartPage(_page);
    }

    [TearDown]
    public async Task Teardown()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    [Description("Add item to cart")]
    public async Task TestAddToCart()
    {
        await _cartPage.AddToCart();
    }
}
