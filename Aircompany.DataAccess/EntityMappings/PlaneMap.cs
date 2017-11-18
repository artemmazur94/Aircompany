using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PlaneMap : EntityTypeConfiguration<Plane>
    {
        public PlaneMap()
        {
            HasKey(x => x.Id);
        }
    }
}