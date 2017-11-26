using System;

namespace Aircompany.DataAccess.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PercentageAmount { get; set; }
    }
}