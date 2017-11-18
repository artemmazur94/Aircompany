using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class AirportRepository : GenericRepositrory<Airport>, IAirportRepository
    {
        private AircompanyContext AirportContext => Context;

        public AirportRepository(AircompanyContext context) : base(context)
        {
        }

        public AirportLocalization GetAirportLocalization(int airportId, int languageId)
        {
            return AirportContext.AirportLocalizations.First(x => x.AirportId == airportId && x.LanguageId == languageId);
        }

        public List<AirportLocalization> GetAllAirportLocalizations(int languageId)
        {
            return AirportContext.AirportLocalizations.Where(x => x.LanguageId == languageId).ToList();
        }

        public List<AirportLocalization> GetAirportLocalizations(List<int> airportIds, int languageId)
        {
            return AirportContext.AirportLocalizations.Where(x => 
                airportIds.Contains(x.AirportId) && 
                x.LanguageId == languageId).ToList();
        }

        public void AddAirportLocalization(AirportLocalization airportLocalization)
        {
            AirportContext.AirportLocalizations.Add(airportLocalization);
        }
    }
}