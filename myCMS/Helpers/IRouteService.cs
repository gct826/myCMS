using System.Web.Mvc;

namespace myCMS.Helpers
{
    public interface IRouteService
    {
        RouteValues GetRouteValues(ControllerContext controllerContext);
    }
}