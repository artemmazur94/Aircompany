using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.DataAccess.Entities;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models.Booking;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMovieService _movieService;
        private readonly IAccountService _accountService;

        private const string MESSAGE_KEY = "Message";
        private const string PLANE_ID_COLUMN = "Id";
        private const string PLANE_NAME_COLUMN = "Model";

        private const string SEAT_STATUS_FREE = "Free";
        private const string SEAT_STATUS_OCCUPIED = "Occupied";

        public BookingController(IBookingService bookingService, IMovieService movieService, IAccountService accountService)
        {
            _bookingService = bookingService;
            _movieService = movieService;
            _accountService = accountService;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        // GET: Booking/Seances/5
        public ActionResult Seances(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _movieService.GetMovie(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            List<Seance> seances = _bookingService.GetActiveSeancesByMovieId(id.Value);
            var seanceModels = seances.Select(seance => new SeanceViewModel()
            {
                Id = seance.Id,
                Date = seance.DateTime.ToLocalTime().Date,
                Time = seance.DateTime.ToLocalTime().TimeOfDay,
                PlaneModel = $"{seance.Plane.Manufacturer} {seance.Plane.Model}",
                Prices = seance.SectorTypePrices.ToList()
            }).ToList();
            var model = new MovieSeanceViewModel()
            {
                Id = movie.Id,
                Name = _movieService.GetMovieLocalization(id.Value, LanguageHelper.CurrnetCulture).Name,
                Poster = movie.Photo,
                Seances = seanceModels,
            };
            return View(model);
        }

        [Authorize]
        // GET: Booking/BookTikets/5
        public ActionResult SelectSeats(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            Seance seance = _bookingService.GetSeance(id.Value);
            if (seance == null)
            {
                return HttpNotFound();
            }
            MovieLocalization movieLocalization = _movieService.GetMovieLocalization(seance.MovieId,
                LanguageHelper.CurrnetCulture);
            var model = new SeanceViewModel()
            {
                Id = seance.Id,
                Date = seance.DateTime.ToLocalTime().Date,
                Time = seance.DateTime.ToLocalTime().TimeOfDay,
                Prices = seance.SectorTypePrices.ToList(),
                PlaneModel = $"{seance.Plane.Manufacturer} {seance.Plane.Model}",
                MovieName = movieLocalization.Name,
                MovieId = movieLocalization.MovieId
            };
            List<Sector> sectors = _bookingService.GetSectorsByPlaneId(seance.PlaneId);
            if (sectors.Count > 0)
            {
                model.PlanePlan = PlaneHelper.CreatePlanePlan(sectors);
                int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);
                List<Ticket> seanceTickets = _bookingService.GetSeanceTickets(seance.Id);
                List<TicketPreOrder> seanceTicketPreOrders = _bookingService.GetSeanceTicketPreOrdersOfOtherUsers(seance.Id, profileId);
                model.Seats = PlaneSeat.GetAllSeats(seanceTickets, seanceTicketPreOrders);
                model.SelectedSeats = PlaneSeat.GetAllSeats(_bookingService.GetSeanceTicketPreOrdersForCurrentUser(seance.Id, profileId));
            }
            if (TempData[MESSAGE_KEY] != null)
            {
                ViewBag.Message = TempData[MESSAGE_KEY].ToString();
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePlaceStatus(int row, int place, int seanceId)
        {
            int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);
            if (_bookingService.IsTicketAbleToBook(row, place, seanceId) && !_bookingService.IsSeatBindedToOtherUser(row, place, seanceId, profileId))
            {
                if (_bookingService.IsSeatBindedByCurrnetUser(row, place, seanceId, profileId))
                {
                    _bookingService.RemoveTicketPreOrderForUser(row, place, seanceId, profileId);
                    _bookingService.Commit();
                    return Json(new
                    {
                        Status = SEAT_STATUS_FREE,
                        Success = true
                    });
                }
                var ticketPreOrder = new TicketPreOrder()
                {
                    DateTime = DateTime.UtcNow,
                    Place = place,
                    Row = row,
                    SeanceId = seanceId
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
        public ActionResult CancelSelectedSeats(int? seanceId)
        {
            if (seanceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            Seance seance = _bookingService.GetSeance(seanceId.Value);
            if (seance == null)
            {
                return HttpNotFound();
            }
            _bookingService.MarkTicketPreOrdersAsDeletedForUser(seanceId.Value,
                IdentityManager.GetProfileIdFromAuthCookie(HttpContext));
            _bookingService.Commit();
            return RedirectToAction("Seances", new { id = seance.MovieId });
        }

        [Authorize]
        public ActionResult ConfirmSelectedSeats(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            Seance seance = _bookingService.GetSeance(id.Value);

            if (seance == null)
            {
                return HttpNotFound();
            }

            MovieLocalization movieLocalization = _movieService.GetMovieLocalization(seance.MovieId, LanguageHelper.CurrnetCulture);

            var model = new SeanceViewModel
            {
                Id = seance.Id,
                Date = seance.DateTime.ToLocalTime().Date,
                Time = seance.DateTime.ToLocalTime().TimeOfDay,
                Prices = seance.SectorTypePrices.ToList(),
                PlaneModel = $"{seance.Plane.Manufacturer} {seance.Plane.Model}",
                MovieName = movieLocalization.Name,
                MovieId = movieLocalization.MovieId,
                SelectedSeats =
                    PlaneSeat.GetAllSeats(_bookingService.GetSeanceTicketPreOrdersForCurrentUser(seance.Id,
                        IdentityManager.GetProfileIdFromAuthCookie(HttpContext)))
            };

            List<Sector> sectors = _bookingService.GetSectorsByPlaneId(seance.PlaneId);
            PlaneSeat.SetSeatTypes(model.SelectedSeats, sectors);

            return View(model);
        }

        [Authorize]
        public ActionResult BookTickets(int? seanceId)
        {
            if (seanceId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            Seance seance = _bookingService.GetSeance(seanceId.Value);
            if (seance == null)
            {
                return HttpNotFound();
            }
            int profileId = IdentityManager.GetProfileIdFromAuthCookie(HttpContext);
            List<TicketPreOrder> ticketPreOrders = _bookingService.GetSeanceTicketPreOrdersForCurrentUser(
                seanceId.Value, profileId);
            if (ticketPreOrders.Count == 0)
            {
                TempData[MESSAGE_KEY] = "Sorry, choosen tickets are already booked. You can choose other onces.";
                return RedirectToAction("SelectSeats", new { id = seance.Id });
            }
            List<Ticket> tickets = (from ticketPreOrder in ticketPreOrders
                                    select new Ticket()
                                    {
                                        Place = ticketPreOrder.Place,
                                        Row = ticketPreOrder.Row,
                                        SaleDate = DateTime.UtcNow,
                                        Seance = seance,
                                        ProfileId = profileId
                                    }).ToList();
            _bookingService.RemoveTicketPreOrdersForUser(seance.Id, profileId);
            _bookingService.BookTickets(tickets);
            _bookingService.SendTickets(tickets, LanguageHelper.CurrnetCulture, Server.MapPath("~/"),
                _accountService.GetProfile(profileId));
            _bookingService.Commit();
            return RedirectToAction("Index", "Movie");
        }

        [AuthorizeAdmin]
        public ActionResult AddSeance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            Movie movie = _movieService.GetMovie(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }

            // todo: check this
            ViewBag.Planes = new SelectList(_bookingService.GetAllPlanes()
                .Select(x => new {Id = x.Id, Model = $"{x.Manufacturer} {x.Model}"}), 
                PLANE_ID_COLUMN, 
                PLANE_NAME_COLUMN);

            MovieLocalization movieLocalization = _movieService.GetMovieLocalization(movie.Id, LanguageHelper.CurrnetCulture);
            AddSeanceViewModel model = new AddSeanceViewModel()
            {
                MovieId = movie.Id,
                MovieName = movieLocalization.Name,
                SeatTypePrices = new List<SectorTypePrice>(),
                Date = DateTime.Now
            };
            _bookingService.GetSeatTypesForPlane(int.Parse(((SelectList)ViewBag.Planes).First().Value))
                .ForEach(x => model.SeatTypePrices.Add(new SectorTypePrice()
                {
                    SeatTypeId = x
                }));
            return View(model);
        }

        [AuthorizeAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSeance(AddSeanceViewModel model)
        {
            // todo: check this
            ViewBag.Planes = new SelectList(_bookingService.GetAllPlanes()
                    .Select(x => new { Id = x.Id, Model = $"{x.Manufacturer} {x.Model}" }),
                PLANE_ID_COLUMN,
                PLANE_NAME_COLUMN);

            if (ModelState.IsValid)
            {
                DateTime dateTime = model.Date.ToUniversalTime().Add(model.Time);
                if (dateTime <= DateTime.UtcNow)
                {
                    ModelState.AddModelError(String.Empty, "Added seance can't be in the past.");
                    return View(model);
                }
                int movieLength = _movieService.GetMovie(model.MovieId).Length;
                if (_bookingService.IsAvailableSeanceTime(model.PlaneId, dateTime, movieLength))
                {
                    _bookingService.AddSeance(new Seance()
                    {
                        DateTime = dateTime,
                        PlaneId = model.PlaneId,
                        MovieId = model.MovieId,
                        SectorTypePrices = model.SeatTypePrices
                    });
                    _bookingService.Commit();
                    return RedirectToAction("Seances", new { id = model.MovieId });
                }
                ModelState.AddModelError(String.Empty, "Time is intersepting with other seance(s).");
            }
            model.SeatTypePrices = new List<SectorTypePrice>();
            _bookingService.GetSeatTypesForPlane(model.PlaneId)
                .ForEach(x => model.SeatTypePrices.Add(new SectorTypePrice()
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
            ViewData.TemplateInfo.HtmlFieldPrefix = nameof(AddSeanceViewModel.SeatTypePrices);
            return PartialView("_SeatTypePrices", model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _movieService.Dispose();
                _bookingService.Dispose();
                _accountService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}