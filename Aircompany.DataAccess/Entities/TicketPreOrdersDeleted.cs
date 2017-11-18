using System;

namespace Aircompany.DataAccess.Entities
{
    public class TicketPreOrdersDeleted
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int SeanceId { get; set; }
        public DateTime DateTime { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual Seance Seance { get; set; }
    }
}
