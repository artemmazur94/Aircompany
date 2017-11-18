using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class ExternalAccountMap : EntityTypeConfiguration<ExternalAccount>
    {
        public ExternalAccountMap()
        {
            HasKey(x => new {x.ExternalProviderId, x.UserIdentity});

            HasRequired(x => x.Profile).WithMany(x => x.ExternalAccounts).HasForeignKey(x => x.ProfileId);
            HasRequired(x => x.ExternalProvider).WithMany(x => x.ExternalAccounts).HasForeignKey(x => x.ExternalProviderId);
        }
    }
}