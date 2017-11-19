using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Aircompany.DataAccess;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;

namespace Aircompany.Services.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly string KEY_PHOTO_DIRECTORY = "PhotoDirectory";

        public FlightService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Commit()
        {
            _unitOfWork.Commit();
        }

        public List<Flight> GetAllFlights()
        {
            return _unitOfWork.FlightRepository.Find(x => x.IsDeleted == false).ToList();
        }

        public Flight GetFlight(int id)
        {
            return _unitOfWork.FlightRepository.Find(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
        }

        public string GetAirportLocalizationName(int airportId, int languageId)
        {
            return _unitOfWork.AirportRepository.GetAirportLocalization(airportId, languageId).Name;
        }

        public List<AirportLocalization> GetAllAirportLocalizations(int languageId)
        {
            return _unitOfWork.AirportRepository.GetAllAirportLocalizations(languageId);
        }

        public Photo SetPhotoToDirectory(HttpPostedFileBase poster, string serverPath)
        {
            string extention = System.IO.Path.GetExtension(poster.FileName);
            var guid = Guid.NewGuid();
            string path = ConfigurationManager.AppSettings[KEY_PHOTO_DIRECTORY] + guid + extention;
            var absolutePath = serverPath + path; //Path.Combine(serverPath, path);
            if (!Directory.Exists(Path.GetDirectoryName(absolutePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(absolutePath));
            }
            poster.SaveAs(absolutePath);
            var photo = new Photo
            {
                Filename = poster.FileName,
                Guid = guid,
                Path = path
            };
            return photo;
        }

        public void RemoveFlight(int id, int profileId)
        {
            var flight = _unitOfWork.FlightRepository.Get(id);
            flight.RemoveExecutorId = profileId;
            flight.IsDeleted = true;
        }

        public List<AirportLocalization> GetAirportLocalizations(List<int> airportIds, int languageId)
        {
            return _unitOfWork.AirportRepository.GetAirportLocalizations(airportIds, languageId);
        }

        public Airport GetAirportByCode(string code)
        {
            return _unitOfWork.AirportRepository.Find(x => x.Code == code).FirstOrDefault();
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