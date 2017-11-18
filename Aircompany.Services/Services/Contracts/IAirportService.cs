using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IAirportService : IDisposable
    {
        void Commit();

        List<Airport> GetAllAirports();

        Airport GetAirport(int id);

        AirportLocalization GetAirportLocalization(int id, int languageId);

        void AddAirportLocalization(AirportLocalization airportLocalization);

        void RemoveAirport(Airport airport);
    }
}