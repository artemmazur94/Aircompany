using System.Data.Entity.ModelConfiguration;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.EntityMappings
{
    public class TicketPreOrderMap : EntityTypeConfiguration<TicketPreOrder>
    {
        public TicketPreOrderMap()
        {
            HasKey(x => x.Id);

            HasRequired(x => x.Profile).WithMany(x => x.TicketPreOrders).HasForeignKey(x => x.ProfileId);
            HasRequired(x => x.Flight).WithMany(x => x.TicketPreOrders).HasForeignKey(x => x.FlightId);
        }
    }
}