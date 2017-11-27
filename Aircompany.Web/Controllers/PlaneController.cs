using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.DataAccess.Entities;
using Aircompany.DataAccess.Enums;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models.Plane;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class PlaneController : Controller
    {
        private readonly IPlaneService _planeService;
        private readonly IFlightService _flightService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        public PlaneController(IPlaneService planeService, IFlightService flightService)
        {
            _planeService = planeService;
            _flightService = flightService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var planes = _planeService.GetAllPlanes();
            var planeLocalizations = _planeService.GetAllPlaneLocalizations(LanguageHelper.CurrnetCulture);

            var model = planes.Select(x => new PlaneViewModel
            {
                Id = x.Id,
                PlaneModel = x.Model,
                MaxSpeed = x.MaxSpeed,
                Manufacturer = x.Manufacturer,
                Name = planeLocalizations.FirstOrDefault(z => z.PlaneId == x.Id)?.Name,
                Description = planeLocalizations.FirstOrDefault(z => z.PlaneId == x.Id)?.Description,
                PhotoEntity = x.PhotoId.HasValue ? _planeService.GetPhoto(x.PhotoId.Value) : null
            }).ToList();

            return View(model);
        }

        [HttpGet]
        [AuthorizeAdmin]
        public ActionResult AddPlane()
        {
            var model = new PlaneViewModel
            {
                EconomSector = new SectorViewModel(),
                BusinessSector = new SectorViewModel(),
                FirstClassSector = new SectorViewModel()
            };

            return View("AddPlane", model);
        }

        [HttpPost]
        [AuthorizeAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult AddPlane(PlaneViewModel model)
        {
            if (!model.BusinessSector.IsIncluded && !model.EconomSector.IsIncluded && !model.FirstClassSector.IsIncluded)
            {
                ModelState.AddModelError(String.Empty, "At least one type of seats should be included");
                return View(model);
            }

            if (!ValidateSector(model.EconomSector) || !ValidateSector(model.BusinessSector) || !ValidateSector(model.FirstClassSector))
            {
                return View(model);
            }

            var sectors = CreatePlaceSectors(model);

            Photo photo = null;
            if (model.Photo != null)
            {
                photo = _flightService.SetPhotoToDirectory(model.Photo, Server.MapPath("~/"));
            }

            var plane = new Plane
            {
                Photo = photo,
                Manufacturer = model.Manufacturer,
                Model = model.PlaneModel,
                MaxSpeed = model.MaxSpeed,
                Sectors = sectors,
                PlaneLocalizations = new List<PlaneLocalization>
                {
                    new PlaneLocalization
                    {
                        Name = model.Name,
                        Description = model.Description,
                        LanguageId = LanguageHelper.CurrnetCulture
                    }
                }
            };

            _planeService.AddPlane(plane);
            _planeService.Commit();

            return RedirectToAction("Details", new {id = plane.Id});
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            var plane = _planeService.GetPlane(id.Value);
            if (plane == null)
            {
                return HttpNotFound();
            }

            var planeLocalization = _planeService.GetPlaneLocalization(id.Value, LanguageHelper.CurrnetCulture);

            var model = new PlaneViewModel
            {
                Id = plane.Id,
                Manufacturer = plane.Manufacturer,
                PlaneModel = plane.Model,
                MaxSpeed = plane.MaxSpeed,
                Name = planeLocalization?.Name,
                Description = planeLocalization?.Description,
                PhotoEntity = plane.Photo
            };

            return View(model);
        }

        private bool ValidateSector(SectorViewModel sector)
        {
            if (!sector.IsIncluded)
            {
                return true;
            }

            if (sector.NumberOfRows <= 0)
            {
                ModelState.AddModelError(String.Empty, "Number of rows must be positive number.");
                return false;
            }

            if (sector.NumberOfPlaces <= 0)
            {
                ModelState.AddModelError(String.Empty, "Number of places must be positive number.");
                return false;
            }

            return true;
        }

        private List<Sector> CreatePlaceSectors(PlaneViewModel model)
        {
            var result = new List<Sector>();

            AddSector(result, model.FirstClassSector, SeatType.First);
            AddSector(result, model.BusinessSector, SeatType.Business);
            AddSector(result, model.EconomSector, SeatType.Econom);

            return result;
        }

        private void AddSector(List<Sector> result, SectorViewModel sector, SeatType seatType)
        {
            if (!sector.IsIncluded)
            {
                return;
            }

            int row = !result.Any() ? 1 : result.Max(x => x.ToRow) + 1;

            result.Add(new Sector
            {
                SeatTypeId = (int)seatType,
                FromPlace = 1,
                ToPlace = sector.NumberOfPlaces,
                FromRow = row,
                ToRow = row + sector.NumberOfRows
            });
        }
    }
}