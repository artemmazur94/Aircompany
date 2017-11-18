using System;
using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArivingAirportId { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArivingDateTime { get; set; }
        public int PlaneId { get; set; }
        public bool IsDeleted { get; set; }
        public int? RemoveExecutorId { get; set; }

        public virtual Plane Plane { get; set; }
        public virtual Airport DepartureAirport { get; set; }
        public virtual Airport ArivingAirport { get; set; }
        public virtual Profile RemoveExecutor { get; set; }

        public virtual ICollection<SectorTypePrice> SectorTypePrices { get; set; }
        public virtual ICollection<TicketPreOrder> TicketPreOrders { get; set; }
        public virtual ICollection<TicketPreOrdersDeleted> TicketPreOrdersDeleted { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
