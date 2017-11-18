using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Departure date: ")]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Departure time: ")]
        public TimeSpan DepartureTime { get; set; }

        [Display(Name = "Ariving date: ")]
        public DateTime ArivingDate { get; set; }
        [Display(Name = "Ariving time: ")]
        public TimeSpan ArivingTime { get; set; }

        [Display(Name = "Prices: ")]
        public List<SectorTypePrice> Prices { get; set; }
        
        [Display(Name = "Plane model: ")]
        public string PlaneModel { get; set; }

        [Display(Name = "Departure airport code: ")]
        public string DepartureAirportCode { get; set; }
        [Display(Name = "Departure airport city: ")]
        public string DepartureAirportCity { get; set; }
        [Display(Name = "Departure airport country: ")]
        public string DepartureAirportCountry { get; set; }

        [Display(Name = "Ariving airport code: ")]
        public string ArivingAirportCode { get; set; }
        [Display(Name = "Ariving airport city: ")]
        public string ArivingAirportCity { get; set; }
        [Display(Name = "Ariving airport country: ")]
        public string ArivingAirportCountry { get; set; }

        public Dictionary<int, Dictionary<int ,int>> PlanePlan { get; set; }

        public List<PlaneSeat> Seats { get; set; } 

        public List<PlaneSeat> SelectedSeats { get; set; } 
    }
}