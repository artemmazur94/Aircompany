using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class ExternalProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExternalAccount> ExternalAccounts { get; set; }
    }
}
