using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Repositories.Contracts;

namespace Aircompany.DataAccess.Repositories
{
    public class PlaneRepository : GenericRepositrory<Plane>, IPlaneRepository
    {
        private AircompanyContext PlaneContext => Context;

        public PlaneRepository(AircompanyContext context) : base(context)
        {
        }

        public List<PlaneLocalization> GetAllPlaneLocalizations(int languageId)
        {
            return PlaneContext.PlaneLocalizations.Where(x => x.LanguageId == languageId).ToList();
        }
    }
}