using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Flight
{
    public class DirectionsViewModel
    {
        [Required]
        [Display(Name = "Departure: ")]
        public int DepartureAirportId { get; set; }

        [Required]
        [Display(Name = "Ariving: ")]
        public int ArivingAirportId { get; set; }
    }
}