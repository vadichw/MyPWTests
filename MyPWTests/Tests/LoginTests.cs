using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

using MyPWTests.PageObject;

namespace MyPWTests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("LoginTests")]

public class LoginTests
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    private LoginPage _loginPage;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 1000 });
        _page = await _browser.NewPageAsync();

        _loginPage = new LoginPage(_page);
    }

    [TearDown]
    public async Task Teardown()
    {
        await _page.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }

    [Test]
    [Description("Enter login and password")]
    public async Task SignIn()
    {
        await _loginPage.GoToMainPage();
        await _loginPage.LoginAsync("standard_user", "secret_sauce");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }

    [Test]
    [Description("Enter invalid login and password")]
    public async Task InvalidSingIn()
    {
        await _loginPage.GoToMainPage();
        await _loginPage.LoginAsync("standard_user", "secret_sauc");
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
}
