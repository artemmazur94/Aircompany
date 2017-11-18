using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PlaneMap : EntityTypeConfiguration<Plane>
    {
        public PlaneMap()
        {
            HasKey(x => x.Id);

            HasOptional(x => x.Photo).WithMany(x => x.Planes).HasForeignKey(x => x.PhotoId);
        }
    }
}