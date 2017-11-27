using System.ComponentModel.DataAnnotations;
using System.Web;
using Aircompany.DataAccess.Entities;
using Aircompany.Web.Helpers;

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

        [Display(Name = "Code: ")]
        public string Code { get; set; }

        [Display(Name = "City: ")]
        public string City { get; set; }

        [Display(Name = "Country: ")]
        public string Country { get; set; }

        [Display(Name = "Photo:")]
        [MaxFileSize(1024 * 1024 * 5, ErrorMessage = "Maximum allowed file size is {0} bytes")]
        public HttpPostedFileBase Photo { get; set; }

        public Photo PhotoEntity { get; set; }
    }
}