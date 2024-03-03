using ArlaFunctionalTests.PageObjects;
using ArlaFunctionalTests.TestData;
using ArlaFunctionalTests.TestSetup;
using ArlaFunctionalTests.TestUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArlaFunctionalTests.TestCases
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
