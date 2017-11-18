using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int? PhotoId { get; set; }

        public virtual Photo Photo { get; set; }

        public virtual ICollection<Movie> DirectorOfMovies { get; set; }
        public virtual ICollection<PersonLocalization> PersonLocalizations { get; set; }
        public virtual ICollection<Movie> ActorInMovies { get; set; }
    }
}
