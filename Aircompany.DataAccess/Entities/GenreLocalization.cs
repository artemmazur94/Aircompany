namespace Aircompany.DataAccess.Entities
{
    public class GenreLocalization
    {
        public int GenreId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
