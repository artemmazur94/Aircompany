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

        public PlaneLocalization GetPlaneLocalization(int id, int languageId)
        {
            return PlaneContext.PlaneLocalizations.FirstOrDefault(x => x.PlaneId == id && x.LanguageId == languageId);
        }

        public Photo GetPhoto(int photoId)
        {
            return PlaneContext.Photos.First(x => x.Id == photoId);
        }
    }
}