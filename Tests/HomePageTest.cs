using OpenQA.Selenium;
using SeleniumCS.Pages;
using System.Net.Http.Headers;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Home Page Tests")]
    public class HomePageTest : Setup
    {
        // Check that the price of products in the section "Акційні пропозиції" is indicated in accordance currency UAH.
        [Test]
        public void CheckCurrencySignForPromotionalOffersSection()
        {
            HomePage homePage = new(driver, logger);
            var section = "Акційні пропозиції";
            var uah_currency = "₴";

            homePage.ScrollToSection(section);
            homePage.ExpandSection(section);
 
            foreach(var currency in homePage.GetCurrencyForProductsInSection(section))
            {
                Assert.That(currency, Is.EqualTo(uah_currency));
            }
        }
    }
}