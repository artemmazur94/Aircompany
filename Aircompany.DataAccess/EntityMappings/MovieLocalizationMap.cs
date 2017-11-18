using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class MovieLocalizationMap : EntityTypeConfiguration<MovieLocalization>
    {
        public MovieLocalizationMap()
        {
            HasKey(x => new {x.LanguageId, x.MovieId});

            HasRequired(x => x.Language).WithMany(x => x.MovieLocalizations).HasForeignKey(x => x.LanguageId);
            HasRequired(x => x.Movie).WithMany(x => x.MovieLocalizations).HasForeignKey(x => x.MovieId);
        }
    }
}