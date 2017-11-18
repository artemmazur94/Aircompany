using System;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IGenreService : IDisposable
    {
        void Commit();

        Genre GetGenre(int id);

        GenreLocalization GetGenreLocalization(int id, int languageId);

        void AddGenreLocalization(GenreLocalization genreLocalization);

        void RemoveGenre(Genre genre);
    }
}