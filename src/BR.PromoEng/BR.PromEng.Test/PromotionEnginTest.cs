using BR.PromoEng;
using BR.PromoEng.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BR.PromEng.Test
{
    [TestClass]
    public class PromotionEnginTest
    {
        [TestMethod]
        public void ZeroPromotionAndzeroSKUTest()
        {
            //Arrange
            var cart = new Cart()
            {
                SKUs = new List<SKU>()
                {

                },
                Promotions = new List<Promotion>()
                {

                }
            };
            //Act

            var result = PromotionEngine.CalculatePromotions();

            // Assert

            Assert.AreEqual(0, result);
        }


    }
}
