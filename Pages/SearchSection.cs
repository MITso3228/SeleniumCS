/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using OpenQA.Selenium;
using SeleniumCS.Helpers;

namespace SeleniumCS.Pages
{
    internal class SearchSection : BasePage
    {
        private By searchTextBox => By.Name("search");
        private By searchResults => By.CssSelector(".search-suggest__item-content.search-suggest__item-text");
        private By searchButton => By.ClassName("search-form__submit");

        public SearchSection(IWebDriver driver, Logging logger) : base(driver, logger) { }

        public void InputText(string text)
        {
            SetText(searchTextBox, text);
        }

        public List<string> GetResults()
        {
            var searchResultStart = By.CssSelector(".search-suggest__item-content.search-suggest__item-text span:not(.caption)");
            WaitAndFind(searchResults);
            var elements = Driver.FindElements(searchResults);
            List<string> array = new();
            foreach (var el in elements)
            {
                string resultStart = el.Text.Replace(System.Environment.NewLine, " ");
                array.Add(resultStart);
            }
            Logger.Info($"Got search results: {string.Join(" | ", array.ToArray())}");
            return array;
        }

        public void ClickSearch()
        {
            Click(searchButton);
        }
    }
}
