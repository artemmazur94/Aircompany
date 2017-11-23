using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Booking
{
    public class FlightsViewModel
    {
        public int DepartureAirportId { get; set; }
        public int ArivingAirportId { get; set; }

        [Required]
        [Display(Name = "Flights")]
        public List<FlightViewModel> Flights { get; set; }

        [Required]
        [Display(Name = "Departure Airport Name: ")]
        public string DepartureAirportName { get; set; }
        [Required]
        [Display(Name = "Departure Airport Code: ")]
        public string DepartureAirportCode { get; set; }
        [Required]
        [Display(Name = "Departure Airport City: ")]
        public string DepartureAirportCity { get; set; }
        [Required]
        [Display(Name = "Departure Airport Country: ")]
        public string DepartureAirportCountry { get; set; }

        [Required]
        [Display(Name = "Ariving Airport Name: ")]
        public string ArivingAirportName { get; set; }
        [Required]
        [Display(Name = "Ariving Airport Code: ")]
        public string ArivingAirportCode { get; set; }
        [Required]
        [Display(Name = "Ariving Airport City: ")]
        public string ArivingAirportCity { get; set; }
        [Required]
        [Display(Name = "Ariving Airport Country: ")]
        public string ArivingAirportCountry { get; set; }
    }
}