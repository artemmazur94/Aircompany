using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using Aircompany.Services.Services.Contracts;
using Aircompany.Web.Helpers;
using Aircompany.Web.Models.Plane;

namespace Aircompany.Web.Controllers
{
    [HandleLogError]
    public class PlaneController : Controller
    {
        private readonly IPlaneService _planeService;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            LanguageHelper.InitializeCulture(HttpContext);
        }

        public PlaneController(IPlaneService planeService)
        {
            _planeService = planeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var planes = _planeService.GetAllPlanes();
            var planeLocalizations = _planeService.GetAllPlaneLocalizations(LanguageHelper.CurrnetCulture);

            var model = planes.Select(x => new PlaneViewModel
            {
                Id = x.Id,
                Model = x.Model,
                MaxSpeed = x.MaxSpeed,
                Manufacturer = x.Manufacturer,
                Name = planeLocalizations.FirstOrDefault(z => z.PlaneId == x.Id)?.Name,
                Description = planeLocalizations.FirstOrDefault(z => z.PlaneId == x.Id)?.Description,
                // todo: check this
                PhotoPath = x.Photo == null ? null : x.Photo.Path + x.Photo.Filename
            }).ToList();

            return View(model);
        }

        [HttpGet]
        [AuthorizeAdmin]
        public ActionResult Create()
        {
            return View("CreateEdit", new PlaneViewModel());
        }

        [HttpPost]
        [AuthorizeAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit()
        {
            throw new System.NotImplementedException();
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
                Model = plane.Model,
                MaxSpeed = plane.MaxSpeed,
                Name = planeLocalization?.Name,
                Description = planeLocalization?.Description,
                PhotoPath = plane.Photo == null ? null : plane.Photo.Path + plane.Photo.Filename
            };

            return View(model);
        }
    }
}