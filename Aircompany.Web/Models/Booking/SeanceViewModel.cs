using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class SeanceViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Date: ")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Time: ")]
        public TimeSpan Time { get; set; }
        
        [Display(Name = "Prices: ")]
        public List<SectorTypePrice> Prices { get; set; }
        
        [Display(Name = "Plane model: ")]
        public string PlaneModel { get; set; }

        [Display(Name = "Movie name: ")]
        public string MovieName { get; set; }

        public int MovieId { get; set; }

        public Dictionary<int, Dictionary<int ,int>> PlanePlan { get; set; }

        public List<PlaneSeat> Seats { get; set; } 

        public List<PlaneSeat> SelectedSeats { get; set; } 
    }
}