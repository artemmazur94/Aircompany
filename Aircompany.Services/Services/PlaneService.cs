using System;
using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;

namespace Aircompany.Services.Services
{
    public class PlaneService : IPlaneService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlaneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Plane> GetAllPlanes()
        {
            return _unitOfWork.PlaneRepository.GetAll().ToList();
        }

        public List<PlaneLocalization> GetAllPlaneLocalizations(int languageId)
        {
            return _unitOfWork.PlaneRepository.GetAllPlaneLocalizations(languageId);
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}