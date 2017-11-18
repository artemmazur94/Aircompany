using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PhotoMap :EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            HasKey(x => x.Id);
        }
    }
}