using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class AddFlightViewModel
    {
        [Required]
        [Display(Name = "Departure date: ")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Required]
        [Display(Name = "Departure time: ")]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        [Display(Name = "Ariving date: ")]
        [DataType(DataType.Date)]
        public DateTime ArivingDate { get; set; }
        [Required]
        [Display(Name = "Ariving time: ")]
        public TimeSpan ArivingTime { get; set; }

        [Required]
        [Display(Name = "Plane: ")]
        public int PlaneId { get; set; }

        [Required]
        public int DepartureAirportId { get; set; }

        [Required]
        public int ArivingAirportId { get; set; }

        [Required]
        [Range(0, 20)]
        public int HandLuggage { get; set; }

        [Required]
        [Range(0, 50)]
        public int Luggage { get; set; }

        [Required]
        public List<SectorTypePrice> SeatTypePrices { get; set; } 
    }
}