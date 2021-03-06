﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Models;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models.Booking;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IFlightService _flightService;
        private readonly IAccountService _accountService;
        private readonly IAirportService _airportService;
        private readonly string _airlinesCode;

        private const string MESSAGE_KEY = "Message";
        private const string PLANE_ID_COLUMN = "Id";
        private const string PLANE_MODEL_COLUMN = "Model";
        private const string AIRPORT_ID_COLUMN = "Id";
        private const string AIRPORT_CODE_COLUMN = "Code";


        private const string SEAT_STATUS_FREE = "Free";
        private const string SEAT_STATUS_OCCUPIED = "Occupied";

        public BookingController(
            IBookingService bookingService, 
            IFlightService flightService, 
            IAccountService accountService, 
            IAirportService airportService)
        {
            _bookingService = bookingService;
            _flightService = flightService;
            _accountService = accountService;
            _airportService = airportService;
            _airlinesCode = ConfigurationManager.AppSettings["FlightCode"];
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        // GET: Booking/Flight/5
        public ActionResult Flights(int? departureAirportId, int? arivingAirportId, DateTime? fromDate, DateTime? toDate)
        {
            if (departureAirportId == null || arivingAirportId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var departureAirport = _airportService.GetAirport(departureAirportId.Value);
            var departureAirportLocalization = _airportService.GetAirportLocalization(departureAirportId.Value, LanguageHelper.CurrnetCulture);

            var arivingAirport = _airportService.GetAirport(arivingAirportId.Value);
            var arivingAirportLocalization = _airportService.GetAirportLocalization(arivingAirportId.Value, LanguageHelper.CurrnetCulture);

            List<Flight> flights = _bookingService.GetActiveFlightsByAirportIds(departureAirportId.Value, arivingAirportId.Value);

            if (fromDate != null)
            {
                flights = flights.Where(x => x.DepartureDateTime.Date >= fromDate.Value.Date).ToList();
            }

            if (toDate != null)
            {
                flights = flights.Where(x => x.DepartureDateTime.Date <= toDate.Value.Date).ToList();
            }

            var flightModels = flights.Select(flight => new FlightViewModel
            {
                Id = flight.Id,
                Code = $"{_airlinesCode} {flight.Id:D4}",
                DepartureDate = flight.DepartureDateTime.ToLocalTime().Date,
                DepartureTime = flight.DepartureDateTime.ToLocalTime().TimeOfDay,
                ArivingDate = flight.ArivingDateTime.ToLocalTime().Date,
                ArivingTime = flight.ArivingDateTime.ToLocalTime().TimeOfDay,
                PlaneModel = $"{flight.Plane.Manufacturer} {flight.Plane.Model}",
                Prices = flight.SectorTypePrices.ToList(),
                DepartureAirportCode = flight.DepartureAirport.Code,
                DepartureAirportCity = flight.DepartureAirport.City,
                DepartureAirportCountry = flight.DepartureAirport.Country,
                ArivingAirportCode = flight.ArivingAirport.Code,
                ArivingAirportCity = flight.ArivingAirport.City,
                ArivingAirportCountry = flight.ArivingAirport.Country,
                HandLuggage = flight.HandLuggage,
                Luggage = flight.Luggage
            }).ToList();
            var model = new FlightsViewModel
            {
                DepartureAirportId = departureAirportId.Value,
                ArivingAirportId = arivingAirport.Id,
                Flights = flightModels,
                DepartureAirportName = departureAirportLocalization.Name,
                DepartureAirportCode = departureAirport.Code,
                DepartureAirportCity = departureAirport.City,
                DepartureAirportCountry = departureAirport.Country,
                ArivingAirportName = arivingAirportLocalization.Name,
                ArivingAirportCode = arivingAirport.Code,
                ArivingAirportCity = arivingAirport.City,
                ArivingAirportCountry = arivingAirport.Country,
            };
            return View(model);
        }

        [Authorize]
        // GET: Booking/BookTikets/5
        public ActionResult SelectSeats(int? id)
        {
            // id - flightId
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            var flight = _bookingService.GetFlight(id.Value);
            if (flight == null)
            {
                return HttpNotFound();
            }

            var model = new FlightViewModel
            {
                Id = flight.Id,
                Code = $"{_airlinesCode} {flight.Id:D4}",
                DepartureDate = flight.DepartureDateTime.ToLocalTime().Date,
                DepartureTime = flight.DepartureDateTime.ToLocalTime().TimeOfDay,
                ArivingDate = flight.ArivingDateTime.ToLocalTime().Date,
                ArivingTime = flight.ArivingDateTime.ToLocalTime().TimeOfDay,
                Prices = flight.SectorTypePrices.ToList(),
                PlaneModel = $"{flight.Plane.Manufacturer} {flight.Plane.Model}",
                DepartureAirportCode = flight.DepartureAirport.Code,
                DepartureAirportCity = flight.DepartureAirport.City,
                DepartureAirportCountry = flight.DepartureAirport.Country,
                ArivingAirportCode = flight.ArivingAirport.Code,
                ArivingAirportCity = flight.ArivingAirport.City,
                ArivingAirportCountry = flight.ArivingAirport.Country,
                HandLuggage = flight.HandLuggage,
                Luggage = flight.Luggage
            };

            var discount = _accountService.GetActiveDiscountPercentage();
            if (discount != null)
            {
                ViewBag.Discount = discount;
                model.Prices.ForEach(x => x.Price = (x.Price * (1 - ((decimal)discount / 100m))));
            }

            List<Sector> sectors = _bookingService.GetSectorsByPlaneId(flight.PlaneId);
            if (sectors.Count > 0)
            {
                model.PlanePlan = PlaneHelper.CreatePlanePlan(sectors);
                int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);
                List<Ticket> flightTickets = _bookingService.GetFlightTickets(flight.Id);
                List<TicketPreOrder> flightTicketPreOrders = _bookingService.GetFlightTicketPreOrdersOfOtherUsers(flight.Id, profileId);
                model.Seats = PlaneSeat.GetAllSeats(flightTickets, flightTicketPreOrders);
                model.SelectedSeats = PlaneSeat.GetAllSeats(_bookingService.GetFlightTicketPreOrdersForCurrentUser(flight.Id, profileId));
            }
            if (TempData[MESSAGE_KEY] != null)
            {
                ViewBag.Message = TempData[MESSAGE_KEY].ToString();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePlaceStatus(int row, int place, int flightId)
        {
            int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);
            if (_bookingService.IsTicketAbleToBook(row, place, flightId) && !_bookingService.IsSeatBindedToOtherUser(row, place, flightId, profileId))
            {
                if (_bookingService.IsSeatBindedByCurrnetUser(row, place, flightId, profileId))
                {
                    _bookingService.RemoveTicketPreOrderForUser(row, place, flightId, profileId);
                    _bookingService.Commit();
                    return Json(new
                    {
                        Status = SEAT_STATUS_FREE,
                        Success = true
                    });
                }
                var ticketPreOrder = new TicketPreOrder
                {
                    DateTime = DateTime.Now,
                    Place = place,
                    Row = row,
                    FlightId = flightId
                };
                if (User.Identity.IsAuthenticated)
                {
                    ticketPreOrder.ProfileId = profileId;
                }
                _bookingService.AddTicketPreOrder(ticketPreOrder);
                _bookingService.Commit();
                return Json(new
                {
                    Status = SEAT_STATUS_OCCUPIED,
                    Success = true
                });
            }
            return Json(new
            {
                Success = false
            });
        }

        [Authorize]
        public ActionResult CancelSelectedSeats(int? flightId)
        {
            if (flightId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var flight = _bookingService.GetFlight(flightId.Value);
            if (flight == null)
            {
                return HttpNotFound();
            }
            _bookingService.MarkTicketPreOrdersAsDeletedForUser(flightId.Value,
                IdentityManager.GetProfileIdFromAuthCookie(HttpContext));
            _bookingService.Commit();
            return RedirectToAction("Flights",
                new
                {
                    departureAirportId = flight.DepartureAirportId,
                    arivingAirportId = flight.ArivingAirportId
                });
        }

        [Authorize]
        public ActionResult ConfirmSelectedSeats(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            var flight = _bookingService.GetFlight(id.Value);

            if (flight == null)
            {
                return HttpNotFound();
            }

            var model = new ConfirmSelectedSeatsViewModel
            {
                FlightId = flight.Id,
                SelectedSeats = PlaneSeat.GetAllSeats(_bookingService.GetFlightTicketPreOrdersForCurrentUser(flight.Id,
                    IdentityManager.GetProfileIdFromAuthCookie(HttpContext)))
            };

            ApplyFlightModel(flight);

            List<Sector> sectors = _bookingService.GetSectorsByPlaneId(flight.PlaneId);
            PlaneSeat.SetSeatTypes(model.SelectedSeats, sectors);

            return View(model);
        }

        private void ApplyFlightModel(Flight flight)
        {
            var model = new FlightViewModel
            {
                Id = flight.Id,
                Code = $"{_airlinesCode} {flight.Id:D4}",
                DepartureDate = flight.DepartureDateTime.ToLocalTime().Date,
                DepartureTime = flight.DepartureDateTime.ToLocalTime().TimeOfDay,
                ArivingDate = flight.ArivingDateTime.ToLocalTime().Date,
                ArivingTime = flight.ArivingDateTime.ToLocalTime().TimeOfDay,
                Prices = flight.SectorTypePrices.ToList(),
                PlaneModel = $"{flight.Plane.Manufacturer} {flight.Plane.Model}",
                DepartureAirportCode = flight.DepartureAirport.Code,
                DepartureAirportCity = flight.DepartureAirport.City,
                DepartureAirportCountry = flight.DepartureAirport.Country,
                ArivingAirportCode = flight.ArivingAirport.Code,
                ArivingAirportCity = flight.ArivingAirport.City,
                ArivingAirportCountry = flight.ArivingAirport.Country,
                HandLuggage = flight.HandLuggage,
                Luggage = flight.Luggage
            };

            var discount = _accountService.GetActiveDiscountPercentage();
            if (discount != null)
            {
                ViewBag.Discount = discount;
                model.Prices.ForEach(x => x.Price = (x.Price * (1 - ((decimal)discount / 100m))));
            }

            ViewBag.FlightModel = model;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmSelectedSeats(ConfirmSelectedSeatsViewModel model)
        {
            var flight = _bookingService.GetFlight(model.FlightId);
            if (flight == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                ApplyFlightModel(flight);

                return View(model);
            }

            int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);

            List<TicketPreOrder> ticketPreOrders = _bookingService.GetFlightTicketPreOrdersForCurrentUser(model.FlightId, profileId);

            if (ticketPreOrders.Count == 0)
            {
                TempData[MESSAGE_KEY] = "Sorry, choosen tickets are already booked. You can choose other onces.";
                return RedirectToAction("SelectSeats", new { id = flight.Id });
            }

            var tickets = ticketPreOrders.Select(x => new Ticket
            {
                Place = x.Place,
                Row = x.Row,
                SaleDate = DateTime.Now,
                Flight = flight,
                ProfileId = profileId
            }).ToList();

            var namedTickets = tickets.Select(x => new NamedTicket
                {
                    Ticket = x,
                    Name = model.SelectedSeats.First(z => z.Row == x.Row && z.Place == x.Place).Name,
                    Surname = model.SelectedSeats.First(z => z.Row == x.Row && z.Place == x.Place).Surname,
                    PassportNumber = model.SelectedSeats.First(z => z.Row == x.Row && z.Place == x.Place).PassportNumber,
                })
                .ToList();

            _bookingService.RemoveTicketPreOrdersForUser(flight.Id, profileId);
            _bookingService.BookTickets(tickets);
            _bookingService.SendTickets(namedTickets, Server.MapPath("~/"), _accountService.GetProfile(profileId));

            _bookingService.Commit();

            return RedirectToAction("Index", "Flight");
        }

        [AuthorizeAdmin]
        public ActionResult AddFlight()
        {
            // todo: check this
            ViewBag.Planes = new SelectList(_bookingService.GetAllPlanes()
                .Select(x => new {Id = x.Id, Model = $"{x.Manufacturer} {x.Model}"}), 
                PLANE_ID_COLUMN, 
                PLANE_MODEL_COLUMN);

            var airports = _airportService.GetAllAirports();

            ViewBag.DepartureAirports = new SelectList(airports
                    .Select(x => new { Id = x.Id, Code = x.Code }),
                AIRPORT_ID_COLUMN,
                AIRPORT_CODE_COLUMN);

            ViewBag.ArivingAirports = new SelectList(airports
                    .Select(x => new { Id = x.Id, Code = x.Code }),
                AIRPORT_ID_COLUMN,
                AIRPORT_CODE_COLUMN);

            AddFlightViewModel model = new AddFlightViewModel
            {
                SeatTypePrices = new List<SectorTypePrice>(),
                DepartureDate = DateTime.Now,
                ArivingDate = DateTime.Now
            };

            _bookingService.GetSeatTypesForPlane(int.Parse(((SelectList)ViewBag.Planes).First().Value))
                .ForEach(x => model.SeatTypePrices.Add(new SectorTypePrice
                {
                    SeatTypeId = x
                }));
            return View(model);
        }

        [AuthorizeAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlight(AddFlightViewModel model)
        {
            // todo: check this
            ViewBag.Planes = new SelectList(_bookingService.GetAllPlanes()
                    .Select(x => new { Id = x.Id, Model = $"{x.Manufacturer} {x.Model}" }),
                PLANE_ID_COLUMN,
                PLANE_MODEL_COLUMN);

            if (ModelState.IsValid)
            {
                DateTime departureDateTime = model.DepartureDate.ToUniversalTime().Add(model.DepartureTime);
                DateTime arivingDateTime = model.DepartureDate.ToUniversalTime().Add(model.DepartureTime);

                if (model.DepartureAirportId == model.ArivingAirportId)
                {
                    ModelState.AddModelError(String.Empty, "Departure and araving airports must be different.");
                }

                if (departureDateTime > arivingDateTime)
                {
                    ModelState.AddModelError(String.Empty, "Added flight can't be in the past.");
                    return View(model);
                }

                if (departureDateTime <= DateTime.Now)
                {
                    ModelState.AddModelError(String.Empty, "Added flight can't be in the past.");
                    return View(model);
                }

                _bookingService.AddFlight(new Flight
                {
                    DepartureDateTime = departureDateTime,
                    ArivingDateTime = arivingDateTime,
                    DepartureAirportId = model.DepartureAirportId,
                    ArivingAirportId = model.ArivingAirportId,
                    IsDeleted = false,
                    PlaneId = model.PlaneId,
                    RemoveExecutorId = null,
                    SectorTypePrices = model.SeatTypePrices,
                    HandLuggage = model.HandLuggage,
                    Luggage = model.Luggage
                });
                _bookingService.Commit();

                return RedirectToAction("Flights",
                    new
                    {
                        departureAirportId = model.DepartureAirportId,
                        arivingAirportId = model.ArivingAirportId
                    });
            }

            model.SeatTypePrices = new List<SectorTypePrice>();

            _bookingService.GetSeatTypesForPlane(model.PlaneId)
                .ForEach(x => model.SeatTypePrices.Add(new SectorTypePrice
                {
                    SeatTypeId = x
                }));

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetSeatTypes(int planeId)
        {
            var model = new List<SectorTypePrice>();
            _bookingService.GetSeatTypesForPlane(planeId).ForEach(x => model.Add(new SectorTypePrice()
            {
                SeatTypeId = x
            }));
            ViewData.TemplateInfo.HtmlFieldPrefix = nameof(AddFlightViewModel.SeatTypePrices);
            return PartialView("_SeatTypePrices", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _flightService.Dispose();
                _bookingService.Dispose();
                _accountService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}