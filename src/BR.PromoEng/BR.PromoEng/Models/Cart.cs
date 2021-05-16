using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BR.PromoEng.Models
{
    public class Cart
    {
        public List<SKU> SKUs { get; set; }
        public List<Promotion> Promotions { get; set; }

    }
}
