using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Plane
{
    public class PlaneViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Model: ")]
        public string Model { get; set; }

        [Required]
        [Display(Name = "Manufacturer: ")]
        public string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Maximum speed: ")]
        public int MaxSpeed { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        public string PhotoPath { get; set; }
    }
}