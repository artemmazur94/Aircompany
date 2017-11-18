using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SectorMap : EntityTypeConfiguration<Sector>
    {
        public SectorMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Plane).WithMany(x => x.Sectors).HasForeignKey(x => x.PlaneId);
            HasRequired(x => x.SeatTypeClass).WithMany(x => x.Sectors).HasForeignKey(x => x.SeatTypeId);
        }
    }
}