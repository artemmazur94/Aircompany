using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class SeanceMap : EntityTypeConfiguration<Seance>
    {
        public SeanceMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Plane).WithMany(x => x.Flights).HasForeignKey(x => x.PlaneId);
            HasRequired(x => x.Movie).WithMany(x => x.Seances).HasForeignKey(x => x.MovieId);
        }
    }
}