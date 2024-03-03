using AlAmalFunctionalTests.PageObjects;
using AlAmalFunctionalTests.TestSetUp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlAmalFunctionalTests.TestCases
{
    public class ItemReleated : Base
    {
        [Test]
        [TestCaseSource(nameof(ImportVanstockData))]
        public void ImportVanstock(string filename)
        {
            ImportVanstockPage importVanstockPage = new ImportVanstockPage(driver);
            importVanstockPage.NavigateToImportVanstock();
            importVanstockPage.ImportVanstockfile(filename);
        }

        public static IEnumerable<TestCaseData> ImportVanstockData()
        {
            yield return new TestCaseData("ImportVanstock");

        }

    }
}
