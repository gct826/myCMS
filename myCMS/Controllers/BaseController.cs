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
        }

        protected RouteValues RouteValue
        {
            get { return _routeService.GetRouteValues(ControllerContext); }
        }

    }
}