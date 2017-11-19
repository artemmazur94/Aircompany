using System;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }

        IAirportRepository AirportRepository { get; }

        IFlightRepository FlightRepository { get; }

        ISecurityTokenRepository SecurityTokenRepository { get; }

        IPlaneRepository PlaneRepository { get; }

        void Commit();
    }
}