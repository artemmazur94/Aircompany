using System;
using System.Collections.Generic;
using System.Linq;
using Aircompany.DataAccess;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;

namespace Aircompany.Services.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AirportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public List<Airport> GetAllAirports()
        {
            return _unitOfWork.AirportRepository.GetAll().ToList();
        }

        public Airport GetAirport(int id)
        {
            return _unitOfWork.AirportRepository.Get(id);
        }

        public AirportLocalization GetAirportLocalization(int id, int languageId)
        {
            return _unitOfWork.AirportRepository.GetAirportLocalization(id, languageId);
        }

        public void AddAirportLocalization(AirportLocalization airportLocalization)
        {
            _unitOfWork.AirportRepository.AddAirportLocalization(airportLocalization);
        }

        public void RemoveAirport(Airport airport)
        {
            _unitOfWork.AirportRepository.Remove(airport);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}