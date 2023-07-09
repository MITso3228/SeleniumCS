/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using NUnit.Framework.Internal;
using SeleniumCS.Pages;

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
