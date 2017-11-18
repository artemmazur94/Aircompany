using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class MovieRepository : GenericRepositrory<Movie>, IMovieRepository
    {
        private AircompanyContext MovieContext => Context;

        public MovieRepository(AircompanyContext context) : base(context)
        {
        }

        public MovieLocalization GetMovieLocalization(int id, int languageId)
        {
            return MovieContext.MovieLocalizations.First(x => x.MovieId == id && x.LanguageId == languageId);
        }

        public List<MovieLocalization> GetMovieLocalizationsForPersons(List<int> movieIds, int languageId)
        {
            return MovieContext.MovieLocalizations.Where( x => 
                movieIds.Contains(x.MovieId) && 
                x.LanguageId == languageId).ToList();
        }

        public void DeletePhoto(Photo photo)
        {
            MovieContext.Photos.Remove(photo);
        }

        public Photo GetPhotoByMovieId(int movieId)
        {
            return MovieContext.Photos.FirstOrDefault(x => x.Movies.Any(z => z.Id == movieId));
        }

        public List<MovieLocalization> GetMovieLocalizations(List<int> movieIds, int languageId)
        {
            return MovieContext.MovieLocalizations.Where( x => 
                movieIds.Contains(x.MovieId) && 
                x.LanguageId == languageId).ToList();
        }

        public void AddMovieLocalization(MovieLocalization movieLocalization)
        {
            MovieContext.MovieLocalizations.Add(movieLocalization);
        }
    }
}