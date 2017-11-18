using System.Collections.Generic;
using Aircompany.Web.Models.Booking;

namespace Aircompany.Web.Models.Account
{
    public class AdminPageViewModel
    {
        public decimal AvarageNumberOfBookedTickets { get; set; }

        public int NumberOfSeancesThisWeek { get; set; }

        public List<string> MoviesThisWeek { get; set; }

        public List<SeanceViewModel> SeancesThisWeek { get; set; }
    }
}