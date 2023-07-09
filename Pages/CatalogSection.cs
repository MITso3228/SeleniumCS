/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using OpenQA.Selenium;
using SeleniumCS.Helpers;

namespace SeleniumCS.Pages
{
    internal class CatalogSection : BasePage
    {
        private By catalog = By.CssSelector(".menu-wrapper.menu-wrapper_state_animated");
        private By catalogButton = By.Id("fat-menu");

        public CatalogSection(IWebDriver driver, Logging logger) : base(driver, logger) { }

        internal bool IsPopupDisplayed()
        {
            try { return Driver.FindElement(catalog).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void ClickCatalogButton()
        {
            WaitAndFind(catalogButton);
            Click(catalogButton);
        }
    }
}
