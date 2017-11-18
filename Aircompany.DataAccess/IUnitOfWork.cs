using System;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }

        IGenreRepository GenreRepository { get; }

        IMovieRepository MovieRepository { get; }

        IPersonRepository PersonRepository { get; }

        ISeanceRepository SeanceRepository { get; }

        ISecurityTokenRepository SecurityTokenRepository { get; }
        
        void Commit();
    }
}