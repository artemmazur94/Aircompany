using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class GenreRepository : GenericRepositrory<Genre>, IGenreRepository
    {
        private AircompanyContext GenreContext => Context;

        public GenreRepository(AircompanyContext context) : base(context)
        {
        }

        public GenreLocalization GetGenreLocalization(int genreId, int languageId)
        {
            return GenreContext.GenreLocalizations.First(x => x.GenreId == genreId && x.LanguageId == languageId);
        }

        public List<GenreLocalization> GetAllGenreLocalizations(int languageId)
        {
            return GenreContext.GenreLocalizations.Where(x => x.LanguageId == languageId).ToList();
        }

        public List<GenreLocalization> GetGenresForMovies(List<int> genreIds, int languageId)
        {
            return GenreContext.GenreLocalizations.Where(x => 
                genreIds.Contains(x.GenreId) && 
                x.LanguageId == languageId).ToList();
        }

        public void AddGenreLocalization(GenreLocalization genreLocalization)
        {
            GenreContext.GenreLocalizations.Add(genreLocalization);
        }
    }
}