using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Profile Profile { get; set; }
        public virtual ICollection<SecurityToken> SecurityTokens { get; set; }
    }
}
