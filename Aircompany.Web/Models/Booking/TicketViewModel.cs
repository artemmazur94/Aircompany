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
        public string DepartureAirportCity { get; set; }
        public string DepartureAirportCountry { get; set; }


        [Display(Name = "Ariving airport code: ")]
        public string ArivingAirportCode { get; set; }
        public string ArivingAirportCity { get; set; }
        public string ArivingAirportCountry { get; set; }

        [Display(Name = "Price: ")]
        public decimal Price { get; set; }

        [Display(Name = "Flight code: ")]
        public string Code { get; set; }

        public int HandLuggage { get; set; }
        public int Luggage { get; set; }
        
        public PlaneSeat Seat { get; set; }
    }
}