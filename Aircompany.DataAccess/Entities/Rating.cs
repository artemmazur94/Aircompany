namespace Aircompany.DataAccess.Entities
{
    public class Rating
    {
        public int Rate { get; set; }
        public int MovieId { get; set; }
        public int ProfileId { get; set; }
    
        public virtual Movie Movie { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
