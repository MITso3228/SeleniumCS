/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using OpenQA.Selenium;
using SeleniumCS.Helpers;

namespace SeleniumCS.Pages
{
    public class HomePage : BasePage
    {
        private static Uri HomePageUrl => new("https://rozetka.com.ua/");

        public HomePage(IWebDriver driver, Logging logger) : base(driver, logger) { }

        internal void GoToPage()
        {
            Driver.Navigate().GoToUrl(HomePageUrl);

            Logger.Info($"Navigated to {HomePageUrl}");
        }

        public void ScrollToSection(string sectionName)
        {
            var el = WaitAndFind(By.XPath($"//*[contains(text(), '{sectionName}')]"));
            ((IJavaScriptExecutor)Driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", el);

            Logger.Info($"Scrolled to {sectionName}");
        }

        public void ExpandSection(string sectionName) => Click(By.XPath($"//*[contains(text(), '{sectionName}')]/..//*[contains(@class, \"main-goods__show-more\")]"));

        public List<string> GetCurrencyForProductsInSection(string sectionName)
        {
            var elements = Driver.FindElements(By.XPath($"//*[contains(text(), '{sectionName}')]/..//*[contains(@class, \" currency\")]"));
            List<string> array = new();
            foreach (var el in elements)
            {
                string currency = el.Text;
                array.Add(currency);
            }

            Logger.Info($"Got currencies for products in {sectionName}: {string.Join(" | ", array.ToArray())}");

            return array;
        }
    }
}
