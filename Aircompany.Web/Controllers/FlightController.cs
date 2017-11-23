using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models.Flight;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;

        private const string NAME_COLUMN = "Name";
        private const string AIRPORT_ID_COLUMN = "AirportId";
        private const string AIRPORT_CODE_COLUMN = "Code";
        private const string FLIGHT_ID_COLUMN = "Id";

        public FlightController(IFlightService flightService, IAirportService airportService)
        {
            _flightService = flightService;
            _airportService = airportService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        [HttpGet]
        public ActionResult Index()
        {
            var airports = _airportService.GetAllAirports();

            ApplyAirports(airports);

            var flights = _flightService.GetAllActiveFlights().OrderBy(x => x.DepartureDateTime).ToList();

            ApplyFlights(flights);

            var model = new DirectionsViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DirectionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ApplyAirports(_airportService.GetAllAirports());

                return View(model);
            }

            if (model.DepartureAirportId == model.ArivingAirportId)
            {
                ApplyAirports(_airportService.GetAllAirports());

                ModelState.AddModelError(String.Empty, "Departure and araving airports must be different.");
                return View(model);
            }

            return RedirectToAction("Flights", "Booking", 
                new
                {
                    departureAirportId = model.DepartureAirportId,
                    arivingAirportId = model.ArivingAirportId
                });
        }


        [HttpGet]
        public ActionResult Directions(int? departureAirportId, int? arivingAirportId)
        {
            List<Flight> flights = _flightService.GetAllFlights();

            if (departureAirportId.HasValue)
            {
                flights = flights.Where(x => x.DepartureAirportId == departureAirportId).ToList();
            }

            if (arivingAirportId.HasValue)
            {
                flights = flights.Where(x => x.ArivingAirportId == arivingAirportId).ToList();
            }

            var models = (from flight in flights
                select new FlightListItemViewModel
                {
                    FlightId = flight.Id,
                    DepartureAirportCode = flight.DepartureAirport.Code,
                    ArivingAirportCode = flight.ArivingAirport.Code,
                    DepartureDateTime = flight.DepartureDateTime,
                    ArivingDateTime = flight.ArivingDateTime
                }).ToList();

            return View(models);
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var flight = _flightService.GetFlight(id.Value);
            if (flight == null)
            {
                return HttpNotFound();
            }

            var departureAirportLocalization = _airportService.GetAirportLocalization(flight.DepartureAirportId, LanguageHelper.CurrnetCulture);
            var airportAirportLocalization = _airportService.GetAirportLocalization(flight.ArivingAirportId, LanguageHelper.CurrnetCulture);

            var model = new FlightDetailsViewModel
            {
                FlightId = flight.Id,
                DepartureAirportId = flight.DepartureAirportId,
                ArivingAirportId = flight.ArivingAirportId,
                DepartureDateTime = flight.DepartureDateTime,
                ArivingDateTime = flight.ArivingDateTime,
                DepartureAirportCode = flight.DepartureAirport.Code,
                DepartureAirportName = departureAirportLocalization.Name,
                DepartureAirportCity = flight.DepartureAirport.City,
                DepartureAirportCountry = flight.DepartureAirport.Country,
                ArivingAirportCode = flight.ArivingAirport.Code,
                ArivingAirportName = airportAirportLocalization.Name,
                ArivingAirportCity = flight.ArivingAirport.City,
                ArivingAirportCountry = flight.ArivingAirport.Country,
            };

            return View(model);
        }

        private void ApplyAirports(List<Airport> airports)
        {
            ViewBag.DepartureAirports = new SelectList(
                airports.Select(x => new { AirportId = x.Id, Code = $"{x.Code}, {x.City}, {x.Country}" }),
                AIRPORT_ID_COLUMN,
                AIRPORT_CODE_COLUMN);

            ViewBag.ArivingAirports = new SelectList(
                airports.Select(x => new { AirportId = x.Id, Code = $"{x.Code}, {x.City}, {x.Country}" }),
                AIRPORT_ID_COLUMN,
                AIRPORT_CODE_COLUMN);
        }

        private void ApplyFlights(List<Flight> flights)
        {
            ViewBag.Flights = flights;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _flightService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
