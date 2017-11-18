using System;
using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int? GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? DirectorId { get; set; }
        public double? Rating { get; set; }
        public int? PhotoId { get; set; }
        public string VideoLink { get; set; }
        public bool IsDeleted { get; set; }
        public int? RemoveExecutorId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Person Director { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual Profile RemoveExecutor { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MovieLocalization> MovieLocalizations { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }
        public virtual ICollection<Person> Actors { get; set; }
    }
}
