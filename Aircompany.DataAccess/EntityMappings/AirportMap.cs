using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class AirportMap : EntityTypeConfiguration<Airport>
    {
        public AirportMap()
        {
            HasKey(x => x.Id);

            HasOptional(x => x.Photo).WithMany(x => x.Airports).HasForeignKey(x => x.PhotoId);
        }
    }
}