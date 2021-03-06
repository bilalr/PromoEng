using BR.PromoEng.Models;
using System;
using System.Linq;

namespace BR.PromoEng
{
    /// <summary>
    /// This is a promotion engine class  which 
    /// gives functionality to runs promotions. runs all active promotions. 
    /// </summary>
    public class PromotionEngine
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
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

                    case PromotionType.CombinedSKU:

                        // Add logic to combined sku
                        var combinedSKU= (CombinedSKU)item;
                        var skuA = false;
                        var skuB = false;
                        var skuC = false;
                        var skuD = false;
                        int totalcombinedpromotionsCounter = 0;
                        foreach (var skuid in combinedSKU.SKUIds)
                        {
                            if (skuid == 'A' || skuid == 'a')
                            {
                                skuA = true;
                            }
                            else if (skuid == 'B' || skuid == 'b')
                            {
                                skuB = true;
                            }
                            else if (skuid == 'C' || skuid == 'c')
                            {
                                skuC = true;
                            }
                            else if (skuid == 'D' || skuid == 'd')
                            {
                                skuD = true;
                            }


                        }
                        //Combined promotion for A and B
                        if (skuA && skuB)
                        {

                            while (noOfA > 0 && noOfB > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfA--;
                                noOfB--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfA * priceOfA) + (noOfB * priceOfB);
                            noOfA = 0;
                            noOfB = 0;
                        }
                        //Combined promotion for A and C
                        else if (skuA && skuC)
                        {

                            while (noOfA > 0 && noOfC > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfA--;
                                noOfC--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfA * priceOfA) + (noOfC * priceOfC);
                            noOfA = 0;
                            noOfC = 0;
                        }//Combined promotion for A and D
                        else if (skuA && skuD)
                        {

                            while (noOfA > 0 && noOfD > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfA--;
                                noOfD--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfA * priceOfA) + (noOfD * priceOfD);
                            noOfA = 0;
                            noOfD = 0;
                        }//Combined promotion for C and C
                        else if (skuB && skuC)
                        {

                            while (noOfB > 0 && noOfC > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfB--;
                                noOfC--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfB * priceOfB) + (noOfC * priceOfC);
                            noOfB = 0;
                            noOfC = 0;
                        }//Combined promotion for B and D
                        else if (skuB && skuD)
                        {

                            while (noOfB > 0 && noOfD > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfB--;
                                noOfD--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfB * priceOfB) + (noOfD * priceOfD);
                            noOfB = 0;
                            noOfD = 0;


                        }//Combined promotion for C and D
                        else if (skuC && skuD)
                        {

                            while (noOfC > 0 && noOfD > 0)
                            {
                                totalcombinedpromotionsCounter++;
                                noOfC--;
                                noOfD--;

                            }

                            totalprice += (totalcombinedpromotionsCounter * combinedSKU.price) + (noOfC * priceOfC) + (noOfD * priceOfD);
                            noOfC = 0;
                            noOfD = 0;
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

            //Return final total price
            return totalprice;
        }

    }
}
