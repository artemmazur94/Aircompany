using System;

namespace Aircompany.DataAccess.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int SeanceId { get; set; }
        public DateTime SaleDate { get; set; }
        public int? ProfileId { get; set; }
        public Guid Guid { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual Seance Seance { get; set; }
    }
}
