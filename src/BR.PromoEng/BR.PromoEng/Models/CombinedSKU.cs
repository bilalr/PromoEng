using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BR.PromoEng.Models
{
    /// <summary>
    /// Promotion type
    /// </summary>
    public class CombinedSKU : Promotion
    {
        public List<char> SKUIds { get; set; }

    }
}
