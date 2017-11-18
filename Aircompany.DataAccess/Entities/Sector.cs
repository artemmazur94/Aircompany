namespace Aircompany.DataAccess.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public int FromRow { get; set; }
        public int ToRow { get; set; }
        public int FromPlace { get; set; }
        public int ToPlace { get; set; }
        public int SeatTypeId { get; set; }
        public int PlaneId { get; set; }
    
        public virtual Plane Plane { get; set; }
        public virtual SeatTypeClass SeatTypeClass { get; set; }
    }
}
