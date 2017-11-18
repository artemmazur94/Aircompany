using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Repositories.Contracts
{
    public interface IAirportRepository : IDisposable, IRepository<Airport>
    {
        AirportLocalization GetAirportLocalization(int airportId, int languageId);
        List<AirportLocalization> GetAllAirportLocalizations(int languageId);
        List<AirportLocalization> GetAirportLocalizations(List<int> airportIds, int languageId);
        void AddAirportLocalization(AirportLocalization airportLocalization);
    }
}