using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrendyolCase.Business.Models;
using TrendyolCase.Business.Enums;

namespace TrendyolCaseUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Category category1 = new Category("Category 1");
            Product prodcut1 = new Product("Prodcut 1", 100, category1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 1, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(100, deliveryCost);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Category category1 = new Category("Category 1");
            Product prodcut1 = new Product("Prodcut 1", 100, category1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 10, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(990, deliveryCost);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Campaign cmp1 = new Campaign
            {
                DiscountScope = DiscountScope.Both,
                Discount = 100,
                MinimumPriceAmount = 200,
                MinimumProdcutCount = 10
            };

            Category category1 = new Category("Category 1");

            Product prodcut1 = new Product("Prodcut 1", 100, category1, cmp1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 10, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(890, deliveryCost);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Campaign cmp1 = new Campaign
            {
                DiscountScope = DiscountScope.PriceAmount,
                Discount = 100,
                MinimumPriceAmount = 200,
                MinimumProdcutCount = 10
            };

            Category category1 = new Category("Category 1");

            Product prodcut1 = new Product("Prodcut 1", 100, category1, cmp1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 10, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(890, deliveryCost);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Campaign cmp1 = new Campaign
            {
                DiscountScope = DiscountScope.ProductCount,
                Discount = 100,
                MinimumPriceAmount = 200,
                MinimumProdcutCount = 10
            };

            Category category1 = new Category("Category 1");

            Product prodcut1 = new Product("Prodcut 1", 100, category1, cmp1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 10, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(890, deliveryCost);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Campaign cmp1 = new Campaign
            {
                DiscountScope = DiscountScope.ProductCount,
                Discount = 100,
                MinimumPriceAmount = 200,
                MinimumProdcutCount = 10
            };

            Category category1 = new Category("Category 1", cmp1);

            Product prodcut1 = new Product("Prodcut 1", 100, category1);
            Coupon coupon1 = new Coupon
            {
                Discount = 10,
                MinimumPriceAmount = 300
            };

            Cart cart1 = new Cart(prodcut1, 10, coupon1);

            decimal deliveryCost = cart1.CalculateDeliveryCost();

            Assert.AreEqual(890, deliveryCost);
        }
    }
}
