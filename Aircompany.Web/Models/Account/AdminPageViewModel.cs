using System.Collections.Generic;
using Aircompany.Web.Models.Booking;

namespace Aircompany.Web.Models.Account
{
    public class AdminPageViewModel
    {
        public decimal AvarageNumberOfBookedTickets { get; set; }

        public int NumberOfFlightsThisWeek { get; set; }

        public List<FlightViewModel> FlightsThisWeek { get; set; }
    }
}