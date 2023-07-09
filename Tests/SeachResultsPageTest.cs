using NUnit.Framework.Internal;
using SeleniumCS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Search Results Page Tests")]
    public class SeachResultsPageTest : Setup
    {
        // 1. Search the word “Samsu”
        // 2. Ensure “Всі результати” quantity value is equal to a summarized value of quantities from all subsequent labels
        [Test]
        public void CheckProductQuantityInAllResults()
        {
            SearchSection searchSection = new(driver, logger);
            SearchResultsPage searchResultsPage = new(driver, logger);
            var searchText = "iPhon";

            searchSection.InputText(searchText);
            searchSection.ClickSearch();

            searchResultsPage.WaitForLoading();
            searchResultsPage.ExpandAllCategories();
            searchResultsPage.ExpandAllSubcategories();
            try
            {
                Assert.That(searchResultsPage.getSumForSubcategories(), Is.EqualTo(searchResultsPage.getTotalAmountResults()));
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                throw e;
            }
        }
    }
}
