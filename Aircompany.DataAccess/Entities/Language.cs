using System.Collections.Generic;

namespace Aircompany.DataAccess.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string LanguageCode { get; set; }

        public virtual ICollection<PlaneLocalization> PlaneLocalizations { get; set; }
        public virtual ICollection<GenreLocalization> GenreLocalizations { get; set; }
        public virtual ICollection<MovieLocalization> MovieLocalizations { get; set; }
        public virtual ICollection<PersonLocalization> PersonLocalizations { get; set; }
    }
}
