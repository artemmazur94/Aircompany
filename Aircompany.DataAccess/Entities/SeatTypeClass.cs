using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class SeatTypeClass
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Sector> Sectors { get; set; }
        public virtual ICollection<SectorTypePrice> SectorTypePrices { get; set; }
    }
}
