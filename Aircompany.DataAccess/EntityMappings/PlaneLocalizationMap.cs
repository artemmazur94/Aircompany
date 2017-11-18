using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class PlaneLocalizationMap : EntityTypeConfiguration<PlaneLocalization>
    {
        public PlaneLocalizationMap()
        {
            HasKey(x => new {x.LanguageId, x.PlaneId});

            HasRequired(x => x.Language).WithMany(x => x.PlaneLocalizations).HasForeignKey(x => x.LanguageId);
            HasRequired(x => x.Plane).WithMany(x => x.PlaneLocalizations).HasForeignKey(x => x.PlaneId);
        }
    }
}