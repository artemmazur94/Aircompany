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

        public Plane GetPlane(int id)
        {
            var plane = _unitOfWork.PlaneRepository.Get(id);
            if (plane.PhotoId.HasValue)
            {
                plane.Photo = _unitOfWork.PlaneRepository.GetPhoto(plane.PhotoId.Value);
            }

            return plane;
        }

        public PlaneLocalization GetPlaneLocalization(int id, int languageId)
        {
            return _unitOfWork.PlaneRepository.GetPlaneLocalization(id, languageId);
        }

        public void AddPlane(Plane plane)
        {
            _unitOfWork.PlaneRepository.Add(plane);
        }

        public Photo GetPhoto(int photoId)
        {
            return _unitOfWork.PlaneRepository.GetPhoto(photoId);
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