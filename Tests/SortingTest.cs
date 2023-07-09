﻿using SeleniumCS.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Sorting Tests")]
    public class SortingTest : Setup
    {
        // 1. Navigate to PLP page (by searching any product or by url)
        // 2. Set sorting to "high to low."
        // 3. Check that the products are sorted by price.
        [Test]
        public void CheckSorting()
        {
            SearchSection searchSection = new(driver, logger);
            SearchResultsPage searchResultsPage = new(driver, logger);
            var searchText = "Samsu";
            var sortType = "Від дорогих до дешевих";

            searchSection.InputText(searchText);
            searchSection.ClickSearch();

            searchResultsPage.WaitForLoading();
            searchResultsPage.SortResults(sortType);

            var sorted = searchResultsPage.CheckForSorting(searchResultsPage.getProductsPrice(), "descending");

            Assert.That(sorted, Is.True);
        }
    }
}
