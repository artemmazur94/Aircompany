using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Movie).WithMany(x => x.Comments).HasForeignKey(x => x.MovieId);
            HasRequired(x => x.Profile).WithMany(x => x.Comments).HasForeignKey(x => x.ProfileId);
        }
    }
}