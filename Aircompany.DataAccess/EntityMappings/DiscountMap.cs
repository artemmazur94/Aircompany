using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class DiscountMap : EntityTypeConfiguration<Discount>
    {
        public DiscountMap()
        {
            HasKey(x => x.Id);
        }
    }
}