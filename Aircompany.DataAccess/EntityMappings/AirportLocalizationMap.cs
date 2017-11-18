using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class AirportLocalizationMap : EntityTypeConfiguration<AirportLocalization>
    {
        public AirportLocalizationMap()
        {
            HasKey(x => new {x.AirportId, x.LanguageId});

            HasRequired(x => x.Language).WithMany(x => x.AirportLocalizations).HasForeignKey(x => x.LanguageId);
            HasRequired(x => x.Airport).WithMany(x => x.AirportLocalizations).HasForeignKey(x => x.AirportId);
        }
    }
}