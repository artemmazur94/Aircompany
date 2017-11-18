using System;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AircompanyContext _context;

        public IAccountRepository AccountRepository { get; set; }

        public IAirportRepository AirportRepository { get; set; }

        public IFlightRepository FlightRepository { get; set; }

        public ISecurityTokenRepository SecurityTokenRepository { get; set; }

        public UnitOfWork(AircompanyContext context, 
            IAccountRepository accountRepository,
            IAirportRepository airportRepository, 
            IFlightRepository flightRepository, 
            ISecurityTokenRepository securityTokenRepository)
        {
            _context = context;
            AccountRepository = accountRepository;
            AirportRepository = airportRepository;
            FlightRepository = flightRepository;
            SecurityTokenRepository = securityTokenRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}