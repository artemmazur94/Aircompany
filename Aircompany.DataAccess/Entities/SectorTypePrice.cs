namespace Aircompany.DataAccess.Entities
{
    public class SectorTypePrice
    {
        public int SeatTypeId { get; set; }
        public int FlightId { get; set; }
        public decimal Price { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual SeatTypeClass SeatTypeClass { get; set; }
    }
}
