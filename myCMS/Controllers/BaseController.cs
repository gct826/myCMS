using System.Web.Mvc;
using myCMS.Helpers;

namespace myCMS.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IRouteService _routeService;

        public BaseController(IRouteService routeService)
        {
            _routeService = routeService;

            //RouteValues routeValues = RouteValue;

            //if (routeValues.Language == "error")
            //{
            //    RedirectToAction("index", "error");
            //}

            //ViewBag.langRV = routeValues.Language;
            //ViewBag.contRV = routeValues.Controller;
            //ViewBag.actiRV = routeValues.Action;

        }

        protected RouteValues RouteValue
        {
            get { return _routeService.GetRouteValues(ControllerContext); }
        }

    }
}