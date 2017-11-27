using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.DataAccess.Repositories.Contracts
{
    public interface IPlaneRepository : IDisposable, IRepository<Plane>
    {
        List<PlaneLocalization> GetAllPlaneLocalizations(int languageId);
        PlaneLocalization GetPlaneLocalization(int id, int languageId);
        Photo GetPhoto(int photoId);
    }
}