using ArlaFunctionalTests.PageObjects;
using ArlaFunctionalTests.TestSetup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArlaFunctionalTests.TestCases
{

    public class PreSellerReturnOrder : Base
    {


        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(nameof(PreSellerReturnOrderData))]
        public void CreatePreSellerReturnOrder(string customercode, string pickupdate, string customerrefdate, string itemcode1,
                string quantity1, string reasontype1, string returnreason1, string itemcode2, string quantity2, string reasontype2,
                string returnreason2, string itemcode3, string quantity3, string reasontype3, string returnreason3)
        {
            PreSellerReturnOrderPage preSellerReturnOrderPage = new PreSellerReturnOrderPage(driver);
            preSellerReturnOrderPage.NavigateToPresellerReturnOrder();
            preSellerReturnOrderPage.PresellerReturnOrder(customercode, pickupdate, customerrefdate);
            preSellerReturnOrderPage.AddItem(itemcode1);
            preSellerReturnOrderPage.EnterItem1Data(quantity1, reasontype1, returnreason1);
            preSellerReturnOrderPage.AddItem(itemcode2);
            preSellerReturnOrderPage.EnterItem2Data(quantity2, reasontype2, returnreason2);
            preSellerReturnOrderPage.AddItem(itemcode3);
            preSellerReturnOrderPage.EnterItem3Data(quantity3, reasontype3, returnreason3);
            preSellerReturnOrderPage.DeleteItem();
            preSellerReturnOrderPage.ConfirmOrder();
            //preSellerReturnOrderPage.ApproveOrder();

            //int actualrows = preSellerReturnOrderPage.VerifyFARowCount();  
            //Verify if row count increased by 1
            // Assert.That(actualrows, Is.GreaterThan(1));
            //Console.WriteLine("Order inserted succussfully");
            //test.Info("Order inserted successfully");

        }




        public static IEnumerable<TestCaseData> PreSellerReturnOrderData()
        {
            yield return new TestCaseData("96600047", "Oct 17, 2023", "Oct 17, 2023", "991450", "1", "Expiry", "Leakages", "990139", "2", "Damage", "Color Change", "991449", "3", "Good Return", "Damage");
        }

       




    }

}
