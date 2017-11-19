using System.Collections.Generic;
using System.Linq;
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
                Description = planeLocalizations.FirstOrDefault(z => z.PlaneId == x.Id)?.Description
            }).ToList();

            return View(model);
        }
    }
}