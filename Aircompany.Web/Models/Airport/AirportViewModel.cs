using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Airport
{
    public class AirportViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name: ")]
        public string Name { get; set; }
        
        [Display(Name = "Description: ")]
        public string Description { get; set; }
    }
}