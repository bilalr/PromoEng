using BR.PromoEng.Models;
using System;
using System.Linq;

namespace BR.PromoEng
{
    public class PromotionEngine
    {


        public static decimal RunPromotions (Cart cart)
        {
            if (!(cart.Promotions.Count() > 0))
            {
                return cart.SKUs.Sum(x => x.Price);
            }

            //Variable declarations 
            decimal totalAmount = 0;
            int noOfA = cart.SKUs.Count(x => x.ID == 'A' || x.ID == 'a');
            decimal priceOfA = cart.SKUs.Where(x => x.ID == 'A' || x.ID == 'a').Select(x => x.Price).FirstOrDefault();
            int noOfB = cart.SKUs.Count(x => x.ID == 'B' || x.ID == 'b');
            decimal priceOfB = cart.SKUs.Where(x => x.ID == 'B' || x.ID == 'b').Select(x => x.Price).FirstOrDefault();
            int noOfC = cart.SKUs.Count(x => x.ID == 'C' || x.ID == 'c');
            decimal priceOfC = cart.SKUs.Where(x => x.ID == 'C' || x.ID == 'c').Select(x => x.Price).FirstOrDefault();
            int noOfD = cart.SKUs.Count(x => x.ID == 'D' || x.ID == 'd');
            decimal priceOfD = cart.SKUs.Where(x => x.ID == 'D' || x.ID == 'd').Select(x => x.Price).FirstOrDefault();
            decimal totalPriceOfA = 0;
            decimal totalPriceOfB = 0;
            decimal totalPriceOfC = 0;
            decimal totalPriceOfD = 0;
            decimal totalprice = 0;


            //looping all promotions and run thier rules.

            foreach (var item in cart.Promotions.OrderBy(x => x.PromotionType))
            {
                switch (item.PromotionType)
                {
                    //IndivualSKU promotion type
                    case PromotionType.IndividualSKU:
                        var individualSKU = (IndividualSKU)item;
                        if (individualSKU.SKUId == 'A' || individualSKU.SKUId == 'a')
                        {
                            if (noOfA >= individualSKU.NoOfItems)
                            {
                                totalPriceOfA = ((noOfA / individualSKU.NoOfItems) * individualSKU.price) + (noOfA % individualSKU.NoOfItems * priceOfA);

                            }
                            else
                            {
                                totalPriceOfA = noOfA * priceOfA;

                            }
                            noOfA = 0;
                            totalprice = +totalPriceOfA;

                        }
                        else if (individualSKU.SKUId == 'B' || individualSKU.SKUId == 'b')
                        {
                            if (noOfB >= individualSKU.NoOfItems)
                            {
                                totalPriceOfB = ((noOfB / individualSKU.NoOfItems) * individualSKU.price) + (noOfB % individualSKU.NoOfItems * priceOfB);
                            }
                            else
                            {
                                totalPriceOfB = noOfB * priceOfB;
                            }
                            noOfB = 0;
                            totalprice += totalPriceOfB;
                        }
                        else if (individualSKU.SKUId == 'C' || individualSKU.SKUId == 'c')
                        {
                            if (noOfC >= individualSKU.NoOfItems)
                            {
                                totalPriceOfC = ((noOfC / individualSKU.NoOfItems) * individualSKU.price) + (noOfC % individualSKU.NoOfItems * priceOfC);
                            }
                            else
                            {
                                totalPriceOfC = noOfC * priceOfC;
                            }
                            noOfC = 0;
                            totalprice += totalPriceOfC;

                        }
                        else if (individualSKU.SKUId == 'D' || individualSKU.SKUId == 'd')
                        {
                            if (noOfD >= individualSKU.NoOfItems)
                            {
                                totalPriceOfD = ((noOfD / individualSKU.NoOfItems) * individualSKU.price) + (noOfD % individualSKU.NoOfItems * priceOfD);
                            }
                            else
                            {
                                totalPriceOfD = noOfD * priceOfD;

                            }
                            noOfD = 0;
                            totalprice += totalPriceOfD;

                        }
                        break;
                  

                       
                    default:
                        break;


                }


            }


            // add remaing SKU which are note consider in above promoitons loop.
            if (noOfA != 0)
            {
                totalprice += noOfA * priceOfA;
                noOfA = 0;
            }
            if (noOfB != 0)
            {
                totalprice += noOfB * priceOfB;
                noOfB += 0;
            }
            if (noOfC != 0)
            {
                totalprice += noOfC * priceOfC;
                noOfC += 0;
            }

            if (noOfD != 0)
            {
                totalprice += noOfD * priceOfD;
                noOfD += 0;
            }
            return totalprice;
        }

    }
}
