using System.Web.Mvc;
using myCMS.Helpers;

namespace myCMS.Binders
{
    public class RouteBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return new RouteValues
                       {
                           Language = controllerContext.RouteData.Values["language"].ToString(),
                           Controller = controllerContext.RouteData.Values["controller"].ToString(),
                           Action = controllerContext.RouteData.Values["action"].ToString(),
                           Id = controllerContext.RouteData.Values["id"].ToString(),
                       };
        }
    }
}