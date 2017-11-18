using System;
using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public Guid Guid { get; set; }
        public string Filename { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
