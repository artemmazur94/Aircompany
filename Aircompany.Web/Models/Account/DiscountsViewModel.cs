using System.Collections.Generic;

namespace Aircompany.Web.Models.Account
{
    public class DiscountsViewModel
    {
        public List<DiscountViewModel> ActiveDiscounts { get; set; }

        public List<DiscountViewModel> UpcomingDiscounts { get; set; }
    }
}