using System;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Booking
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Plane model: ")]
        public string PlaneModel { get; set; }

        [Display(Name = "Departure date: ")]
        public DateTime DepartureDate { get; set; }

        [Display(Name = "Ariving date: ")]
        public DateTime ArivingDate { get; set; }

        [Display(Name = "Departure airport code: ")]
        public string DepartureAirportCode { get; set; }

        [Display(Name = "Ariving airport code: ")]
        public string ArivingAirportCode { get; set; }

        [Display(Name = "Price: ")]
        public decimal Price { get; set; }
        
        public PlaneSeat Seat { get; set; }
    }
}