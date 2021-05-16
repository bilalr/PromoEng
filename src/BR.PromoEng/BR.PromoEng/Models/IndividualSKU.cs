using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BR.PromoEng.Models
{
    public class IndividualSKU  : Promotion
    {
        public int NoOfItems { get; set; }
        public char SKUId { get; set; }

     }
}
