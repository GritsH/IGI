using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953505_Grits.Entities
{
    public class BouquetGroup
    {
        public int BouquetGroupId { get; set; }
        public string GroupName { get; set; }
        public List<Bouquet> Bouquets { get; set; }
    }
}
