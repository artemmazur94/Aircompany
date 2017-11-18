using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Airport
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? PhotoId { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual ICollection<AirportLocalization> AirportLocalizations { get; set; }
        public virtual ICollection<Flight> FlightsAsDeparture { get; set; }
        public virtual ICollection<Flight> FlightsAsArriving { get; set; }

    }
}
