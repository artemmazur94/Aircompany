namespace Aircompany.DataAccess.Entities
{
    public class MovieLocalization
    {
        public int MovieId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
