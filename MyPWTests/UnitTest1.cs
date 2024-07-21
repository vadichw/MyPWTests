using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace MyPWTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IPage _page;

        [SetUp]
        public async Task SetUp()
        {
            _playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _page = await _browser.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }

        [Test]
        [Description("Test check page title")]
        public async Task HasTitle()
        {
            // Open Main page
            await _page.GotoAsync("https://www.saucedemo.com/");

            // Check page title
            string actualTitle = await _page.TitleAsync();
            string expectedTitle = "Swag Labs";
            Assert.That(actualTitle, Is.EqualTo(expectedTitle));

            if (expectedTitle == actualTitle)
            {
                Console.WriteLine("It's the correct title.");
            }
            else
            {
                Console.WriteLine($"It's the incorrect title. Found title is {actualTitle}");

            }
        }
    }
}
