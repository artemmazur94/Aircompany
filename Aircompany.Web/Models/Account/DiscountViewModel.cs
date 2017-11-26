using System;
using System.ComponentModel.DataAnnotations;

namespace Aircompany.Web.Models.Account
{
    public class DiscountViewModel
    {
        [Display(Name = "Start date:")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date:")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Percentage amount:")]
        [Range(1 , 99)]
        public int PercentageAmount { get; set; }
    }
}