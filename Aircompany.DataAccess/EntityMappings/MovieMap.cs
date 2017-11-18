using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            HasKey(x => x.Id);

            HasOptional(x => x.Genre).WithMany(x => x.Movies).HasForeignKey(x => x.GenreId);
            HasOptional(x => x.Director).WithMany(x => x.DirectorOfMovies).HasForeignKey(x => x.DirectorId);
            HasOptional(x => x.Photo).WithMany(x => x.Movies).HasForeignKey(x => x.PhotoId);
            HasOptional(x => x.RemoveExecutor).WithMany(x => x.RemovedMovies).HasForeignKey(x => x.RemoveExecutorId);
        }
    }
}