using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Models
{
    public class NamedTicket
    {
        public Ticket Ticket { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportNumber { get; set; }
    }
}