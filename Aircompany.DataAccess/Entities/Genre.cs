using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public virtual ICollection<GenreLocalization> GenreLocalizations { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
