namespace Aircompany.DataAccess.Entities
{
    public class TicketPreOrder
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int SeanceId { get; set; }
        public System.DateTime DateTime { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual Seance Seance { get; set; }
    }
}
