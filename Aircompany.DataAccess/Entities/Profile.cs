using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PassportNumber { get; set; }
        public byte[] ImageData { get; set; }
    
        // many because it's easier to configure, always use First/Single (OrDefault) to access navigation property
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<ExternalAccount> ExternalAccounts { get; set; }
        public virtual ICollection<Flight> RemovedFlights { get; set; }
        public virtual ICollection<TicketPreOrder> TicketPreOrders { get; set; }
        public virtual ICollection<TicketPreOrdersDeleted> TicketPreOrdersDeleted { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
