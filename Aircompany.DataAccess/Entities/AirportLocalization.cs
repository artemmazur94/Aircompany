namespace Aircompany.DataAccess.Entities
{
    public class AirportLocalization
    {
        public int AirportId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Airport Airport { get; set; }
    }
}
