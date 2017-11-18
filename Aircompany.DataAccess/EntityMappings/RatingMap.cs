using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            HasKey(x => new {x.MovieId, x.ProfileId});

            HasRequired(x => x.Movie).WithMany(x => x.Ratings).HasForeignKey(x => x.MovieId);
            HasRequired(x => x.Profile).WithMany(x => x.Ratings).HasForeignKey(x => x.ProfileId);
        }
    }
}