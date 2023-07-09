using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumCS.Pages;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Catalog Tests")]
    public class CatalogSectionTest : Setup
    {
        // Toggle the button “Каталог” and ensure the popup is displayed.
        [Test]
        public void CheckCatalogPopupPositive()
        {
            CatalogSection catalogPopup = new(driver, logger);

            catalogPopup.ClickCatalogButton();

            Assert.That(catalogPopup.IsPopupDisplayed(), Is.True);
        }

        // Ensure popup “Каталог” is not visible by default.
        [Test]
        public void CheckCatalogPopupNegative()
        {
            CatalogSection catalogPopup = new(driver, logger);

            Assert.That(catalogPopup.IsPopupDisplayed(), Is.False);
        }
    }
}
