using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Web.Models.Booking
{
    public class MovieSeanceViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Seances")]
        public List<SeanceViewModel> Seances { get; set; }
        
        public Photo Poster { get; set; }
        
        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; } 
    }
}