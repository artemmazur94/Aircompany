using System;
using System.Collections.Generic;
using System.Web;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IFlightService : IDisposable
    {
        void Commit();
        List<Flight> GetAllFlights();
        List<Flight> GetAllActiveFlights();
        Flight GetFlight(int id);
        string GetAirportLocalizationName(int airportId, int languageId);
        List<AirportLocalization> GetAllAirportLocalizations(int languageId);
        Photo SetPhotoToDirectory(HttpPostedFileBase poster, string serverPath);
        void RemoveFlight(int id, int profileId);
        List<AirportLocalization> GetAirportLocalizations(List<int> airportIds, int languageId);
        Airport GetAirportByCode(string code);
    }
}