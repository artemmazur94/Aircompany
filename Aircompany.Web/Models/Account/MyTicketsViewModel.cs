using System.Collections.Generic;
using Aircompany.Web.Models.Booking;

namespace Aircompany.Web.Models.Account
{
    public class MyTicketsViewModel
    {
        public List<TicketViewModel> UpcomingTickets { get; set; }

        public List<TicketViewModel> PastTickets { get; set; }
    }
}