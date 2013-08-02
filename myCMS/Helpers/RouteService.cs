using System;
using System.Net.Mime;
using System.Web.Mvc;
using myCMS.Models;

namespace myCMS.Helpers
{
    public class RouteService : IRouteService
    {

        public RouteValues GetRouteValues(ControllerContext controllerContext)
        {
            var translation = new TranslationHelper();
            var idRV = "";

            try 
            {
                idRV = controllerContext.RouteData.Values["id"].ToString();
            }
            catch
            {
                idRV = "no id";
            }

            if (controllerContext == null)
            {
                return new RouteValues
                    {
                        Language = translation.DefaultTranslation(),
                        Controller = "controller",
                        Action = "action",
                        Id = idRV
                    };
            }

            if (!translation.ValidTranslation(controllerContext.RouteData.Values["language"].ToString()))
            {
                return new RouteValues
                    {
                        Language = "error",
                        Controller = controllerContext.RouteData.Values["controller"].ToString(),
                        Action = controllerContext.RouteData.Values["action"].ToString(),
                        Id = idRV
                    };
            }

            return new RouteValues
                {
                    Language = controllerContext.RouteData.Values["language"].ToString(),
                    Controller = controllerContext.RouteData.Values["controller"].ToString(),
                    Action = controllerContext.RouteData.Values["action"].ToString(),
                    Id=idRV
                };
        }

    }
}