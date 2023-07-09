using NUnit.Framework;
using SeleniumCS.Pages;
using SeleniumCS.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SeleniumCS.Tests
{
    [TestFixture, Category("Search Tests")]
    internal class SearchSectionTest : Setup
    {
        // 1. Type the word “Samsu” in Search input
        // 2. Verify that the "Search Results" popup visible contains words that all start with “Samsu”
        [Test]
        public void CheckSearch()
        {
            SearchSection searchSection = new(driver, logger);
            var searchText = "Samsu";

            searchSection.InputText(searchText);

            foreach (var result in searchSection.GetResults())
            {
                Match match = Regex.Match(result, $@"^{searchText}", RegexOptions.IgnoreCase);
                Assert.That(match.Success, Is.True);
            }
        }
    }
}
