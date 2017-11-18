using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class AddSeanceViewModel
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        [Display(Name = "Movie name: ")]
        public string MovieName { get; set; }
        
        [Required]
        [Display(Name = "Date: ")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time: ")]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name = "Plane: ")]
        public int PlaneId { get; set; }

        [Required]
        public List<SectorTypePrice> SeatTypePrices { get; set; } 
    }
}