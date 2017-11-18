using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class TicketPreOrdersDeletedMap : EntityTypeConfiguration<TicketPreOrdersDeleted>
    {
        public TicketPreOrdersDeletedMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Profile).WithMany(x => x.TicketPreOrdersDeleted).HasForeignKey(x => x.ProfileId);
            HasRequired(x => x.Seance).WithMany(x => x.TicketPreOrdersDeleted).HasForeignKey(x => x.SeanceId);
        }
    }
}