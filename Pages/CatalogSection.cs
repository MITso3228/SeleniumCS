using OpenQA.Selenium;
using SeleniumCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
