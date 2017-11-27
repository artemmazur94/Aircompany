using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models;
using Aircompany.Web.Models.Airport;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly IFlightService _flightService;

        public AirportController(IAirportService airportService, IFlightService flightService)
        {
            _airportService = airportService;
            _flightService = flightService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        // GET: Airport
        public ActionResult Index()
        {
            var airportLocalizations = _flightService.GetAllAirportLocalizations(LanguageHelper.CurrnetCulture);

            var models = airportLocalizations.Select(x => new AirportViewModel
            {
                Id = x.AirportId,
                Name = x.Name,
                Description = x.Description,
                Code = x.Airport.Code,
                City = x.Airport.City,
                Country = x.Airport.Country,
                PhotoEntity = x.Airport.Photo
            }).ToList();

            return View(models);
        }

        // GET: Airport/Create
        [AuthorizeAdmin]
        public ActionResult Create()
        {
            return View("CreateEdit", new AirportViewModel());
        }

        // GET: Airport/Edit/5
        [AuthorizeAdmin]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = _airportService.GetAirport(id.Value);
            if (airport == null)
            {
                return HttpNotFound();
            }
            AirportLocalization airportLocalization = _airportService.GetAirportLocalization(id.Value,
                LanguageHelper.CurrnetCulture);
            var model = new AirportViewModel
            {
                Id = airport.Id,
                Name = airportLocalization.Name,
                Description = airportLocalization.Description,
                Code = airport.Code,
                City = airport.City,
                Country = airport.Country,
                PhotoEntity = airport.Photo
            };
            return View("CreateEdit", model);
        }

        // POST: Aiport/Create
        [HttpPost]
        [AuthorizeAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(AirportViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id <= 0)
                {
                    AddAirport(model);
                }
                else
                {
                    EditAirport(model);
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void AddAirport(AirportViewModel model)
        {
            Photo photo = null;
            if (model.Photo != null)
            {
                photo = _flightService.SetPhotoToDirectory(model.Photo, Server.MapPath("~/"));
            }

            var airport = new Airport
            {
                Photo = photo,
                Code = model.Code,
                City = model.City,
                Country = model.Country
            };
            _airportService.AddAirportLocalization(new AirportLocalization
            {
                Airport = airport,
                Description = model.Description,
                Name = model.Name,
                LanguageId = (int) LanguageType.EN
            });
            _airportService.Commit();
        }

        private void EditAirport(AirportViewModel model)
        {
            AirportLocalization airportLocalization = _airportService.GetAirportLocalization(model.Id, (int) LanguageType.EN);
            airportLocalization.Name = model.Name;
            airportLocalization.Description = model.Description;

            airportLocalization.Airport.Code = model.Code;
            airportLocalization.Airport.City = model.City;
            airportLocalization.Airport.Country = model.Country;

            if (model.Photo != null)
            {
                if (airportLocalization.Airport.Photo != null)
                {
                    _flightService.DeletePreviousPhotoFromDirectory(airportLocalization.Airport.Photo, Server.MapPath("~/"));
                }
                airportLocalization.Airport.Photo = _flightService.SetPhotoToDirectory(model.Photo, Server.MapPath("~/"));
            }
            
            _airportService.Commit();
        }

        // GET: Airport/Delete/5
        [AuthorizeAdmin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airport airport = _airportService.GetAirport(id.Value);
            if (airport == null)
            {
                return HttpNotFound();
            }
            var model = new DeleteViewModel
            {
                Name = _airportService.GetAirportLocalization(id.Value, LanguageHelper.CurrnetCulture).Name
            };
            return View(model);
        }

        // POST: Airport/Delete/5
        [HttpPost, ActionName("Delete")]
        [AuthorizeAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airport airport = _airportService.GetAirport(id);
            _airportService.RemoveAirport(airport);
            _airportService.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _airportService.Dispose();
                _flightService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
