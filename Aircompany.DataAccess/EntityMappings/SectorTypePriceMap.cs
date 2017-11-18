using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SectorTypePriceMap : EntityTypeConfiguration<SectorTypePrice>
    {
        public SectorTypePriceMap()
        {
            HasKey(x => new {x.SeatTypeId, x.SeanceId});

            HasRequired(x => x.Seance).WithMany(x => x.SectorTypePrices).HasForeignKey(x => x.SeanceId);
            HasRequired(x => x.SeatTypeClass).WithMany(x => x.SectorTypePrices).HasForeignKey(x => x.SeatTypeId);
        }
    }
}