using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SeatTypeMap : EntityTypeConfiguration<SeatTypeClass>
    {
        public SeatTypeMap()
        {
            HasKey(x => x.Id);
        }
    }
}