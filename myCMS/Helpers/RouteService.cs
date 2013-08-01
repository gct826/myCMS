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
            if (controllerContext == null)
            {

                var translation = new TranslationHelper();
                var defaultTranslation = translation.DefaultTranslation();

                //string defaultTranslation = "test";

                return new RouteValues
                    {
                        Language = defaultTranslation,
                        //Language = "language",
                        Controller = "controller",
                        Action = "action"
                    };
            }
            return new RouteValues
                {
                    Language = controllerContext.RouteData.Values["language"].ToString(),
                    Controller = controllerContext.RouteData.Values["controller"].ToString(),
                    Action = controllerContext.RouteData.Values["action"].ToString(),
                };
        }
    }
}