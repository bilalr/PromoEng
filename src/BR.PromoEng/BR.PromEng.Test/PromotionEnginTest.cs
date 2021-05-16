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

            var result = PromotionEngine.RunPromotions(cart);

            // Assert

            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void ZeroPromotionAndManySKUTest()
        {
            //Arrange
            var cart = new Cart()
            {
                SKUs = new List<SKU>()
                {
                    new SKU(){ID='A',Price=50},
                    new SKU(){ID='A',Price=50},
                    new SKU(){ID='A',Price=50},
                    new SKU(){ID='B',Price=30},

                },
                Promotions = new List<Promotion>()
                {

                    
                }
            };

            //Act

            var result = PromotionEngine.RunPromotions(cart);

            // Assert

            Assert.AreEqual(180, result);
        }


        [TestMethod]
        public void DifferentPromotionDifferentSUKTestB()
        {
            //Arrange
            var cart = new Cart()
            {
                SKUs = new List<SKU>()
                {
                    new SKU(){ID='B',Price=30},
                    
                },
                Promotions = new List<Promotion>()
                {
                    new  IndividualSKU(){ NoOfItems=3, SKUId='A', price=130, PromotionType= PromotionType.IndividualSKU}

                }
            };

            //Act

            var result = PromotionEngine.RunPromotions(cart);

            // Assert

            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void DifferentPromotionDifferentSUKTestA()
        {
            //Arrange
            var cart = new Cart()
            {
                SKUs = new List<SKU>()
                {
                    new SKU(){ID='A',Price=50},

                },
                Promotions = new List<Promotion>()
                {
                    new  IndividualSKU(){ NoOfItems=2, SKUId='B', price=45, PromotionType= PromotionType.IndividualSKU}

                }
            };

            //Act

            var result = PromotionEngine.RunPromotions(cart);

            // Assert

            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void OnePromotionAndOneSKUTest()
        {
            //Arrange
            var cart = new Cart()
            {
                SKUs = new List<SKU>()
                {
                    new SKU(){ID='A',Price=50},

                },
                Promotions = new List<Promotion>()
                {
                   new IndividualSKU(){ NoOfItems =3, SKUId='A', price=130, PromotionType= PromotionType.IndividualSKU},

                }
            };

            //Act

            var result = PromotionEngine.RunPromotions(cart);

            // Assert

            Assert.AreEqual(50, result);
        }

    }
}
