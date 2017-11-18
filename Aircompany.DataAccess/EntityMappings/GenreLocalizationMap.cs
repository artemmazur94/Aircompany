using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class GenreLocalizationMap : EntityTypeConfiguration<GenreLocalization>
    {
        public GenreLocalizationMap()
        {
            HasKey(x => new {x.GenreId, x.LanguageId});

            HasRequired(x => x.Language).WithMany(x => x.GenreLocalizations).HasForeignKey(x => x.LanguageId);
            HasRequired(x => x.Genre).WithMany(x => x.GenreLocalizations).HasForeignKey(x => x.GenreId);
        }
    }
}