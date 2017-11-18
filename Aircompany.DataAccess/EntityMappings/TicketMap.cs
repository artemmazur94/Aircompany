using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Profile).WithMany(x => x.Tickets).HasForeignKey(x => x.ProfileId);
            HasRequired(x => x.Seance).WithMany(x => x.Tickets).HasForeignKey(x => x.SeanceId);
        }
    }
}