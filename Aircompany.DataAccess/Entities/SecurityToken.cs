using System;

namespace Aircompany.DataAccess.Entities
{
    public class SecurityToken
    {
        public Guid Id { get; set; }
        public int AccountId { get; set; }
        public DateTime ResetRequestDateTime { get; set; }
        public bool IsUsed { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
