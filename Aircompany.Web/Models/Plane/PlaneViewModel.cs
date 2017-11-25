using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Plane
{
    public class PlaneViewModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Model: ")]
        public string PlaneModel { get; set; }

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

        [Display(Name = "Econom class sector")]
        public SectorViewModel EconomSector { get; set; } = new SectorViewModel();

        [Display(Name = "Business class sector")]
        public SectorViewModel BusinessSector { get; set; } = new SectorViewModel();

        [Display(Name = "First class sector")]
        public SectorViewModel FirstClassSector { get; set; } = new SectorViewModel();
    }

    public class SectorViewModel
    {
        [Display(Name = "From row: ")]
        public int FromRow { get; set; }

        [Display(Name = "To row: ")]
        public int ToRow { get; set; }

        [Display(Name = "From place: ")]
        public int FromPlace { get; set; }

        [Display(Name = "To place: ")]
        public int ToPlace { get; set; }

        [Display(Name = "Include: ")]
        public bool IsIncluded { get; set; } = false;
    }
}