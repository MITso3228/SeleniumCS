/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using OpenQA.Selenium;
using SeleniumCS.Helpers;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCS.Pages
{
    public class SearchResultsPage : BasePage
    {
        private By allCategoriesExpandButton => By.CssSelector("[class='button button_type_link categories-filter__toggle']");
        private By sortTypeDropDown = By.ClassName("select-css");
        private By productPrice = By.ClassName("goods-tile__price-value");

        public SearchResultsPage(IWebDriver driver, Logging logger) : base(driver, logger) { }

        public void WaitForLoading()
        {
            WaitAndFind(allCategoriesExpandButton);
        }

        public void ExpandAllCategories()
        {
            Click(allCategoriesExpandButton);
        }
            
        public void ExpandAllSubcategories()
        {
            var elements = Driver.FindElements(By.CssSelector(".button.button_type_link.categories-filter__toggle.ng-star-inserted"));
            foreach (var el in elements)
            {
                el.Click();
            }

            Logger.Info("Expanded all Subcategoties");
        }

        public string getSumForSubcategories()
        {
            var elements = Driver.FindElements(By.CssSelector(".categories-filter__link .sidebar-block__quantity.ng-star-inserted"));
            int sum = 0;
            foreach (var el in elements)
            {
                if (el.Displayed)
                {
                    sum += int.Parse(Regex.Match(el.Text, @"\d+").Value);
                }
            }

            return sum.ToString();
        }

        public string getTotalAmountResults()
        {
            var el = Driver.FindElement(By.CssSelector("[class=sidebar-block__quantity]"));
            int total = int.Parse(Regex.Match(el.Text, @"\d+").Value);

            return total.ToString();
        }

        public void SortResults(string sortType)
        {
            var el = Driver.FindElement(sortTypeDropDown);
            var selectElement = new SelectElement(el);

            selectElement.SelectByText(sortType);

            Thread.Sleep(1500);
        }

        public List<int> getProductsPrice()
        {
            var elements = Driver.FindElements(productPrice);
            List<int> array = new();
            foreach (var el in elements)
            {
                int price = int.Parse(Regex.Match(el.Text.Replace(" ", String.Empty), @"\d+").Value);
                array.Add(price);
            }

            Logger.Info($"Got price for products: {string.Join(" | ", array.ToArray())}");

            return array;
        }

        public bool CheckForSorting(List<int> sortedList, string sortOrder)
        { 
            if (sortOrder == "descending")
            {
                for (int i = 0; i < sortedList.Count - 2; i++)
                {
                    if (sortedList[i] < sortedList[i + 1])
                    {
                        return false;
                    }
                }
            } else if (sortOrder == "ascending")
            {
                for (int i = 0; i < sortedList.Count - 2; i++)
                {
                    if (sortedList[i] > sortedList[i + 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
