using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class ExternalProviderMap : EntityTypeConfiguration<ExternalProvider>
    {
        public ExternalProviderMap()
        {
            HasKey(x => x.Id);
        }
    }
}