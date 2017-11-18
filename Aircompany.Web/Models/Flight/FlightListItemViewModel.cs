using System;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Flight
{
    public class FlightListItemViewModel
    {
        public int FlightId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Departure date: ")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ariving date: ")]
        public DateTime ArivingDateTime { get; set; }
        
        [Display(Name = "Departure airport code: ")]
        public string DepartureAirportCode { get; set; }

        [Display(Name = "Ariving airport code: ")]
        public string ArivingAirportCode { get; set; }
    }
}