using System;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Flight
{
    public class FlightDetailsViewModel
    {
        public int FlightId { get; set; }

        [Display(Name = "Flight code:")]
        public string FlightCode { get; set; }

        public int DepartureAirportId { get; set; }
        public int ArivingAirportId { get; set; }

        [Display(Name = "Departure date: ")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Ariving date: ")]
        public DateTime ArivingDateTime { get; set; }
        
        [Display(Name = "Departure airport code: ")]
        public string DepartureAirportCode { get; set; }
        [Display(Name = "Departure airport name: ")]
        public string DepartureAirportName { get; set; }
        [Display(Name = "Departure airport city: ")]
        public string DepartureAirportCity { get; set; }
        [Display(Name = "Departure airport country: ")]
        public string DepartureAirportCountry { get; set; }


        [Display(Name = "Ariving airport code:")]
        public string ArivingAirportCode { get; set; }
        [Display(Name = "Ariving airport name: ")]
        public string ArivingAirportName { get; set; }
        [Display(Name = "Ariving airport city: ")]
        public string ArivingAirportCity { get; set; }
        [Display(Name = "Ariving airport country: ")]
        public string ArivingAirportCountry { get; set; }
    }
}