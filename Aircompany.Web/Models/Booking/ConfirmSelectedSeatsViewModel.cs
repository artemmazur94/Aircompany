using System.Collections.Generic;

namespace Aircompany.Web.Models.Booking
{
    public class ConfirmSelectedSeatsViewModel
    {
        public int FlightId { get; set; }

        public List<PlaneSeat> SelectedSeats { get; set; }
    }
}