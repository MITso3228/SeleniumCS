/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using SeleniumCS.Pages;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Catalog Section Tests")]
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
