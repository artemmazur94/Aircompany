namespace Aircompany.DataAccess.Entities
{
    public class SectorTypePrice
    {
        public int SeatTypeId { get; set; }
        public int SeanceId { get; set; }
        public decimal Price { get; set; }
    
        public virtual Seance Seance { get; set; }
        public virtual SeatTypeClass SeatTypeClass { get; set; }
    }
}
