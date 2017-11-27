using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IPlaneService : IDisposable
    {
        void Commit();

        List<Plane> GetAllPlanes();
        List<PlaneLocalization> GetAllPlaneLocalizations(int languageId);
        Plane GetPlane(int id);
        PlaneLocalization GetPlaneLocalization(int id, int languageId);
        void AddPlane(Plane plane);
        Photo GetPhoto(int photoId);
    }
}