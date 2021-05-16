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
