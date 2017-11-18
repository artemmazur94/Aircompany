using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Profile).WithMany(x => x.Accounts).HasForeignKey(x => x.ProfileId);
        }
    }
}