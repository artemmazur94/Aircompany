using System;
using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Seance
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int PlaneId { get; set; }
        public int MovieId { get; set; }

        public virtual Plane Plane { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<SectorTypePrice> SectorTypePrices { get; set; }
        public virtual ICollection<TicketPreOrder> TicketPreOrders { get; set; }
        public virtual ICollection<TicketPreOrdersDeleted> TicketPreOrdersDeleted { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
