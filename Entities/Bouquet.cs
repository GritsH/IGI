using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953505_Grits.Entities;

namespace WEB_953505_Grits.Entities
{
    public class Bouquet
    {
        public int BouquetId { get; set; }
        public string BouquetName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int BouquetGroupId { get; set; }
        public BouquetGroup Group { get; set; }
    }
}
