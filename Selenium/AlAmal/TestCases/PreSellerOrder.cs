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
    public class PreSellerOrder : Base
    {

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(nameof(PreSellerOrderData))]
        public void CreatePreSellerOrder(string customercode, string deliverydate, string itemcode1,
                string qtycase1, string qtypcs1, string itemcode2,
                string qtycase2, string qtypcs2)
        {
            PreSellerOrderPage preSellerOrderPage = new PreSellerOrderPage(driver);
            preSellerOrderPage.NavigateToPresellerOrder();
            preSellerOrderPage.PresellerOrder(customercode, deliverydate);
            preSellerOrderPage.AddItem(itemcode1, qtycase1, qtypcs1);
            preSellerOrderPage.AddItem(itemcode2, qtycase2, qtypcs2);

            // preSellerOrderPage.DeleteItem();
            preSellerOrderPage.PlaceOrder();
            //preSellerOrderPage.ApproveOrder();

            //int actualrows = preSellerOrderPage.VerifyFARowCount();  
            //Verify if row count increased by 1
            // Assert.That(actualrows, Is.GreaterThan(1));

        }

        //Developed by Ramakrishna G

        [Test]
        [TestCaseSource(nameof(PreSellerOrderWithPromotionData))]
        public void PreSellerOrderWithPromotion(string customercode, string deliverydate, string itemcode1,
                string qtycase1, string qtypcs1)
        {
            PreSellerOrderPage preSellerOrderPage = new PreSellerOrderPage(driver);
            preSellerOrderPage.NavigateToPresellerOrder();
            preSellerOrderPage.PresellerOrderWithPromotion(customercode, deliverydate);
            preSellerOrderPage.AddItem(itemcode1, qtycase1, qtypcs1);
            //preSellerOrderPage.AddItem(itemcode2, qtycase2, qtypcs2);


            // preSellerOrderPage.DeleteItem();
            preSellerOrderPage.PlaceOrderWithPromotion();
            //preSellerOrderPage.ApproveOrder();

            //int actualrows = preSellerOrderPage.VerifyFARowCount();  
            //Verify if row count increased by 1
            // Assert.That(actualrows, Is.GreaterThan(1));
            //Console.WriteLine("Order inserted succussfully");
            //test.Info("Order inserted successfully");

        }




        public static IEnumerable<TestCaseData> PreSellerOrderData()
        {
            yield return new TestCaseData("96600047", "Nov 17, 2023", "86019", "10", "2", "89110", "5", "1");
        }

        public static IEnumerable<TestCaseData> PreSellerOrderWithPromotionData()
        {
            yield return new TestCaseData("96610401", "Nov 17, 2023", "588383", "0", "5");

        }



    }
}
