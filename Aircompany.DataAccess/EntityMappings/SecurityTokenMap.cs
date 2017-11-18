using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SecurityTokenMap : EntityTypeConfiguration<SecurityToken>
    {
        public SecurityTokenMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Account).WithMany(x => x.SecurityTokens).HasForeignKey(x => x.AccountId);
        }
    }
}