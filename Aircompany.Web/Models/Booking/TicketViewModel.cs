using System;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Booking
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Movie name: ")]
        public string MovieName { get; set; }

        [Display(Name = "Plane model: ")]
        public string PlaneModel { get; set; }

        [Display(Name = "Date: ")]
        public DateTime Date { get; set; }

        [Display(Name = "Time: ")]
        public TimeSpan Time { get; set; }

        [Display(Name = "Price: ")]
        public decimal Price { get; set; }
        
        public PlaneSeat Seat { get; set; }
    }
}