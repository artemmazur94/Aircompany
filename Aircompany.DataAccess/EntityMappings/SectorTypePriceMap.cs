using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SectorTypePriceMap : EntityTypeConfiguration<SectorTypePrice>
    {
        public SectorTypePriceMap()
        {
            HasKey(x => new {x.SeatTypeId, x.FlightId});

            HasRequired(x => x.Flight).WithMany(x => x.SectorTypePrices).HasForeignKey(x => x.FlightId);
            HasRequired(x => x.SeatTypeClass).WithMany(x => x.SectorTypePrices).HasForeignKey(x => x.SeatTypeId);
        }
    }
}