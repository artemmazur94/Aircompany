﻿using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IPlaneService : IDisposable
    {
        void Commit();

        List<Plane> GetAllPlanes();
        List<PlaneLocalization> GetAllPlaneLocalizations(int languageId);
    }
}