using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Plane
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxSpeed { get; set; }

        public byte[] PlanePicture { get; set; }

        public virtual ICollection<PlaneLocalization> PlaneLocalizations { get; set; }
        public virtual ICollection<Seance> Flights { get; set; }
        public virtual ICollection<Sector> Sectors { get; set; }
    }
}
