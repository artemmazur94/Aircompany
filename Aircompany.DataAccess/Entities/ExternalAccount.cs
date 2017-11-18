namespace Aircompany.DataAccess.Entities
{
    public class ExternalAccount
    {
        public int ExternalProviderId { get; set; }
        public string UserIdentity { get; set; }
        public int ProfileId { get; set; }
    
        public virtual ExternalProvider ExternalProvider { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
