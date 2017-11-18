namespace Aircompany.DataAccess.Entities
{
    public class PersonLocalization
    {
        public int PersonId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Person Person { get; set; }
    }
}
