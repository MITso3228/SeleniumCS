/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using SeleniumCS.Pages;
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
